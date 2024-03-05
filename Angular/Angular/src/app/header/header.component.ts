import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ToastrService } from 'ngx-toastr';
 
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public firstname:any;
  public lastname:any;

  constructor(public auth:AuthService,
    private toast:ToastrService) { }
 
  ngOnInit() {
    this.getName();
    this.setTimer();
  }
 
  logout()
  {
    this.toast.success("Logout Successfully", "Success");
    this.auth.logout();
  }

  getName()
  {
    this.firstname = localStorage.getItem("firstname");
    this.lastname = localStorage.getItem("lastname");
  }

  setTimer()
  {
    setInterval(()=>
    {
      this.getName();
    },500)
  }
 
}