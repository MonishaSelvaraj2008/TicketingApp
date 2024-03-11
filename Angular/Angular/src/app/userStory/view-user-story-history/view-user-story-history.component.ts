import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { UserStoryService } from 'src/app/services/user-story.service';

@Component({
  selector: 'app-view-user-story-history',
  templateUrl: './view-user-story-history.component.html',
  styleUrls: ['./view-user-story-history.component.scss']
})
export class ViewUserStoryHistoryComponent implements OnInit {

  values:any;

  itemsPerPage = 10;
  currentPage = 1;

  constructor(private userStoryService : UserStoryService, private activatedRoute : ActivatedRoute,
    private route:Router) { }

  ngOnInit(): void {

    let userStoryId = this.activatedRoute.snapshot.params["id"];

    userStoryId && this.userStoryService.getUserStoryHistory(userStoryId).subscribe((result)=>
    {
      console.log(result);
      this.values = result;
    })
  }

  getPages(): number[] {
    const pageCount = Math.ceil(this.values.length / this.itemsPerPage);
    return Array.from({ length: pageCount }, (_, i) => i + 1);
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.getPages().length) {
      this.currentPage = page;
    }
  }

  currentPageStartIndex(): number {
    return (this.currentPage - 1) * this.itemsPerPage;
  }

  currentPageEndIndex(): number {
    const endIndex = this.currentPage * this.itemsPerPage;
    return endIndex > this.values.length ? this.values.length : endIndex;
  }

}
