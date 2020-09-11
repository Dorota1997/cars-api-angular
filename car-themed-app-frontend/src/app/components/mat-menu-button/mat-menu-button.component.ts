import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-mat-menu-button',
  templateUrl: './mat-menu-button.component.html',
  styleUrls: ['./mat-menu-button.component.less'],
})
export class MatMenuButtonComponent implements OnInit {
  @Input('rowId') id: number;
  @Output() valueChange = new EventEmitter();
  @Output() displayChange = new EventEmitter();
  detailsClick: boolean = false;
  constructor() {}

  ngOnInit() {}

  showId() {
    this.detailsClick = true;
  }

  editRow() {
    this.valueChange.emit(true);
  }

  showDetails() {
    this.displayChange.emit(true);
    window.scroll({
      top: 0,
      left: 0,
      behavior: 'smooth',
    });
  }
}
