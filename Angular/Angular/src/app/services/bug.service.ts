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

  postBugData(bug: Bug): Observable<any> {
  
    return this.http.post<any>(this.apiBaseAddress+'api/Bug', bug );
  }
  
  putBugData(Id: any, bug: Bug): Promise<void> {
    return this.http.put<void>(`${this.apiBaseAddress}/api/Bug/${Id}`, bug).toPromise();
  }

  getBugById(Id:number)
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/Bug/${Id}`)
  }
}
