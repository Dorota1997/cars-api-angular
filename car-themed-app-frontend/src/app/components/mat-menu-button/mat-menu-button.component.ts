import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DetailsDisplayComponent } from '@components/details-display/details-display.component';
import { RemoveModalComponent } from '@components/remove-modal/remove-modal.component';

@Component({
  selector: 'app-mat-menu-button',
  templateUrl: './mat-menu-button.component.html',
  styleUrls: ['./mat-menu-button.component.less'],
})
export class MatMenuButtonComponent implements OnInit {
  @Input('rowId') id: number;
  @Input('title') title;
  @Output() valueChange = new EventEmitter();
  constructor(public dialog: MatDialog) {}

  ngOnInit() {}

  editRow() {
    this.valueChange.emit(true);
  }

  showDetails() {
    this.dialog.open(DetailsDisplayComponent, {
      data: { id: this.id, title: this.title },
      minWidth: '40%',
    });
  }

  openDialog() {
    this.dialog.open(RemoveModalComponent, {
      data: { id: this.id, title: this.title }
    });
  }
}
