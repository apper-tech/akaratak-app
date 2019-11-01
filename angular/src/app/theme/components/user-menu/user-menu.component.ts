import { Component, OnInit, Input, NgZone } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { AuthService } from '../../../shared/services/auth.service';
import { Observable } from 'rxjs';
import { UserDto } from 'src/app/shared/services/service.base';
import { environment } from '../../../../environments/environment';
@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.scss']
})
export class UserMenuComponent implements OnInit {

  constructor(public appService: AppService, public authService: AuthService, private zone: NgZone) {

  }

  isLoggedIn: boolean;
  userInfo: UserDto;
  userPhoto = environment.defaultUserImagePath;
  futureFeatures = false;


  ngOnInit() {
    this.authService.isLoggedIn().subscribe(value => {
      this.zone.run(() => {
        this.isLoggedIn = value ? value.isLoggedIn : false;
        if (value.isLoggedIn) {
          this.userInfo = value.userInfo;
          if (value.userInfo.photo)
            this.userPhoto = value.userInfo.photo.url;
        }
      });
    });
  }

  logOut() {
    this.authService.logOut();
  }
}
