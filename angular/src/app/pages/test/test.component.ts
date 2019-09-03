import { Component, OnInit } from '@angular/core';
import { InsertProperty, Describer } from '../../app.models'
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    let test = {
      basic: {
        title: 'cool'
      }
    };
    let y = new InsertProperty();
    console.log(Object.getOwnPropertyNames(y));
  }

}
class A {
  x: number = 5;
}