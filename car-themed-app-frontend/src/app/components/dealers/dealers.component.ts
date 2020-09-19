import { Component, OnInit } from '@angular/core';
import { DealersService } from '@service/dealers.service';
import { BehaviorSubject } from 'rxjs';
import { Dealer } from '@model/dealer.model';

@Component({
  selector: 'app-dealers',
  templateUrl: './dealers.component.html',
  styleUrls: ['./dealers.component.less'],
})
export class DealersComponent implements OnInit {
  tableCols = ['name', 'address', 'country', 'postalCode'];
  dealers = new BehaviorSubject<Dealer[]>([]);
  title = 'Dealers';
  constructor(private dealersService: DealersService) {
    this.showDealers();
  }

  ngOnInit() {}

  showDealers() {
    this.dealersService.dealers().subscribe((res) => {
      this.dealers.next(res.data);
    });
  }
}
