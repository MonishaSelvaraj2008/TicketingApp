import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Bug } from 'src/app/interface/bug';
import { BugService } from 'src/app/services/bug.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-create-bug',
  templateUrl: './create-bug.component.html',
  styleUrls: ['./create-bug.component.scss']
})
export class CreateBugComponent implements OnInit {

public id = localStorage.getItem('id');
bugForm! : FormGroup;
user! : any[];

  constructor(private fb: FormBuilder, 
              private bugService: BugService,
              private router : Router,
              private authService : AuthService) { }

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
      createdBy: [this.id, Validators.required],
    });
    this.getResponsible();
  }

  getResponsible(){
    this.authService.getUser().subscribe((data:any[])=>{
      this.user = data;
    })
  }

  submitCreateBugForm() {
    if (this.bugForm.valid) {
      const bug: Bug = this.bugForm.value;
      this.bugService.postBugData(bug)
        .subscribe(() => {
          console.log('Data added successfully!!!');
          this.navigateToHomePage();
        })
    }
  }
  navigateToHomePage() {
    this.router.navigate(['/dashboard']); 
  }

}
