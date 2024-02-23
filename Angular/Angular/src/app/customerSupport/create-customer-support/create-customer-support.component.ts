import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerSupport } from './../../interface/customerSupport';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerSupportService } from 'src/app/services/customer-support.service';

@Component({
  selector: 'app-create-customer-support',
  templateUrl: './create-customer-support.component.html',
  styleUrls: ['./create-customer-support.component.scss']
})
export class CreateCustomerSupportComponent implements OnInit {

  customerSupportForm! : FormGroup;

  constructor(private fb: FormBuilder,
              private CustomerSupportService: CustomerSupportService,
              private router : Router) { }

  ngOnInit() {
    this.customerSupportForm = this.fb.group({
      responsible: ['', Validators.required],
      customerId:['',Validators.required],
      details: [''],
      createdBy: ['', Validators.required],
      comments: ['']
    });
  }
  submitCreateCustomerSupportForm() {
    if (this.customerSupportForm.valid) {
      const customerSupport: CustomerSupport = this.customerSupportForm.value;
      this.CustomerSupportService.postCustomerSupportData(customerSupport)
        .subscribe(() => {
          console.log('Data added successfully!!!');
        })

    }
  }

}
