import { IOrders } from '@model/order.model';
import { ErrorService } from '@service/error.service';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private baseUrl = environment.api + 'Orders?PageNumber=1';

  constructor(
    private httpClient: HttpClient,
    private errorService: ErrorService
  ) {}

  orders(): Observable<IOrders> {
    return this.httpClient
      .get<IOrders>(this.baseUrl)
      .pipe(catchError(this.errorService.handleError));
  }

}
