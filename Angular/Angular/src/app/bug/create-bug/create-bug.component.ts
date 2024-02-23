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
      description: ['', Validators.required],
      environment: ['', Validators.required],
      priority: [''],
      responsible : [''],
      regression: [false, Validators.required],
      fixedId: ['', Validators.required],
      notFixedReason: ['', Validators.required],
      comments: [''],
      createdBy: ['', Validators.required],
      // StatusId: ['', Validators.required],
      // Version: ['', Validators.required],
      
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
