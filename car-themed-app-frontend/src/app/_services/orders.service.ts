import { Orders, Order } from '@model/order.model';
import { ErrorService } from '@service/error.service';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  private baseUrl = environment.api + 'Orders';

  constructor(
    private httpClient: HttpClient,
    private errorService: ErrorService
  ) {}

  orders(): Observable<Orders> {
    return this.httpClient
      .get<Orders>(`${this.baseUrl}?PageNumber=1`)
      .pipe(catchError(this.errorService.handleError));
  }

  update(order: Order) {
    return this.httpClient
      .put(this.baseUrl, order)
      .pipe(catchError(this.errorService.handleError));
  }

  remove(id: number) {
    return this.httpClient
    .delete(`${this.baseUrl}/${id}`)
    .pipe(catchError(this.errorService.handleError));
  }
}
