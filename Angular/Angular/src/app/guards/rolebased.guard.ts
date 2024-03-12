import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
 
@Injectable({
  providedIn: 'root'
})
export class RolebasedGuard implements CanActivate{
  constructor(private _auth:AuthService, private route:Router){}
 
  canActivate(
    router: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean
    {
      {
        if(this._auth.isloggedIn())
        {
          if(this._auth.getRole())
          {
           
            return true;
          }
          else
          {
            alert("You are not allowed to access the page");
            this.route.navigate(['']);
            return false;
          }
        }
        else
        {
          this.route.navigate(['login'], {queryParams:{returnurl:state.url}})
          return false;
        }
 
      }
    }
  }
 