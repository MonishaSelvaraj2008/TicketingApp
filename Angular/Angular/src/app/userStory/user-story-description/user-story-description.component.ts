import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Result } from 'postcss';
import { UserStoryService } from 'src/app/services/user-story.service';

@Component({
  selector: 'app-user-story-description',
  templateUrl: './user-story-description.component.html',
  styleUrls: ['./user-story-description.component.scss']
})
export class UserStoryDescriptionComponent implements OnInit {

  details:any;

  constructor(private activedRouting: ActivatedRoute, private userStoryService : UserStoryService) { }

  ngOnInit(): void {
    let storyId = this.activedRouting.snapshot.params["id"];

    storyId && this.userStoryService.getUserStoryById(storyId).subscribe((result)=>
    {
      this.details = result;
    })

  }

}
