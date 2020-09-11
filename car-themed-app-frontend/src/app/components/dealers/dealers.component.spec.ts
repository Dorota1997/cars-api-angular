import { DealersService } from '@service/dealers.service';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { DealersComponent } from '@components/dealers/dealers.component';
import { HttpClientModule } from '@angular/common/http';
import { ErrorService } from '@service/error.service';

describe('DealersComponent', () => {
  let component: DealersComponent;
  let fixture: ComponentFixture<DealersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [DealersComponent],
      imports: [HttpClientModule],
      providers: [DealersService, ErrorService],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DealersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
