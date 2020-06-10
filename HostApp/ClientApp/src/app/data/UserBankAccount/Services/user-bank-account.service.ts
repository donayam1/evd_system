import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ListUserBankAccountResponse, CreateUserBankAccoutResponse, NewUserBankAccount } from '../Models/user-bank-account.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';

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

  createUserBankAccount(newUserBankAccount: NewUserBankAccount):Observable<CreateUserBankAccoutResponse>{
    //Mock Data
    let response = new CreateUserBankAccoutResponse();
    response.status = true;
    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 1;
    mes.systemMessage = 'Working fine!';
    response.messages.push(mes);

    let nub = new NewUserBankAccount();
    nub.ui_id = newUserBankAccount.ui_id;
    nub.id = '2';
    nub.bankId = newUserBankAccount.bankId;
    nub.accountNumber = newUserBankAccount.accountNumber;
    nub.userId = newUserBankAccount.userId;
    nub.objectStatus = newUserBankAccount.objectStatus;

    response.newUserBankAccount = nub;

    return of(response);
    
    //Later to be used with the api
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.post<CreateUserBankAccoutResponse>(url, newUserBankAccount).subscribe(data => {
        const response = new CreateUserBankAccoutResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      })
    })
  }
}
