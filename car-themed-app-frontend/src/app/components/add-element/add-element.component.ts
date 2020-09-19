import { SharedDataService } from './../../_services/shared-data.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DealersService } from '@service/dealers.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-element',
  templateUrl: './add-element.component.html',
  styleUrls: ['./add-element.component.less'],
})
export class AddElementComponent implements OnInit {
  displayForms: boolean = false;
  formGroup: FormGroup;
  formsName: string[] = [];
  title: string;

  constructor(private dealerService: DealersService, private sharedDataService: SharedDataService) {
    this.sharedDataService._title.subscribe((res: any) => {
      this.title = res;
    })
  }

  ngOnInit() {}

  public checkError = (data: FormGroup, controlName: string, errorName: string) => {
    return this.formGroup.controls[controlName].hasError(errorName);
  };

  displayForm() {
    switch (this.title) {
      case 'dealers':
        this.formsName = ['name', 'address', 'postalCode', 'country'];
        this.formGroup = new FormGroup({
          name: new FormControl('', [Validators.required]),
          address: new FormControl('', [Validators.required]),
          postalCode: new FormControl('', [Validators.required]),
          country: new FormControl('', [Validators.required])
        });
        break;
      case 'orders':
        this.formsName = ['components', 'orderDate', 'dealerId'];
        this.formGroup = new FormGroup({
          components: new FormControl('', [Validators.required]),
          orderDate: new FormControl('', [Validators.required]),
          dealerId: new FormControl('', [Validators.required])
        });
        break;
    }
    this.displayForms = true;
  }

  hideForm() {
    this.displayForms = false;
  }

  sendData(data: FormGroup) {
    const obj: {[k: string]: any} = {};
    for (var i = 0; i < this.formsName.length; i++) {
      obj[this.formsName[i]] = data.get(this.formsName[i]).value
    }
    console.log(obj);

    this.dealerService.add(obj).subscribe((res: any) => {
      console.log('Dodano nowego dealera');
      console.log(res);
    });
  }
}
