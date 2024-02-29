import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserStoryService } from 'src/app/services/user-story.service';
import { UserStory } from 'src/app/interface/userStory';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-create-user-story',
  templateUrl: './create-user-story.component.html',
  styleUrls: ['./create-user-story.component.scss']
})
export class CreateUserStoryComponent implements OnInit {
  userStoryForm! : FormGroup;
  user! : any[];
  public id = localStorage.getItem('id');

  constructor(private fb: FormBuilder, 
              private userStoryService: UserStoryService,
              private authService:AuthService,
              private statusService: StatusService,
              private router : Router) { }

  ngOnInit() {
    this.userStoryForm = this.fb.group({
      responsible: ['', Validators.required],
      storyPoint: ['', Validators.required],
      acceptanceCriteria: ['', Validators.required,
        Validators.minLength(5),
        Validators.maxLength(100),
    ],
      description: ['', Validators.required,
      Validators.minLength(5),
      Validators.maxLength(5),
    ],
      createdBy: [this.id, Validators.required],
      comments: ['']
    });
    this.getResponsible();

  }

  getResponsible(){
    this.authService.getUser().subscribe((data:any[])=>{
      this.user = data;
    })
  }


  submitCreateUserStoryForm() {
    this.userStoryForm.markAllAsTouched();
    if (this.userStoryForm.valid) {
      const userStory: UserStory = this.userStoryForm.value;
      this.userStoryService.postUserStoryData(userStory)
        .subscribe((result:any) => {
          localStorage.setItem("userstory", result.statusId);
          console.log('Data added successfully!!!');
          this.navigateToHomePage();
        })
    }
  }
  navigateToHomePage() {
    this.router.navigate(['/dashboard']); 
  }

}
