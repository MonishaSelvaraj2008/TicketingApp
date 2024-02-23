import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CustomerSupport } from '../interface/customerSupport';

@Injectable({
  providedIn: 'root'
})
export class CustomerSupportService {

  apiBaseAddress = environment.apiBaseAddress;


  constructor(private http: HttpClient) {}

  postCustomerSupportData(customerSupport: CustomerSupport): Promise<void> {

    return this.http.post<void>(this.apiBaseAddress+'/api/CustomerSupport', customerSupport ).toPromise();
  }

  putCustomerSupportData(Id: any, customerSupport: CustomerSupport): Promise<void> {
    return this.http.put<void>(`${this.apiBaseAddress}/api/CustomerSupport/${Id}`, customerSupport).toPromise();
  }

  getCustomerSupportById(Id:number)
  {
    return this.http.get<any>(`${this.apiBaseAddress}/api/CustomerSupport/${Id}`)
  }
}
