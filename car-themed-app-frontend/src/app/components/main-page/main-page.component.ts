import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.less'],
})
export class MainPageComponent implements OnInit {
  orders: boolean = false;
  dealers: boolean = true;
  constructor() {}

  ngOnInit() {}

  tabClick(tab) {
    if (tab.index === 0) {
      this.dealers = true;
      this.orders = !this.dealers;
    } else {
      this.dealers = false;
      this.orders = !this.dealers;
    }
  }
}
