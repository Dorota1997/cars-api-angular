import { Component, OnInit } from '@angular/core';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-mat-menu-button',
  templateUrl: './mat-menu-button.component.html',
  styleUrls: ['./mat-menu-button.component.less']
})
export class MatMenuButtonComponent implements OnInit {

  @Output() valueChange = new EventEmitter();
  edit: boolean = false;
  constructor() { }

  ngOnInit() {
  }

  editRow() {
    this.edit = true;
    this.valueChange.emit(this.edit);
  }
  
}
