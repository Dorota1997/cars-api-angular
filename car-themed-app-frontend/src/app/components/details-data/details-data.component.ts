import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DealersService } from '@service/dealers.service';
import { OrdersService } from '@service/orders.service';

@Component({
  selector: 'app-details-data',
  templateUrl: './details-data.component.html',
  styleUrls: ['./details-data.component.less'],
})
export class DetailsDataComponent implements OnInit {
  @Input('rowData') rowData: any;
  @Input('title') title: any;
  @Output() valueChange = new EventEmitter();

  constructor(
    private dealersService: DealersService,
    private ordersService: OrdersService
  ) {}

  ngOnInit() {}

  closeEditRow() {
    this.valueChange.emit(false);
  }

  updateRowData() {
    switch (this.title) {
      case 'Orders':
        this.ordersService.update(this.rowData).subscribe((res: any) => {
          this.valueChange.emit(false);
        });
        break;
      case 'Dealers':
        this.dealersService.update(this.rowData).subscribe((res: any) => {
          this.valueChange.emit(false);
        });
        break;
    }
  }
}
