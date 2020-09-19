import { Component, OnInit } from '@angular/core';
import { OrdersService } from '@service/orders.service';
import { BehaviorSubject } from 'rxjs';
import { Order } from '@model/order.model';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.less'],
})
export class OrdersComponent implements OnInit {
  tableCols = ['components', 'orderDate', 'dealer'];
  orders = new BehaviorSubject<Order[]>([]);
  title = 'Orders';
  constructor(private ordersService: OrdersService) {
    this.showOrders();
  }

  ngOnInit() {}

  showOrders() {
    this.ordersService.orders().subscribe((res) => {
      this.orders.next(res.data);
    });
  }
}
