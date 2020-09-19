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
  addOrderFormGroup: FormGroup;
  dealer: string[] = ['name', 'address', 'postalCode', 'country'];
  constructor(public fb: FormBuilder, private dealerService: DealersService) {
    this.addDealerFormGroup = new FormGroup({
      name: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      postalCode: new FormControl('', [Validators.required]),
      country: new FormControl('', [Validators.required])
    });

  ngOnInit() {
  }

  ngOnInit() {}

  public checkError = (controlName: string, errorName: string) => {
    return this.addDealerFormGroup.controls[controlName].hasError(errorName);
  };

  displayForm() {
    this.displayForms = true;
  }

  hideForm() {
    this.displayForms = false;
  }
  sendDealerData() {
    const obj: {[k: string]: IAddDealer} = {};
    for (var i = 0; i < this.dealer.length; i++) {
      obj[this.dealer[i]] = this.addDealerFormGroup.get(this.dealer[i]).value
    }
    console.log(obj);

    this.dealerService.add(obj).subscribe((res: any) => {
      console.log('Dodano nowego dealera');
      console.log(res);
    });
  }
}
