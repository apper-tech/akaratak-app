import { Component, OnInit, ViewChild, HostListener, NgZone } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { AuthService, AuthModel } from 'src/app/shared/services/auth.service';
import { UserDto } from 'src/app/shared/services/service.base';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  public psConfig: PerfectScrollbarConfigInterface = {
    wheelPropagation: true
  };
  @ViewChild('sidenav', { static: true }) sidenav: any;
  public sidenavOpen: boolean = true;
  public links = [
    { name: 'Profile', href: 'profile', icon: 'person' },
    { name: 'My Properties', href: 'my-properties', icon: 'view_list' },
    { name: 'Favorites', href: 'favorites', icon: 'favorite' },
    { name: 'Submit Property', href: '/submit-property', icon: 'add_circle' },
    { name: 'Logout', href: '/login', icon: 'power_settings_new' },
  ];
  public userName;
  public photoUrl;
  constructor(public router: Router, private authService: AuthService, private zone: NgZone) { }

  ngOnInit() {
    if (window.innerWidth < 960) {
      this.sidenavOpen = false;
    };
    this.getUserInfo();
  }

  @HostListener('window:resize')
  public onWindowResize(): void {
    (window.innerWidth < 960) ? this.sidenavOpen = false : this.sidenavOpen = true;
  }

  ngAfterViewInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        if (window.innerWidth < 960) {
          this.sidenav.close();
        }
      }
    });
  }
  getUserInfo() {
    this.authService.isLoggedIn().subscribe((info: AuthModel) => {
      if (info.isLoggedIn) {
        this.zone.run(() => {
          this.userName = info.userInfo.fullName;
          this.photoUrl = info.userInfo.photo ? info.userInfo.photo.url : environment.defaultUserImagePath;
          console.log(this.photoUrl);

        })
      }
    })
  }


}
