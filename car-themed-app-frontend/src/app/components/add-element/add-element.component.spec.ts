/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddElementComponent } from './add-element.component';

describe('AddElementComponent', () => {
  let component: AddElementComponent;
  let fixture: ComponentFixture<AddElementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddElementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
