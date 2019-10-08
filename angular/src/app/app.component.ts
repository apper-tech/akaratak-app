import { Component, NgZone } from '@angular/core';
import { Settings, AppSettings } from './app.settings';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public settings: Settings;
  constructor(public appSettings: AppSettings, public router: Router, public authService: AuthService, private zone: NgZone) {
    this.settings = this.appSettings.settings;
  }

  ngAfterViewInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.zone.run(() => {
          this.authService.emitUserInfo(false)
          setTimeout(() => {
            window.scrollTo(0, 0);
          });
        })
      }
    });
  }

}
