import { Component, OnInit } from '@angular/core';
import { UserStoryService } from '../services/user-story.service';

@Component({
  selector: 'app-responsible-tickets',
  templateUrl: './responsible-tickets.component.html',
  styleUrls: ['./responsible-tickets.component.scss']
})
export class ResponsibleTicketsComponent implements OnInit {

  userstory:any;
  public count:any;

  constructor(private userStoryTicket : UserStoryService) { }

  ngOnInit(): void {
    let id = localStorage.getItem('id');
    this.userStoryTicket.getResponsibleData(id).subscribe((result:any)=>
    {
      console.log(result);
      this.userstory = result;
      this.count = this.userstory.length;
    })
  }

  click()
  {
    if(!this.userstory.isRead)
    {
      this.count--;
    }
     
  }

}
