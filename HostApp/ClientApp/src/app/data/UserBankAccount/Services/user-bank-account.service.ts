import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListUserBankAccountResponse } from '../Models/user-bank-account.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class UserBankAccountService {

  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchUserBankAccount():Observable<ListUserBankAccountResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<ListUserBankAccountResponse>(url).subscribe(data =>{
        const response = new ListUserBankAccountResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      })
    })
  }
}
