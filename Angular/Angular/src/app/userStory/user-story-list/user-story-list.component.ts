import { Component, OnInit } from '@angular/core';
import { UserStoryService } from 'src/app/services/user-story.service';
import { AuthService } from 'src/app/services/auth.service';
import { Tokenresponse } from 'src/app/interface/TokenResponse';
 
@Component({
  selector: 'app-user-story-list',
  templateUrl: './user-story-list.component.html',
  styleUrls: ['./user-story-list.component.scss']
})
export class UserStoryListComponent implements OnInit {
 
  public values:any[] = [];
  public user:any;
 
  responsible:any;
  public showingUser:any;
 
 
 
  constructor(private userStoryService: UserStoryService, private authService:AuthService) { }
 
  ngOnInit(): void {
    this.getUserStoryList();
    this.getAllUsers();
    this.getResponsible();
  }
 
 
  getUserStoryList()
  {
    let id = localStorage.getItem('id');
    this.userStoryService.getUserStoryList(id).subscribe(result=>
      {
        this.responsible = result[1].Responsible;
        this.values = result;
      })
  }
 
  getAllUsers()
  {
    this.authService.getUser().subscribe((result:any[])=>
      {
        console.log(result);
        this.responsible = result[0].firstName;
        this.showingUser = this.responsible;
      })
  }
 
  getResponsible()
  {
    this.authService.getUser().subscribe((data:any[])=>
    {
      this.user = data;
      console.log(this.user);
      this.user = this.showingUser;
    })
  }
 
}