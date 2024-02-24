import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Bug } from '../interface/bug';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class BugService {
  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postBugData(bug: Bug): Observable<any> {
  
    return this.http.post<any>(this.apiBaseAddress+'/api/Bug', bug);
  }
  

  getBugById(Id:number)
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/Bug/${Id}`)
  }
 
}

