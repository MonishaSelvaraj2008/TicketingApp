import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserStory } from 'src/app/interface/userStory';
import { UserStoryService } from 'src/app/services/user-story.service';
import { UpdateUserStory } from 'src/app/interface/updateuserStory';
import { AuthService } from 'src/app/services/auth.service';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-update-user-story',
  templateUrl: './update-user-story.component.html',
  styleUrls: ['./update-user-story.component.scss']
})
export class UpdateUserStoryComponent implements OnInit {

  user! : any[];
  status! : any[];
  userStoryForm!: FormGroup;
  updateUserStory: any;


  constructor(private fb: FormBuilder, 
              private route: ActivatedRoute,
              private updateUserStoryService: UserStoryService,
              private statusService: StatusService,
              private authService : AuthService) { }

  ngOnInit() : void{
    this.userStoryForm = this.fb.group({
      id : [''],
      statusId: ['', Validators.required],
      responsible: ['', Validators.required],
      storyPoint: ['', Validators.required],
       acceptanceCriteria: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)] ],
      description: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(500)] ],
      comments: [''],
      createdBy: ['', Validators.required],
    });
    this.getStatus();
    this.getResponsible();
   

    let userStoryId = this.route.snapshot.params['id'];

    if(userStoryId)
    {
      this.updateUserStoryService.getUserStoryById(userStoryId).subscribe(result=>
        {
          this.updateUserStory = result;
          this.userStoryForm.patchValue({
            id:result.id,
            statusId: result.statusId,
            responsible: result.responsible,
            storyPoint: result.storyPoint,
            acceptanceCriteria: result.acceptanceCriteria,
            description: result.description,
            comments: result.comments,
            createdBy: result.createdBy
            
          });
        })
    }

  }
  getResponsible(){
    this.authService.getUser().subscribe((data:any[])=>{
      this.user = data;
    })
  }

  getStatus(){
    this.statusService.getStatus().subscribe((datas:any[])=>{
      this.status = datas; 
    })
  }

  submitUpdateUserStoryForm() 
  {
    const userStory:UserStory = this.userStoryForm.value;
    this.updateUserStoryService.updateUserStory(userStory).subscribe(response=>
      {
        console.log(response);
        console.log("User Story Updated...");
      })
  }
}
