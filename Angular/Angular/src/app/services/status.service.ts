import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  apiBaseAddress = environment.apiBaseAddress;

  constructor(private http: HttpClient) {}

  getStatus(){
    return this.http.get<any[]>(this.apiBaseAddress+'/api/Status');
  }
}
