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
  @Output() valueChange = new EventEmitter();
  edit: boolean = true;

  constructor() { }

  ngOnInit() {
  closeEditRow() {
    this.edit = false;
    this.valueChange.emit(this.edit);
  }

}
