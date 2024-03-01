import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
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
regression: FormControl = new FormControl(false); // For "Yes" option
noRegression: FormControl = new FormControl(false); // For "No" option

  constructor(private fb: FormBuilder, 
              private bugService: BugService,
              private router : Router,
              private authService : AuthService) { }

  ngOnInit() {
    this.bugForm = this.fb.group({
      description:  ['', [Validators.required, Validators.minLength(5), Validators.maxLength(500)] ],
      environment:  ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)] ],
      priority: ['' ,  [Validators.required]],
      responsible : ['' ,  [Validators.required]],
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
