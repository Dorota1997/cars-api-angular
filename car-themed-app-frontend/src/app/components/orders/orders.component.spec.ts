import { OrdersService } from '@service/orders.service';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CUSTOM_ELEMENTS_SCHEMA, DebugElement } from '@angular/core';
import { OrdersComponent } from '@components/orders/orders.component';
import { HttpClientModule } from '@angular/common/http';
import { ErrorService } from '@service/error.service';

describe('OrdersComponent', () => {
  let component: OrdersComponent;
  let fixture: ComponentFixture<OrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OrdersComponent],
      imports: [HttpClientModule],
      providers: [OrdersService, ErrorService],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
