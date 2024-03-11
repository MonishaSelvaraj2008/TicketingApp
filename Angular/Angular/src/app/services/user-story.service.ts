import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserStory } from '../interface/userStory';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UserStoryService {
  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postUserStoryData(userStory: UserStory): Observable<any>
  {
    return this.http.post<any>(this.apiBaseAddress+'/api/UserStory', userStory);
  }
  

  getUserStoryById(id:number) 
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/UserStory/UserStoryId?UserStoryId=${id}`);
  }

  updateUserStory(updateUserStory:any)
  {
    return this.http.put(`${this.apiBaseAddress}/api/UserStory`, updateUserStory);
  }

  getUserStoryList(id:any)
  {
    return this.http.get<UserStory[]>(`${this.apiBaseAddress}/api/UserStory/CreatedBy?CreatedBy=${id}`);
  }

  getUserStoryHistory(historyId:any)
  {
    return this.http.get<UserStory[]>(`${this.apiBaseAddress}/api/UserStoryHistory/UserStoryId?UserStoryId=${historyId}`);
  }

  searchUserStory(CreatedBy:any, query:string)
  {
    return this.http.get<any[]>(`${this.apiBaseAddress}/api/UserStory?CreatedBy=${CreatedBy}&Search=${query}`);
  }

  getResponsibleData(id:any) 
  {
    return this.http.get<any[]>(`${this.apiBaseAddress}/api/UserStory/Responsible?Responsible=${id}`)
    }
  }

