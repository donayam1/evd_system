import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ListDepositResponse, NewMoneyDeposit, CreateMoneyDepositResponse } from '../Models/money-deposit.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class MoneyDepositService {

  private readonly api = "/api/accounting/MoneyDeposit";

  constructor(private http: HttpClient) { }

  fetchMoneyDeposit():Observable<ListDepositResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api + '/list';
    return new Observable(observer => {
      this.http.get<ListDepositResponse>(url).subscribe(data => {
        const resonse = new ListDepositResponse(data);
        observer.next(resonse);
        observer.complete();
      }, error =>{
        observer.error(error);
        observer.complete();
      });
    });
  }

  createMoneyDeposit(nMD: NewMoneyDeposit):Observable<CreateMoneyDepositResponse>{
    //Mock Data
    let response = new CreateMoneyDepositResponse();
    response.status = true;

    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 1;
    mes.systemMessage = 'working';
    response.messages.push(mes);

    nMD.id = '1';
    nMD.ui_id = '-1';
    response.newMoneyDeposit = nMD;
    
    return of(response);
    //Later to be used with the api
    // const url = AppConfig.settings.apiServers.authServer + this.api;
    // return new Observable(observer => {
    //   this.http.post<CreateMoneyDepositResponse>(url, nMD).subscribe(data => {
    //     const response = new CreateMoneyDepositResponse(data);
    //     observer.next(response);
    //     observer.complete();
    //   });
    // });
  }
}
