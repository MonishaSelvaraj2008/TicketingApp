import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserStoryService } from 'src/app/services/user-story.service';
import { AuthService } from 'src/app/services/auth.service';
 
@Component({
  selector: 'app-user-story-list',
  templateUrl: './user-story-list.component.html',
  styleUrls: ['./user-story-list.component.scss']
})
export class UserStoryListComponent implements OnInit {

 
  public values:any[] = [];
  public user:any;
  itemsPerPage = 4;
  currentPage = 1;

  searchTerm:string = '';

  id!:number;
 
  responsible:any;
  public showingUser:any;

  createdby:any;
  query:any;
  userStorySearch:any;
 
 
 
  constructor(private userStoryService: UserStoryService, private authService:AuthService) { }
 
  ngOnInit(): void {
    this.createdby = localStorage.getItem('id');
    this.getUserStoryList();
  }
 
 
  getUserStoryList()
  {
    let id = localStorage.getItem('id');
    this.userStoryService.getUserStoryList(id).subscribe(result=>
      {
        console.log(result);
        this.values = result;
      })
  }

  get filteredValues() 
  {
    return this.values.filter(data =>
      data.responsibleName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      data.description.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      data.status.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
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