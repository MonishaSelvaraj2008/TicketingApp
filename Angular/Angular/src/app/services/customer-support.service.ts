import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CustomerSupport } from '../interface/customerSupport';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerSupportService {

  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postCustomerSupportData(customerSupport: CustomerSupport): Observable<any> {

    return this.http.post<any>(this.apiBaseAddress+'/api/CustomerSupport', customerSupport );
  }

  putCustomerSupportData(Id: any, customerSupport: CustomerSupport): Promise<void> {
    return this.http.put<void>(`${this.apiBaseAddress}/api/CustomerSupport/${Id}`, customerSupport).toPromise();
  }

  getCustomerSupportById(Id:number)
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/CustomerSupport/${Id}`)
  }
}
