import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Observable } from 'rxjs';
import { SharedDataService } from '@service/shared-data.service';

@Component({
  selector: 'app-mat-table',
  templateUrl: './mat-table.component.html',
  styleUrls: ['./mat-table.component.less'],
})
export class MatTableComponent implements OnInit {
  tableDataSrc;
  id: number;
  object = {};
  editable: boolean = false;
  details: boolean = false;
  rowNumber: number;
  @Input('tableColumns') tableCols: string[];
  @Input('tableData') tableData: Observable<any>;
  @Input('title') title: string;

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private sharedDataService: SharedDataService) {
    this.sharedDataService._isDeleted.subscribe((res: boolean) => {
      if (res) {
        const newData = this.tableDataSrc.data;
        const rowToDelete = newData.find((u) => u.id === this.id);
        this.tableDataSrc.data = newData.filter((obj) => obj !== rowToDelete);
        this.rowNumber = this.tableDataSrc.filteredData.length;
      }
    });
  }

  ngOnInit() {
    this.tableData.subscribe((res: any) => {
      this.tableDataSrc = new MatTableDataSource(res);
      this.tableDataSrc.sort = this.sort;
      this.tableDataSrc.paginator = this.paginator;
      this.rowNumber = this.tableDataSrc.filteredData.length;
    });
    this.tableCols.push('options');
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

  checkCol(col: string) {
    return col === "options" ? true : false;
  }

  isEditable(profile: number, id: number) {
    return this.editable && profile === id ? true : false;
  }

  isNotEditable(profile: number, id: number) {
    return this.editable && profile !== id ? true : false;
  }
}
