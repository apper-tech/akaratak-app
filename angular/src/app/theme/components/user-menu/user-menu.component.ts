import { Component, OnInit, Input } from '@angular/core';
import { AppService } from 'src/app/app.service';
import { AuthService } from '../../../shared/services/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.scss']
})
export class UserMenuComponent implements OnInit {

  constructor(public appService: AppService, public authService: AuthService) {

  }

  isLoggedIn: boolean;
  ngOnInit() {
    this.authService.isLoggedIn().subscribe(value => {
      this.isLoggedIn = value;
    })
  }

  logOut() {
    this.authService.logOut();
  }
}
