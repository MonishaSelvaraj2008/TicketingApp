import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { UserStoryService } from 'src/app/services/user-story.service';
import { UserStory } from 'src/app/interface/userStory';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { StatusService } from 'src/app/services/status.service';
import { ToastrService } from 'ngx-toastr';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-user-story',
  templateUrl: './create-user-story.component.html',
  styleUrls: ['./create-user-story.component.scss']
})
export class CreateUserStoryComponent implements OnInit {
  userStoryForm!: FormGroup;
  user!: any[];
  public id = localStorage.getItem('id');

  constructor(private fb: FormBuilder,
    private userStoryService: UserStoryService,
    private authService: AuthService,
    private router: Router,
    private toastr:ToastrService) { }

  ngOnInit() {
    this.userStoryForm = this.fb.group({
      responsible: ['', Validators.required],
      storyPoint: ['', Validators.required],
      acceptanceCriteria: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)] ],
      description: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(500)] ],
      createdBy: [this.id, Validators.required],
      comments: ['']
    });
    this.getResponsible();

  }

  getResponsible() {
    this.authService.getUser().subscribe((data: any[]) => {
      this.user = data;
    })
  }

  submitCreateUserStoryForm() 
  {
    this.userStoryForm.markAllAsTouched();
  
    if (this.userStoryForm.valid) 
    {
      const userStory: UserStory = this.userStoryForm.value;
  
      this.userStoryService.postUserStoryData(userStory)
        .subscribe((result: any) => {
           // Display success toast
          this.toastr.success('User Story Ticket Raised Successfully!!!');
          localStorage.setItem("userstory", result.statusId);
          console.log('User Story Ticket Raised successfully!!!');
          this.navigateToHomePage();
        });
    } 
    else 
    {
      // Display a warning toast for invalid data
      this.toastr.error('Please fill the required fields.');
    }
  }
  navigateToHomePage() {
    this.router.navigate(['/dashboard']);
  }

}
