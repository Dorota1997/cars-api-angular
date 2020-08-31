/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DealersService } from './dealers.service';

describe('Service: Dealers', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DealersService]
    });
  });

  it('should ...', inject([DealersService], (service: DealersService) => {
    expect(service).toBeTruthy();
  }));
});
