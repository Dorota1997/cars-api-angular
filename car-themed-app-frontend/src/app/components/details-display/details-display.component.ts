import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-details-display',
  templateUrl: './details-display.component.html',
  styleUrls: ['./details-display.component.less'],
})
export class DetailsDisplayComponent implements OnInit {
  @Input('rowData') rowData: any;
  @Input('title') title: string;
  @Output() displayChange = new EventEmitter();
  constructor() {}

  ngOnInit() {}

  closeInfo() {
    this.displayChange.emit(false);
  }
}
