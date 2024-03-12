import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerSupport } from './../../interface/customerSupport';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { CustomerSupportService } from 'src/app/services/customer-support.service';
 
@Component({
  selector: 'app-create-customer-support',
  templateUrl: './create-customer-support.component.html',
  styleUrls: ['./create-customer-support.component.scss']
})
export class CreateCustomerSupportComponent implements OnInit {
  public id = localStorage.getItem('id');
  user! : any[];
  customerSupportForm! : FormGroup;

  constructor(private fb: FormBuilder,
              private CustomerSupportService: CustomerSupportService,
              private authService : AuthService,
              private router : Router) { }
 
  ngOnInit() {
    this.customerSupportForm = this.fb.group({
      responsible: ['', Validators.required],
      customerId:['',Validators.required],
      details: [''],
      createdBy: [this.id, Validators.required],
      comments: ['']
    });
    this.getResponsible();
  }

  getResponsible(){
    this.authService.getUser().subscribe((data:any[])=>{
      this.user = data;
    })
  }

  submitCreateCustomerSupportForm() {
    if (this.customerSupportForm.valid) {
      const customerSupport: CustomerSupport = this.customerSupportForm.value;
      this.CustomerSupportService.postCustomerSupportData(customerSupport)
        .subscribe(() => {
          console.log('Data added successfully!!!');
          this.navigateToHomePage();
        })
    }
  }
  navigateToHomePage() {
    this.router.navigate(['/dashboard']); 
  }

}
