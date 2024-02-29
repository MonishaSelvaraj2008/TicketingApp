import { Component, OnInit } from '@angular/core';
import { UserStoryService } from '../services/user-story.service';
import { AuthService } from '../services/auth.service';
import { Tokenresponse } from '../interface/TokenResponse';

@Component({
  selector: 'app-user-story-list',
  templateUrl: './user-story-list.component.html',
  styleUrls: ['./user-story-list.component.scss']
})
export class UserStoryListComponent implements OnInit {

  public values:any[] = [];
  public user:any;
  id:any;
  responsible:any;
  showingUser:any;

  

  constructor(private userStoryService: UserStoryService, private authService:AuthService) { }

  ngOnInit(): void {
    this.getUserStoryList();
    this.getAllUsers();
    this.getUserById();
  }


  getUserStoryList()
  {
    let id = localStorage.getItem('id');
    this.userStoryService.getUserStoryList(id).subscribe(result=>
      {
        this.responsible = result[1].responsible;
        this.values = result;
      })
  }

  getAllUsers()
  {
    this.authService.getUser().subscribe((result:any[])=>
      {
        console.log(result);
        this.responsible = result[0].firstName;
      })
  }

  getUserById()
  {
    this.authService.getUserById(this.id).subscribe((result)=>
      {
        this.showingUser = result.firstName;
        console.log(this.showingUser);
      })
  }

}
