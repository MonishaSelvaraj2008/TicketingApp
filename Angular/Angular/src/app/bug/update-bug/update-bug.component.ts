import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Bug } from 'src/app/interface/bug';
import { AuthService } from 'src/app/services/auth.service';
import { BugService } from 'src/app/services/bug.service';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-update-bug',
  templateUrl: './update-bug.component.html',
  styleUrls: ['./update-bug.component.scss']
})
export class UpdateBugComponent implements OnInit {

  user! : any[];
  status! : any[];
  bugForm!: FormGroup;
  updateBug: any;
  regression: FormControl = new FormControl(false); // For "Yes" option
  noRegression: FormControl = new FormControl(false); // For "No" option

  constructor(private fb: FormBuilder, 
              private route: ActivatedRoute,
              private updateBugService: BugService,
              private statusService: StatusService,
              private authService : AuthService) { }

  ngOnInit() : void{
    this.bugForm = this.fb.group({
      description:  ['', [Validators.required, Validators.minLength(5), Validators.maxLength(500)] ],
      environment:  ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)] ],
      priority: ['' ,  [Validators.required]],
      responsible : ['' ,  [Validators.required]],
      regression: [false, Validators.required],
      fixedId: ['', Validators.required],
      notFixedReason: ['', Validators.required],
      comments: [''],
      createdBy: ['', Validators.required],
    });
    this.getStatus();
    this.getResponsible();
   

    let bugId = this.route.snapshot.params['id'];

    if(bugId)
    {
      this.updateBugService.getBugById(bugId).subscribe(result=>
        {
          this.updateBug = result;
          this.bugForm.patchValue({
            id:result.id,
            statusId: result.statusId,
            responsible: result.responsible,
            priority: result.priority,
            environment: result.environment,
            description: result.description,
            regression : result.regression,
            notFixedReason : result.notFixedReason,
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
    this.statusService.getStatus().subscribe((data:any[])=>{
      this.status = data; 
    })
  }

  submitUpdateBugForm() 
  {
    const bug:Bug = this.bugForm.value;
    this.updateBugService.updateBug(bug).subscribe(response=>
      {
        console.log(response);
        console.log("User Story Updated...");
      })
  }
}
