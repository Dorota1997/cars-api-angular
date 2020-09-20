import { Component, OnInit } from '@angular/core';
import { SharedDataService } from '@service/shared-data.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.less'],
})
export class MainPageComponent implements OnInit {
  dealers: boolean = true;
  dealer: string = 'dealers';
  order: string = 'orders';
  forms: boolean = false;
  formsName: string[] = ['name', 'address', 'postalCode', 'country'];
  constructor(private sharedDataService: SharedDataService) {}

  ngOnInit() {}

  tabClick(tab) {
    switch (tab.index) {
      case 0:
        this.forms = false;
        this.dealers = true;
        this.formsName = ['name', 'address', 'postalCode', 'country'];
        this.sharedDataService._title.next(this.dealer);
        break;
      case 1:
        this.forms = false;
        this.dealers = false;
        this.formsName = ['components', 'orderDate', 'dealerId'];
        this.sharedDataService._title.next(this.order);
        break;
    }
  }

  displayForms(event) {
    this.forms = event;
  }
}
