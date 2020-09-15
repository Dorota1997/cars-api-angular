import { IDealers, IDealer } from '@model/dealer.model';
import { ErrorService } from '@service/error.service';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class DealersService {
  private baseUrl = environment.api + 'Dealers';

  constructor(
    private httpClient: HttpClient,
    private errorService: ErrorService
  ) {}

  dealers(): Observable<IDealers> {
    return this.httpClient
      .get<IDealers>(`${this.baseUrl}?PageNumber=1`)
      .pipe(catchError(this.errorService.handleError));
  }

  get(id: number): Observable<IDealer> {
    return this.httpClient
      .get<IDealer>(`${this.baseUrl}/${id}`)
      .pipe(catchError(this.errorService.handleError));
  }

  update(dealer: IDealer) {
    return this.httpClient
      .put(`${this.baseUrl}`, dealer)
      .pipe(catchError(this.errorService.handleError));
  }

  remove(id: number) {
    return this.httpClient
    .delete(`${this.baseUrl}/${id}`)
    .pipe(catchError(this.errorService.handleError));
  }
}
