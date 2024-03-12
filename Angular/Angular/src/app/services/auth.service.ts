import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Tokenresponse } from '../interface/TokenResponse';
import * as list from 'postcss/lib/list';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
  httpOptions =
  {
    headers: new HttpHeaders({
      'Content-Type':'application/json'
    })
  }
 
  loginAddress = environment.apiBaseAddress;
 
  constructor(private httpClients : HttpClient, private _route:Router) { }
 
    login(email:string, password:string) : Observable<Tokenresponse>
    {
      return this.httpClients.post<Tokenresponse>(this.loginAddress +'/api/User/Login', { email, password });
    }

    getUser(){
      return this.httpClients.get<any[]>(this.loginAddress+'/api/User');
    }

    getUserById(id:any) : Observable<any>
    {
      return this.httpClients.get<any>(this.loginAddress +`/api/User/UserId?UserId=${id}`)
    }

 
    logout()
    {
      localStorage.removeItem('token');
      localStorage.removeItem('id');
      localStorage.removeItem('firstname');
      localStorage.removeItem('lastname');
      localStorage.removeItem('email');
      this._route.navigate([''])
    }
 
    token(tokenValue: string)
    {
      localStorage.setItem('token', tokenValue)
    }
 
    getToken()
    {
      return localStorage.getItem('token');
    }
 
    isloggedIn() : boolean
    {
      return !!localStorage.getItem('token');
    }
 
    getRole()
    {
      let jwt:any = localStorage.getItem('token');
      let jwtData = jwt.split('.')[1];
      let decodedJwtJsonData = window.atob(jwtData)
      let decodedJwtData = JSON.stringify(decodedJwtJsonData)
      let isUser = decodedJwtData.includes('user');
      if(isUser === true)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
 
