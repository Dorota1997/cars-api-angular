import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DealersService } from '@service/dealers.service';
import { Router } from '@angular/router';
import { OrdersService } from '@service/orders.service';

@Component({
  selector: 'app-details-data',
  templateUrl: './details-data.component.html',
  styleUrls: ['./details-data.component.less'],
})
export class DetailsDataComponent implements OnInit {
  @Input('rowData') rowData: any;
  @Output() valueChange = new EventEmitter();

  constructor(
    private dealersService: DealersService,
    private ordersService: OrdersService,
    private router: Router
  ) {}

  ngOnInit() {}

  closeEditRow() {
    this.valueChange.emit(false);
  }

  updateRowData() {
    switch (this.router.url) {
      case '/orders':
        this.ordersService.update(this.rowData).subscribe((res: any) => {
          this.valueChange.emit(false);
        });
        break;
      case '/dealers':
        this.dealersService.update(this.rowData).subscribe((res: any) => {
          this.valueChange.emit(false);
        });
        break;
    }
  }
}
