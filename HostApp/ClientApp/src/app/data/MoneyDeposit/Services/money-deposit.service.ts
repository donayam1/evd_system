import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListDepositResponse } from '../Models/money-deposit.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class MoneyDepositService {

  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchMoneyDeposit():Observable<ListDepositResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api;
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
}
