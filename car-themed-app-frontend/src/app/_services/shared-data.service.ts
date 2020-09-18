import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedDataService {
  _isDeleted = new BehaviorSubject<boolean>(false);
  _title = new BehaviorSubject<string>('');
  constructor() {}

  setValue(value: boolean) {
    this._isDeleted.next(value);
  }

  setTitle(value: string) {
    this._title.next(value);
  }
}
