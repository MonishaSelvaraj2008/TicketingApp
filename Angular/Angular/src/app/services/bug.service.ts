import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Bug } from '../interface/bug';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BugService {

  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postBugData(bug: Bug): Observable<any>
  {
    return this.http.post<any>(this.apiBaseAddress+'/api/Bug', bug);
  }
  

  getBugById(id:number) 
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/Bug/BugId?BugId=${id}`);
  }

  updateBug(updateBug:any)
  {
    return this.http.put(`${this.apiBaseAddress}/api/Bug`, updateBug);
  }

  getBugList(id:any)
  {
    return this.http.get<Bug[]>(`https://localhost:5001/api/Bug?CreatedBy=${id}`)
  }
}

