import { Component, OnInit, Input } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { AuthService } from '../../../shared/services/auth.service';
import { Observable } from 'rxjs';
import { UserDto } from 'src/app/shared/services/service.base';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.scss']
})
export class UserMenuComponent implements OnInit {

  constructor(public appService: AppService, public authService: AuthService) {

  }

  isLoggedIn: boolean;
  userInfo: UserDto;
  ngOnInit() {
    this.authService.isLoggedIn().subscribe(value => {
      this.isLoggedIn = value;
      if (value) {
        this.authService.getUserInfo().then(info => {
          console.log(info);
          
          this.userInfo = info;
        })
      }
    })
  }

  logOut() {
    this.authService.logOut();
  }
}
