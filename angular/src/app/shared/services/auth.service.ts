import { Injectable, Output, EventEmitter } from '@angular/core';
import { Observable, of, throwError, Subject, BehaviorSubject } from 'rxjs';
import { AuthenticateModel, TokenAuthServiceProxy, AuthenticateResultModel, AccountServiceProxy, RegisterInput, RegisterOutput, ExternalAuthenticateModel, UserDto, ExternalAuthenticateResultModel, UpdateUserInput, FileParameter, UserServiceProxy, ChangePasswordDto } from './service.base';
import { Router } from '@angular/router';
import { TokenService } from './token.service';
import * as social from "angularx-social-login";
import {/*  FacebookLoginProvider, */ GoogleLoginProvider } from "angularx-social-login";
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn: BehaviorSubject<AuthModel> = new BehaviorSubject(undefined);

  constructor(private _tokenAuthService: TokenAuthServiceProxy,
    private _router: Router,
    private _tokenService: TokenService,
    private _userService: UserServiceProxy,
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
  public emitUserInfo(refresh): Promise<boolean> {
    return new Promise((resolve, reject) => {
      if (!refresh) {
        if (this._tokenService.hasToken())
          this.loggedIn.next({ isLoggedIn: true, userInfo: this._tokenService.getUser() });
        else
          this.loggedIn.next({ isLoggedIn: false } as AuthModel);
        resolve(true);
      }
      else {
        this._accountService.getUserInfo()
          .subscribe(user => {
            this._tokenService.setUser(user);
            this.loggedIn.next({ isLoggedIn: true, userInfo: user });
            resolve(true);
          });
      }
    })

  }
  public async updateUser(user: UpdateUserInput): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this._accountService.updateUser(user).subscribe(result => {
        resolve(result);
      }, error => reject(error))
    })
  }
  public async updateUserPhoto(photoUrl: string, photo: any): Promise<boolean> {
    return new Promise((resolve, reject) => {
      var file = photo ? ({ fileName: photo.name, data: photo } as FileParameter) : undefined;
      this._accountService.updatePhotoForUser(photoUrl, file)
        .subscribe(result => {
          resolve(result);
        }, error => reject(error));
    })
  }
  public async updatePassword(currentPassowrd: string, newPassword: string): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this._userService.changePassword(
        {
          currentPassword: currentPassowrd,
          newPassword: newPassword
        } as ChangePasswordDto).subscribe(result => {
          if (result) {
            resolve(result);
          }
          else
            reject(false);
        })
    })
  }
  public isLoggedIn(): Observable<AuthModel> {
    return this.loggedIn.asObservable();
  }
  public logOut() {
    this._tokenService.clearToken();
    this.emitUserInfo(false).then(result => {
      this._router.navigate(['/']);
    });
  }

  private processAuthenticateResult(authenticateResult: AuthenticateResultModel, rememberMe: boolean): Observable<boolean> {
    if (authenticateResult.accessToken) {
      // Successfully logged in
      this.login(
        authenticateResult.accessToken,
        authenticateResult.encryptedAccessToken,
        authenticateResult.expireInSeconds,
        rememberMe);
      return of(true);
    } else {
      return of(false);
    }
  }
  private login(accessToken: string, encryptedAccessToken: string, expireInSeconds: number, rememberMe?: boolean): void {
    const tokenExpireDate = rememberMe ? (new Date(new Date().getTime() + 1000 * expireInSeconds)) : undefined;
    this._tokenService.setToken(
      accessToken,
      tokenExpireDate
    );
    this.emitUserInfo(true).then(result => {
      if (result)
        this._router.navigate(['/']);
    })

  }
}
export enum SocialLoginTypes {
  Google
}
export class AuthModel {
  public isLoggedIn: boolean;
  public userInfo: UserDto;
}
