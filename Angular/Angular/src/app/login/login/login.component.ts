import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/interface/user';
import { AuthService } from 'src/app/services/auth.service';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
 
  constructor(private auth:AuthService, 
              private formBuilder:FormBuilder, 
              private route:Router,
              private toast:ToastrService) { }
 
  login!:FormGroup;
 
  ngOnInit(): void {
    this.login = this.formBuilder.group({
 
      email:['', [Validators.required,
        Validators.pattern("^[a-z]+[.]+[a-z]+@aspiresys.com")],
        Validators.minLength(19),
        Validators.maxLength(33)],
 
      password:['', [Validators.required, Validators.minLength(8)]]
    })
  }


  userLogin()
  {
    this.auth.login(this.login.value.email, this.login.value.password).subscribe(response=>
    {
      
      localStorage.setItem('token', response.accessToken);
      localStorage.setItem('id', response.id);
      localStorage.setItem('firstname', response.firstName);
      localStorage.setItem('lastname', response.lastName);
      localStorage.setItem('email', response.email);
     
      this.auth.getRole();
     
      if(this.auth.getRole())
      {
        this.toast.success("Login Successfully...", this.login.value.email);
        this.route.navigate(['dashboard']);
        console.log('Login successful. Token:', JSON.stringify(response.accessToken));
      }
      else
      {
        this.handleLoginError();
      }
    },
    error => {
      console.error('Error during login:', error);
      this.handleLoginError();
    });
  }

  private handleLoginError() {
    this.toast.error("Invalid Credentials", "Error");
    this.route.navigate(['login']);
  }
}
 