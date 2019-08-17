import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/app.service';

@Component({
  selector: 'app-dark-mode',
  templateUrl: './dark-mode.component.html',
  styleUrls: ['./dark-mode.component.css']
})
export class DarkModeComponent implements OnInit {

  public darkmode: boolean;
  colors = ['green', 'orange-dark'];
  constructor(public appService: AppService) { }

  ngOnInit() {
  }
  changeMode() {
    if (this.darkmode) {
      this.appService.appSettings.settings.theme = this.colors[0];
      this.darkmode = false;
    }
    else {
      this.appService.appSettings.settings.theme = this.colors[1];
      this.darkmode = true;
    }
  }
}
