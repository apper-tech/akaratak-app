import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { emailValidator, matchingPasswords, urlValidator, phoneNumberValidator } from 'src/app/theme/utils/app-validators';
import { MatSnackBar } from '@angular/material';
import { AuthService, AuthModel } from 'src/app/shared/services/auth.service';
import { UserDto, UpdateUserInput } from 'src/app/shared/services/service.base';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public infoForm: FormGroup;
  public passwordForm: FormGroup;
  constructor(public formBuilder: FormBuilder, public snackBar: MatSnackBar, public authService: AuthService) { }

  ngOnInit() {
    this.infoForm = this.formBuilder.group({
      firstname: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      surname: ['', Validators.compose([Validators.required, Validators.minLength(3)])],
      email: ['', Validators.compose([Validators.required, emailValidator])],
      phone: ['', Validators.compose([Validators.required, phoneNumberValidator])],
      image: null,
      organization: ['', Validators.compose([Validators.maxLength(25)])],
      facebook: ['', Validators.compose([urlValidator('facebook')])],
      twitter: ['', Validators.compose([urlValidator('twitter')])],
      linkedin: ['', Validators.compose([urlValidator('linkedin')])],
      instagram: ['', Validators.compose([urlValidator('instagram')])],
      website: ['', Validators.compose([urlValidator('website')])],
    });
    this.passwordForm = this.formBuilder.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', Validators.required],
      confirmNewPassword: ['', Validators.required]
    }, { validator: matchingPasswords('newPassword', 'confirmNewPassword') });
    this.getUserInfo();
  }

  public onInfoFormSubmit(values: Object): void {
    if (this.infoForm.valid) {
      this.authService.updateUser({
        emailAddress: values['email'],
        phoneNumber: values['phone'],
        name: values['firstname'],
        surname: values['surname'],
        organization: values['organization'],
        facebookUrl: values['facebook'],
        twitterUrl: values['twitter'],
        linkedinUrl: values['linkedin'],
        instagramUrl: values['instagram'],
        websiteUrl: values['website'],
      } as UpdateUserInput).then(result => {
        if (values['image']) {
          var image = values['image'][0];
          this.authService.updateUserPhoto(image.link, image.file).then(result2 => {
            this.proccessUpdateResult(result2);
          })
        }
        else
          this.proccessUpdateResult(result);
      })
    }
  }
  private proccessUpdateResult(done) {
    if (done) {
      this.authService.emitUserInfo(true);
      this.snackBar.open('Your account information updated successfully!', '×', { panelClass: 'success', verticalPosition: 'top', duration: 3000 });
    }
    else
      this.snackBar.open('An error Occurred while updating your profile!', '×', { panelClass: 'error', verticalPosition: 'top', duration: 3000 });
  }
  public onPasswordFormSubmit(values: Object): void {
    if (this.passwordForm.valid) {
      this.authService.updatePassword(values['currentPassword'],
        values['newPassword']).then(result => {
          this.proccessUpdateResult(result);
          if (result)
            setTimeout(() => { this.authService.logOut() }, 3000);
        })
    }
  }
  getUserInfo() {
    this.authService.isLoggedIn().subscribe((value: AuthModel) => {
      console.log('event');

      if (value.isLoggedIn) {
        var info = value.userInfo;
        this.infoForm.controls['firstname'].setValue(info.name);
        this.infoForm.controls['surname'].setValue(info.surname);
        this.infoForm.controls['email'].setValue(info.emailAddress);
        this.infoForm.controls['phone'].setValue(info.phoneNumber);
      }
    })
  }

}
