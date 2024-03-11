import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { UserStoryService } from '../services/user-story.service';
import { DashboardComponent } from '../dashboard/dashboard.component';
 
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public firstname:any;
  public lastname:any;

  userStoryData:any;
  notificationCount: number = 0;


  constructor(public auth:AuthService,
    private toast:ToastrService,
    private userStoryService : UserStoryService) { }

  ngOnInit() {
    this.getName();
    this.setTimer();
    let id = localStorage.getItem('id');
    this.userStoryService.getResponsibleData(id).subscribe((result:any)=>
    {
      this.userStoryData = result;
      this.notificationCount = this.userStoryData.length;
      this.userStoryData.forEach((item:any) => {
        if(!item.isRead)
        {
          item.isRead = true;
          this.notificationCount -= 1;
        }
        
      });
    })
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