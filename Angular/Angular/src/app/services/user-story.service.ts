import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserStory } from '../interface/userStory';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class UserStoryService {
  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postUserStoryData(userStory: UserStory): Observable<any> {
  
    return this.http.post<any>(this.apiBaseAddress+'/api/UserStory', userStory);
  }
  
  putUserStoryData(Id: any, userStory: UserStory): Promise<void> {
    return this.http.put<void>(`${this.apiBaseAddress}/api/UserStory/${Id}`, userStory).toPromise();
  }

  getUserStoryById(Id:number)
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/UserStory/${Id}`)
  }
 
}

