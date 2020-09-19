import { TestBed, async, inject } from '@angular/core/testing';
import { OrdersService } from './orders.service';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { Orders } from '@model/order.model';
import { environment } from 'src/environments/environment';

describe('Service: Orders', () => {
  let httpMock: HttpTestingController;
  let orderService: OrdersService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrdersService],
      imports: [HttpClientTestingModule],
    });

    httpMock = TestBed.get(HttpTestingController);
    orderService = TestBed.get(OrdersService);
  });

  it('should create', inject([OrdersService], (service: OrdersService) => {
    expect(service).toBeTruthy();
  }));

  it('be able to retrieve orders from the API bia GET', () => {
    const orderArray: Orders = {
      data: [
        {
          id: 29,
          components: 'Engine replacement for Citroen C3 Picasso',
          orderDate: '04.07.2017',
          dealer: 'Aston Martin service',
          dealerId: 69,
        },
        {
          id: 30,
          components: 'New brake pads for Honda Civic 3D',
          orderDate: '21.05.2019',
          dealer: 'Nuova - Car engines',
          dealerId: 64,
        },
        {
          id: 31,
          components: 'New suspension for Aston Martin Rapide',
          orderDate: '16.03.2016',
          dealer: 'Honda Cars/Motors Equipment',
          dealerId: 67,
        },
      ],
      pageNumber: 1,
      pageSize: 10,
      nextPage: 'https://localhost:44354/?pageNumber=2&pageSize=10',
      previousPage: null,
    };

    orderService.orders().subscribe((orders) => {
      expect(orders.data.length).toBe(3);
      expect(orders).toEqual(orderArray);
    });

    const request = httpMock.expectOne(`${environment.api}Orders?PageNumber=1`);
    expect(request.request.method).toBe('GET');
    request.flush(orderArray);
  });
});
