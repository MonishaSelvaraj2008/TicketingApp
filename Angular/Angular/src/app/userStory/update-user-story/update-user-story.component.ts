import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserStory } from 'src/app/interface/userStory';
import { Router } from '@angular/router';
import { UserStoryService } from 'src/app/services/user-story.service';

@Component({
  selector: 'app-update-user-story',
  templateUrl: './update-user-story.component.html',
  styleUrls: ['./update-user-story.component.scss']
})
export class UpdateUserStoryComponent implements OnInit {

  userStoryForm!: FormGroup;

  constructor(private fb: FormBuilder, 
              private updateUserStoryService: UserStoryService,
              private router: Router) { }

  ngOnInit() {
    this.userStoryForm = this.fb.group({
      Id: [''], 
      Responsible: ['', Validators.required],
      StoryPoint: ['', Validators.required],
      AcceptanceCriteria: [''],
      Description: [''],
      CreatedBy: ['', Validators.required],
      StatusId: ['', Validators.required],
      Version: ['', Validators.required],
      Comments: ['']
    });
    
  }

  submitUpdateUserStoryForm() {
  //   if (this.userStoryForm.valid) {
  //     const userStory: UserStory = this.userStoryForm.value;
  //     const userId = userStory.Id; 
  //     this.updateUserStoryService.putUserStoryData(userId, userStory)
  //       .then(() => {
  //         console.log('User story updated successfully!!!');
  //         this.router.navigate(['']); 
  //       })
      
  // }
}
}
