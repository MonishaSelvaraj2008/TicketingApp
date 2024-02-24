import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
 
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
 
  public firstname = localStorage.getItem("firstname");
 
  constructor(public auth:AuthService) { }
 
  ngOnInit() {
  }
 
  logout()
  {
    this.auth.logout();
  }
 
}