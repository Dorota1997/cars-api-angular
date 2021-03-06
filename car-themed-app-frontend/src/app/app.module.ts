import { PageButtonsDirective } from './_directives/page-buttons.directive';
import { AddElementComponent } from '@components/add-element/add-element.component';
import { InputSearchComponent } from '@components/input-search/input-search.component';
import { DetailsDisplayComponent } from '@components/details-display/details-display.component';
import { DetailsDataComponent } from '@components/details-data/details-data.component';
import { RemoveModalComponent } from '@components/remove-modal/remove-modal.component';
import { MatMenuButtonComponent } from '@components/mat-menu-button/mat-menu-button.component';
import { MatTableComponent } from '@components/mat-table/mat-table.component';
import { BrowserModule } from '@angular/platform-browser';
import {
  CUSTOM_ELEMENTS_SCHEMA,
  NgModule,
  NO_ERRORS_SCHEMA,
} from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DealersComponent } from '@components/dealers/dealers.component';
import { APP_BASE_HREF } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { A11yModule } from '@angular/cdk/a11y';
import { OrdersComponent } from '@components/orders/orders.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { SatPopoverModule } from '@ncstate/sat-popover';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { MainPageComponent } from '@components/main-page/main-page.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    DealersComponent,
    MatTableComponent,
    OrdersComponent,
    MatMenuButtonComponent,
    RemoveModalComponent,
    DetailsDataComponent,
    DetailsDisplayComponent,
    MainPageComponent,
    InputSearchComponent,
    AddElementComponent,
    PageButtonsDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MDBBootstrapModule.forRoot(),
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    SatPopoverModule,
    MatInputModule,
    MatCardModule,
    MatTabsModule,
  ],
  exports: [A11yModule, MatDialogModule],
  schemas: [NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
  bootstrap: [AppComponent],
})
export class AppModule {}
