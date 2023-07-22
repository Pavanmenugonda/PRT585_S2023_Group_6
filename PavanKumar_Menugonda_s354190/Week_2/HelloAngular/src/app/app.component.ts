import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HelloAngular';
  myCount = 1;
  hideMe = true;

  countUp() {
    this.myCount += 1;
  }


}
