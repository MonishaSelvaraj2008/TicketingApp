import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Bug } from '../interface/bug';

@Injectable({
  providedIn: 'root'
})
export class BugService {

  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postBugData(bug: Bug): Promise<void> {
  
    return this.http.post<void>(this.apiBaseAddress+'api/Bug', bug ).toPromise();
  }
  
  putBugData(Id: any, bug: Bug): Promise<void> {
    return this.http.put<void>(`${this.apiBaseAddress}/api/Bug/${Id}`, bug).toPromise();
  }

  getBugById(Id:number)
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/Bug/${Id}`)
  }
}
