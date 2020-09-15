import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-remove-modal',
  templateUrl: './remove-modal.component.html',
  styleUrls: ['./remove-modal.component.less'],
})
export class RemoveModalComponent implements OnInit {
  constructor() {}
  constructor(public dialogRef: MatDialogRef<RemoveModalComponent>,

  ngOnInit() {}
  close(): void {
    this.dialogRef.close();
  }
}
