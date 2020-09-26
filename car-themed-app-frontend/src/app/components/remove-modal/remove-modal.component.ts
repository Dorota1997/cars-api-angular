import { SharedDataService } from '@service/shared-data.service';
import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DealersService } from '@service/dealers.service';
import { OrdersService } from '@service/orders.service';

@Component({
  selector: 'app-remove-modal',
  templateUrl: './remove-modal.component.html',
  styleUrls: ['./remove-modal.component.less'],
})
export class RemoveModalComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<RemoveModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private ordersService: OrdersService,
    private dealersService: DealersService,
    private sharedDataService: SharedDataService
  ) {}

  ngOnInit() {}

  remove() {
    switch (this.data.title) {
      case 'Orders':
        this.removeOrder();
        break;
      case 'Dealers':
        this.removeDealer();
        break;
    }
  }

  removeOrder() {
    this.ordersService.remove(this.data.id).subscribe(() => {
      this.sharedDataService.setValue(true);
    });
  }

  removeDealer() {
    this.dealersService.remove(this.data.id).subscribe(() => {
      this.sharedDataService.setValue(true);
    });
  }

  close(): void {
    this.dialogRef.close();
  }
}
