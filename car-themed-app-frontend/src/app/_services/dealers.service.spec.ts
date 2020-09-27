import { Dealers, Dealer, AddDealer } from '@model/dealer.model';
import { TestBed, async, inject } from '@angular/core/testing';
import { DealersService } from './dealers.service';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { environment } from 'src/environments/environment';

describe('Service: Dealers', () => {
  let httpMock: HttpTestingController;
  let dealerService: DealersService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DealersService],
      imports: [HttpClientTestingModule],
    });

    httpMock = TestBed.get(HttpTestingController);
    dealerService = TestBed.get(DealersService);
  });

  it('should create', inject([DealersService], (service: DealersService) => {
    expect(service).toBeTruthy();
  }));

  it('be able to retrieve dealers from the API bia GET', () => {
    const dealerArray: Dealers = {
      data: [
        {
          id: 60,
          name: 'Trapped, fast Jaguar engines delievery',
          address: '17 The Drive',
          postalCode: 'TD41 8YT',
          country: 'United Kingdom',
        },
        {
          id: 61,
          name: 'Tomaz Car Engines, Accessories',
          address: 'Krucza 2',
          postalCode: '20-022',
          country: 'Poland',
        },
      ],
      pageNumber: 1,
      pageSize: 10,
      nextPage: 'https://localhost:44354/?pageNumber=2&pageSize=10',
      previousPage: null,
    };

    dealerService.dealers().subscribe((dealers) => {
      expect(dealers.data.length).toBe(2);
      expect(dealers).toEqual(dealerArray);
    });

    const request = httpMock.expectOne(
      `${environment.api}Dealers?PageNumber=1`
    );
    expect(request.request.method).toBe('GET');
    request.flush(dealerArray);
  });

  it('should update dealer', () => {
    const dealer = {
      id: 172,
      name: 'Volkswagen Car Service',
      address: '21 Park Road',
      postalCode: '80 219',
      country: 'USA'
    }
    dealerService.update(dealer).subscribe((dealer: Dealer) => {
      expect(dealer).toBe(dealer);
    });

    const request = httpMock.expectOne(`${environment.api}Dealers`);
    expect(request.request.method).toBe('PUT');
    request.flush(dealer);
  });

  it('should create dealer', () => {
    const dealer = {
      name: 'BMW Car Service',
      address: '44 River Street',
      postalCode: '90 432',
      country: 'USA'
    }
    dealerService.add(dealer).subscribe((dealer: AddDealer) => {
      expect(dealer).toEqual(dealer);
    });

    const request = httpMock.expectOne(`${environment.api}Dealers`);
    expect(request.request.method).toEqual('POST');
    expect(request.request.body).toEqual(dealer);
  });

  it('should delete dealer', () => {
    var dealerId = 172
    dealerService.remove(dealerId).subscribe(() => {
      expect().nothing();
    });

    const request = httpMock.expectOne(`${environment.api}Dealers/${dealerId}`);
    expect(request.request.method).toEqual('DELETE');
  });
});
