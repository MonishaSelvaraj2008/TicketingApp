import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserStory } from '../interface/userStory';
import { environment } from 'src/environments/environment';
import { UpdateUserStory } from '../interface/updateuserStory';



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
<<<<<<< HEAD
    return this.http.get<UserStory[]>(`https://localhost:5001/api/UserStory?CreatedBy=${id}`)
=======
    return this.http.get<UserStory[]>(`https://localhost:5001/api/UserStory?CreatedBy=${id}`);
>>>>>>> 3b422124e711cdf328d5764acd36faa61acca665
  }
}

