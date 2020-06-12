import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ListConfigureBankResponse, NewBank, CreateBankResponse, BankResponse, Bank } from '../Models/configure-bank.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class ConfigureBankService {

  private readonly api = "/api/accounting/banks";

  constructor(private http: HttpClient) { }
  

  fetchConfigureBank():Observable<ListConfigureBankResponse> {

    const url = AppConfig.settings.apiServers.authServer + this.api + "/list";
    return new Observable(observer => {
      this.http.get<ListConfigureBankResponse>(url).subscribe(data => {
        const response = new ListConfigureBankResponse(data);
        console.log(response)
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });

  }

  createBank(newBank: NewBank[]):Observable<CreateBankResponse>{
    //Mock Data
    let response = new CreateBankResponse();
    response.status = true;

    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 1;
    mes.systemMessage = 'working';
    response.messages.push(mes);

    response.banks = newBank;

    return of(response);

    //Later to be used with the api
    // const url = AppConfig.settings.apiServers.authServer + this.api;
    // return new Observable(observer => {
    //   this.http.post<CreateBankResponse>(url, newBank).subscribe(data => {
    //     const response = new CreateBankResponse(data);
    //     observer.next();
    //     observer.complete();
    //   }, error => {
    //     observer.error(error);
    //     observer.complete();
    //   });
    // });
  }

  getBank(id: string): Observable<BankResponse>{
    let response: BankResponse = new BankResponse();
    let bank = new Bank({
      id: '1',
      name: 'Commercial bank of Ethiopia'
    });
    response.bank = bank;
    response.status = true;
    return of(response);
  }

  updateBank(bank: Bank):Observable<BankResponse>{
    //Mock data
    let res: BankResponse = new BankResponse();
    res.bank = bank;
    res.status = true;
    return of (res);

    //Later to be used with the api
    //return this.http.post<BankResponse>(this.api, bank);
  }
}
