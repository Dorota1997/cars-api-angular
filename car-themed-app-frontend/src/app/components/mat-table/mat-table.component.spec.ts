import { MatMenuButtonComponent } from '@components/mat-menu-button/mat-menu-button.component';
import { DetailsDisplayComponent } from '@components/details-display/details-display.component';
import { DetailsDataComponent } from '@components/details-data/details-data.component';
import { MatCardModule } from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatTableComponent } from '@components/mat-table/mat-table.component';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { OrdersService } from '@service/orders.service';
import { ErrorService } from '@service/error.service';
import { DealersService } from '@service/dealers.service';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { DealersComponent } from '@components/dealers/dealers.component';
import { OrdersComponent } from '@components/orders/orders.component';
import { RemoveModalComponent } from '@components/remove-modal/remove-modal.component';

describe('MatTableComponent', () => {
  let component: MatTableComponent;
  let fixture: ComponentFixture<MatTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        MatTableComponent,
        DetailsDataComponent,
        DetailsDisplayComponent,
        MatMenuButtonComponent,
        DealersComponent,
        OrdersComponent,
        RemoveModalComponent,
      ],
      imports: [
        HttpClientModule,
        MatIconModule,
        BrowserAnimationsModule,
        BrowserModule,
        MatTableModule,
        MatMenuModule,
        MatTabsModule,
        MatCardModule,
        MatInputModule,
        ReactiveFormsModule,
        FormsModule,
        MatPaginatorModule,
        MatFormFieldModule,
        MatButtonModule,
      ],
      providers: [OrdersService, ErrorService, DealersService],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
