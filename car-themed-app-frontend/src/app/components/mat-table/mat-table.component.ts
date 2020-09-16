import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-mat-table',
  templateUrl: './mat-table.component.html',
  styleUrls: ['./mat-table.component.less'],
})
export class MatTableComponent implements OnInit {
  tableDataSrc: any;
  id;
  object: any = {};
  editable: boolean = false;
  details: boolean = false;
  rowNumber;
  @Input('tableColumns') tableCols: string[];
  @Input('tableData') tableData: Observable<any>;
  @Input('title') title: string;

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor() {}

  ngOnInit() {
    this.tableData.subscribe((res: any) => {
      this.tableDataSrc = new MatTableDataSource(res);
      this.tableDataSrc.sort = this.sort;
      this.tableDataSrc.paginator = this.paginator;
      this.rowNumber = this.tableDataSrc.filteredData.length;
    });
    this.tableCols.push('options');
    // this.tableDataSrc._updateChangeSubscription();
  }

  applyFilter(filterValue: string) {
    this.tableDataSrc.filter = filterValue.trim().toLowerCase();
    this.rowNumber = this.tableDataSrc.filteredData.length;
  }

  rowId(row) {
    this.id = row.id;
    this.object = row;
  }

  displayCounter(count) {
    this.editable = count;
  }

  displayDetails(count) {
    this.details = count;
  }
}
