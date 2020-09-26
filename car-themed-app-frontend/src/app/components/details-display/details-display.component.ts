import { OrdersService } from '@service/orders.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DealersService } from '@service/dealers.service';
import { Order } from '@model/order.model';
import { Dealer } from '@model/dealer.model';

@Component({
  selector: 'app-details-display',
  templateUrl: './details-display.component.html',
  styleUrls: ['./details-display.component.less'],
})
export class DetailsDisplayComponent implements OnInit {
  title: string;
  element = {};
  constructor(
    public dialogRef: MatDialogRef<DetailsDisplayComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private dealersService: DealersService,
    private ordersService: OrdersService
  ) {
    this.title = data.title;
  }

  ngOnInit() {
    if (this.title === 'Dealers') this.getDealer(this.data.id);
    else this.getOrder(this.data.id);
  }

  public removeLastChar(title: string) {
    return title.slice(0, -1);
  }

  displayDealers() {
    return this.title === 'Dealers' ? true : false;
  }

  displayOrders() {
    return this.title === 'Orders' ? true : false;
  }

  getOrder(id: number) {
    this.ordersService.get(id).subscribe((order: Order) => {
      this.element = order;
    });
  }

  getDealer(id: number) {
    this.dealersService.get(id).subscribe((dealer: Dealer) => {
      this.element = dealer;
    });
  }

  close(): void {
    this.dialogRef.close();
  }
}
