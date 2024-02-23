import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserStoryService } from 'src/app/services/user-story.service';
import { UserStory } from 'src/app/interface/userStory';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-create-user-story',
  templateUrl: './create-user-story.component.html',
  styleUrls: ['./create-user-story.component.scss']
})
export class CreateUserStoryComponent implements OnInit {
  userStoryForm! : FormGroup;

  constructor(private fb: FormBuilder, 
              private userStoryService: UserStoryService,
              private router : Router) { }

  ngOnInit() {
    this.userStoryForm = this.fb.group({
      responsible: ['', Validators.required],
      storyPoint: ['', Validators.required],
      acceptanceCriteria: [''],
      description: [''],
      createdBy: ['', Validators.required],
      comments: ['']
    });
  }

  submitCreateUserStoryForm() {
    if (this.userStoryForm.valid) {
      const userStory: UserStory = this.userStoryForm.value;
      this.userStoryService.postUserStoryData(userStory)
        .then(() => {
          console.log('Data added successfully!!!');
        })
        
        .finally(() => {
          this.router.navigate(['']);
        });
    }
  }
  
}
