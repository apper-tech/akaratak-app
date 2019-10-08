import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { matchingPasswords, emailValidator, phoneNumberValidator } from 'src/app/theme/utils/app-validators';
import { AuthService } from '../../shared/services/auth.service';
import { RegisterInput } from '../../shared/services/service.base';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;
  public hide = true;
  public userTypes = [
    { id: 1, name: 'Agent' },
    { id: 2, name: 'Agency' },
    { id: 3, name: 'Buyer' }
  ];
  constructor(public fb: FormBuilder, public router: Router,
    public authService: AuthService,
    public snackBar: MatSnackBar) { }

  ngOnInit() {
    this.registerForm = this.fb.group({
      userType: ['', Validators.required],
      firstname: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      surname: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      email: ['', Validators.compose([Validators.required, emailValidator])],
      phoneNumber: ['', Validators.compose([Validators.required, phoneNumberValidator])],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      receiveNewsletter: false
    }, { validator: matchingPasswords('password', 'confirmPassword') });
  }

  public onRegisterFormSubmit(values: Object): void {
    if (this.registerForm.valid) {
      this.authService.register({
        userName: (values['firstname'] + '_' + values['surname']).toLocaleLowerCase(),
        emailAddress: values['email'],
        password: values['password'],
        userType: values['userType'].id,
        name: values['firstname'],
        surname: values['surname'],
        phoneNumber: values['phoneNumber']
      } as RegisterInput).then(result => {
        if (result)
          this.snackBar.open('You registered successfully!', '×',
            { panelClass: 'success', verticalPosition: 'top', duration: 3000 });
        else
          this.snackBar.open('Somthing Went Wrong!', '×',
            { panelClass: 'error', verticalPosition: 'top', duration: 3000 });
      })

    }
  }
}
