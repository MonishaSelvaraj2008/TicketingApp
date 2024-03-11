import { Component, OnInit } from '@angular/core';
import { UserStoryService } from '../services/user-story.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateUserStoryComponent } from '../userStory/create-user-story/create-user-story.component';
import { UserStoryListComponent } from '../userStory/user-story-list/user-story-list.component';
import { ResponsibleTicketsComponent } from '../responsible-tickets/responsible-tickets.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  userStoryData:any;
  public firstname = localStorage.getItem('firstname');
  public lastname = localStorage.getItem('lastname');

  public count:any;
  
  isDarkMode: boolean | undefined;

  


  constructor(private userStoryService : UserStoryService,
    public matDialog:MatDialog) { }

  ngOnInit(): void {
    let userStoryResponsibleData = localStorage.getItem('id');

    this.userStoryService.getResponsibleData(userStoryResponsibleData).subscribe((result:any)=>
    {
      
      this.userStoryData = result;
      this.count = this.userStoryData.length;
      console.log(this.userStoryData);
    })
  }

  toggleMode() {
    this.isDarkMode = !this.isDarkMode;
  }

  getBackgroundImage(): string {
    return this.isDarkMode ? 'none' : 'url("https://cdn.dribbble.com/users/4781516/screenshots/10796279/media/04eb24250e23400dc0162080a231b70c.gif")';
  }

  openUserStory() 
  {
    const dialogRef = this.matDialog.open(CreateUserStoryComponent,
      {
        width: '700px',
        height: '500px'
      });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openDialog() {
    this.matDialog.open(ResponsibleTicketsComponent);
  }
}
