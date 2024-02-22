import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Bug } from 'src/app/interface/bug';
import { BugService } from 'src/app/services/bug.service';

@Component({
  selector: 'app-create-bug',
  templateUrl: './create-bug.component.html',
  styleUrls: ['./create-bug.component.scss']
})
export class CreateBugComponent implements OnInit {

  bugForm! : FormGroup;

  constructor(private fb: FormBuilder, 
              private bugService: BugService,
              private router : Router) { }

  ngOnInit() {
    this.bugForm = this.fb.group({
      Description: ['', Validators.required],
      Environment: ['', Validators.required],
      Priority: [''],
      Responsible : [''],
      Regression: [false, Validators.required],
      FixedId: ['', Validators.required],
      NotFixedReason: ['', Validators.required], 
      CreatedBy: ['', Validators.required], 
      StatusId: ['', Validators.required],
      Version: ['', Validators.required],
      Comments: ['']
    });
  }
  submitCreateBugForm() {
    if (this.bugForm.valid) {
      const bug: Bug = this.bugForm.value;
      this.bugService.postBugData(bug)
        .then(() => {
          console.log('Data added successfully!!!');
        })
        
        .finally(() => {
          this.router.navigate(['']);
        });
    }
  }
  
}
