import { TestBed, async, inject } from '@angular/core/testing';
import { ErrorService } from './error.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('Service: Error', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ErrorService],
      imports: [HttpClientTestingModule],
    });
  });

  it('should create', inject([ErrorService], (service: ErrorService) => {
    expect(service).toBeTruthy();
  }));
});
