import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ListUserBankAccountResponse, CreateUserBankAccoutResponse, NewUserBankAccount, UserBankAccountResponse, UserBankAccount } from '../Models/user-bank-account.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';
import { ObjectStatus } from '../../Shared/Models/newObjectStatus.model';
import { UPDATE } from '@ngrx/store';

@Injectable({
  providedIn: 'root'
})
export class UserBankAccountService {

  private readonly api = "/api/accounting/BankAccounts";

  constructor(private http: HttpClient) { }

  fetchUserBankAccount(userId: string):Observable<ListUserBankAccountResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api + '/list?userId={{userId}}';
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

  saveUserBankAccount(newUserBankAccount: NewUserBankAccount):Observable<CreateUserBankAccoutResponse>{
    //Mock Data
    // let response = new CreateUserBankAccoutResponse();
    // response.status = true;
    // let mes = new Message();
    // mes.messageCode = '30';
    // mes.messageType = 1;
    // mes.systemMessage = 'Working fine!';
    // response.messages.push(mes);

    // let nub = new NewUserBankAccount();
    // nub.ui_id = newUserBankAccount.ui_id;
    // nub.id = '2';
    // nub.bankId = newUserBankAccount.bankId;
    // nub.accountNumber = newUserBankAccount.accountNumber;
    // nub.userId = newUserBankAccount.userId;
    // nub.objectStatus = newUserBankAccount.objectStatus;

    // response.newUserBankAccount = nub;

    // return of(response);

    //Later to be used with the api
    const url = AppConfig.settings.apiServers.authServer + this.api + '/create';
    return new Observable(observer => {
      this.http.post<CreateUserBankAccoutResponse>(url, newUserBankAccount).subscribe(data => {
        const response = new CreateUserBankAccoutResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

  getUserBankAccount(userId: string):Observable<UserBankAccountResponse>{
    // let response = new UserBankAccountResponse();
    // let ub = new UserBankAccount({
    //   id: '2',
    //   bankId: '1',
    //   accountNumber: '10001000001',
    //   userId: userId,
    //   objectStatus: ObjectStatus.UNCHANGED
    // });
    // response.userBa = ub;
    // response.status = true;
    // return of(response);

    const url = AppConfig.settings.apiServers.authServer + this.api + "/list?userId={{userId}}";
    return new Observable(observer => {
      this.http.get<UserBankAccountResponse>(url).subscribe(data => {
        const response = new UserBankAccountResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

  updateUserBankAccount(ub: UserBankAccount):Observable<UserBankAccountResponse>{
    //Mock Data
    let response = new UserBankAccountResponse();
    response.status = true;
    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 1;
    mes.systemMessage = 'working';
    response.messages.push(mes);

    let uB = new UserBankAccount();
    uB.id = ub.id;
    uB.bankId = ub.bankId;
    uB.accountNumber = ub.accountNumber;
    uB.userId = ub.userId;
    uB.status = ub.status;

    response.userBa = uB;

    return of(response);
  }
}
