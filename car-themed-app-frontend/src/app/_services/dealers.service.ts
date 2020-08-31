import { IDealers } from '@model/dealer.model';
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
  private baseUrl = `${environment.api}servers`;

  constructor(
    private httpClient: HttpClient,
    private errorService: ErrorService
  ) {}

  dealers(): Observable<IDealers> {
    return this.httpClient
      .get<IDealers>(this.baseUrl)
      .pipe(catchError(this.errorService.handleError));
  }
}
