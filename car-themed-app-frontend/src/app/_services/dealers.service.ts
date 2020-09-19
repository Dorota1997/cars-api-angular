import { Dealers, Dealer } from '@model/dealer.model';
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

  dealers(): Observable<Dealers> {
    return this.httpClient
      .get<Dealers>(`${this.baseUrl}?PageNumber=1`)
      .pipe(catchError(this.errorService.handleError));
  }

  get(id: number): Observable<Dealer> {
    return this.httpClient
      .get<Dealer>(`${this.baseUrl}/${id}`)
      .pipe(catchError(this.errorService.handleError));
  }

  update(dealer: Dealer) {
    return this.httpClient
      .put(`${this.baseUrl}`, dealer)
      .pipe(catchError(this.errorService.handleError));
  }

  remove(id: number) {
    return this.httpClient
    .delete(`${this.baseUrl}/${id}`)
    .pipe(catchError(this.errorService.handleError));
  }

  add(dealer) {
    return this.httpClient
    .post(`${this.baseUrl}`, dealer)
    .pipe(catchError(this.errorService.handleError));
  }
}
