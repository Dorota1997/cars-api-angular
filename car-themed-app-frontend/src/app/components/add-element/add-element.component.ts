import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-element',
  templateUrl: './add-element.component.html',
  styleUrls: ['./add-element.component.less'],
})
export class AddElementComponent implements OnInit {
  displayForms: boolean = false;
  addDealerFormGroup: FormGroup;

  constructor() {
    this.addDealerFormGroup = new FormGroup({
      dealerName: new FormControl('', [Validators.required]),
      dealerAddress: new FormControl('', [Validators.required]),
      dealerCountry: new FormControl('', [Validators.required]),
      dealerPostalCode: new FormControl('', [Validators.required]),
    });

  ngOnInit() {
  }

  ngOnInit() {}

  public checkError = (controlName: string, errorName: string) => {
    return this.addDealerFormGroup.controls[controlName].hasError(errorName);
  };
}
