import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as Api from '../../shared/services/auth.service';
import { AuthenticateModel } from 'src/app/shared/services/service.base';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public hide = true;
  constructor(public fb: FormBuilder, public router: Router,
    public apiAuthService: Api.AuthService,
    public snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: [null, Validators.compose([Validators.required, Validators.minLength(6), Validators.email])],
      password: [null, Validators.compose([Validators.required, Validators.minLength(6)])],
      rememberMe: false
    });
  }

  public onLoginFormSubmit(values: Object): void {
    this.apiAuthService.authenticate({
      userNameOrEmailAddress: values['email'],
      password: values['password'],
      rememberClient: values['rememberMe']
    } as AuthenticateModel)
      .then((value: boolean) => {
        if (value)
          this.snackBar.open('Successfully Logged In!', '×',
            { panelClass: 'error', verticalPosition: 'top', duration: 3000 });
      }, (reason: boolean) => {
        this.snackBar.open('Username Or Password Incorrect!', '×',
          { panelClass: 'error', verticalPosition: 'top', duration: 3000 });
      })
  }
  public signInWithGoogle(): void {
    this.apiAuthService.externalAuthenticate(Api.SocialLoginTypes.Google);
  }

}
