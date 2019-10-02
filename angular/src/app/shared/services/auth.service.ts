import { Injectable, Output, EventEmitter } from '@angular/core';
import { Observable, of, throwError, Subject, BehaviorSubject } from 'rxjs';
import { AuthenticateModel, TokenAuthServiceProxy, AuthenticateResultModel, AccountServiceProxy, RegisterInput, RegisterOutput, ExternalAuthenticateModel, UserDto } from './service.base';
import { Router } from '@angular/router';
import { TokenService } from './token.service';
import * as social from "angularx-social-login";
import {/*  FacebookLoginProvider, */ GoogleLoginProvider } from "angularx-social-login";
import { ExternalAuthenticateResultModel } from 'src/src/app/shared/services/service.base';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject(false);

  constructor(private _tokenAuthService: TokenAuthServiceProxy,
    private _router: Router,
    private _tokenService: TokenService,
    private _accountService: AccountServiceProxy,
    private _authService: social.AuthService) { }


  public async authenticate(authenticateModel: AuthenticateModel) {
    return new Promise((resolve, reject) => {
      this._tokenAuthService
        .authenticate(authenticateModel)
        .subscribe(
          res => resolve(this.processAuthenticateResult(res, authenticateModel.rememberClient)),
          err => {
            reject(false)
          }
        );
    })
  }
  public async register(input: RegisterInput) {
    return new Promise((resolve, reject) => {
      this._accountService.register(input)
        .subscribe((result: RegisterOutput) => {
          if (result.canLogin)
            this.authenticate(
              {
                userNameOrEmailAddress: input.emailAddress,
                password: input.password,
                rememberClient: true
              } as AuthenticateModel).then(value => {
                resolve(value);
              })
          reject(false);
        }, error => {
          console.log(error);

        })
    })
  }
  public async externalAuthenticate(type: SocialLoginTypes) {
    return new Promise((resolve, reject) => {
      switch (type) {
        case SocialLoginTypes.Google:
          this._authService.signIn(GoogleLoginProvider.PROVIDER_ID)
            .then((value: social.SocialUser) => {
              var externalUser = {
                name: value.firstName,
                surname: value.lastName,
                userName: value.name.replace(' ', '_').toLocaleLowerCase(),
                idToken: value.idToken,
                photoUrl: value.photoUrl,
                userType: 3,
                emailAddress: value.email,
                password: '123qwe'
              } as ExternalAuthenticateModel;
              console.log(externalUser);
              this._tokenAuthService.externalAuthenticate(externalUser)
                .subscribe((res: ExternalAuthenticateResultModel) =>
                  resolve(this.processAuthenticateResult(
                    {
                      accessToken: res.accessToken,
                      expireInSeconds: res.expireInSeconds,
                      encryptedAccessToken: res.encryptedAccessToken
                    } as AuthenticateResultModel, true)),
                  err => {
                    reject(false)
                  })

            });
          break;
      }
    })
  }
  public async getUserInfo(): Promise<UserDto> {
    return new Promise((resolve, reject) => {
      this._authService.authState.subscribe(user => {
        this._accountService.getUserInfo(user.idToken)
          .subscribe((data: UserDto) => {
            resolve(data);
          }, (error) => reject(error))
      }, (error) => reject(error))
    })
  }

  public isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }
  public logOut() {
    this._tokenService.clearToken();
    this.loggedIn.next(this._tokenService.hasToken());
    this._router.navigate(['/'])
  }

  private processAuthenticateResult(authenticateResult: AuthenticateResultModel, rememberMe: boolean): boolean {
    if (authenticateResult.accessToken) {
      // Successfully logged in
      this.login(
        authenticateResult.accessToken,
        authenticateResult.encryptedAccessToken,
        authenticateResult.expireInSeconds,
        rememberMe);
      return true;
    } else {
      return false;
    }
  }
  private login(accessToken: string, encryptedAccessToken: string, expireInSeconds: number, rememberMe?: boolean): void {

    const tokenExpireDate = rememberMe ? (new Date(new Date().getTime() + 1000 * expireInSeconds)) : undefined;
    this._tokenService.setToken(
      accessToken,
      tokenExpireDate
    );
    this.loggedIn.next(this._tokenService.hasToken());
    this._router.navigate(['/']);
  }
}
export enum SocialLoginTypes {
  Google
}
