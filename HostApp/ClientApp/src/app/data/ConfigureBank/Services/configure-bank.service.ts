import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable, of } from 'rxjs';
import { ListConfigureBankResponse, Bank } from '../Models/configure-bank.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class ConfigureBankService {

  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchConfigureBank():Observable<ListConfigureBankResponse> {
    
    const configBanklist =  new ListConfigureBankResponse();
    const configureBank = new Bank({
      id: "1" , name: 'Commercial Bank'
    })
     const cb: Bank[] = Array();
     cb.push(configureBank);
     configBanklist.configureBank = cb;
     return of(configBanklist);

    // const url = AppConfig.settings.apiServers.authServer + this.api;
    // return new Observable(observer => {
    //   this.http.get<ListConfigureBankResponse>(url).subscribe(data => {
    //     const response = new ListConfigureBankResponse(data);
    //     observer.next(response);
    //     observer.complete();
    //   }, error => {
    //     observer.error(error);
    //     observer.complete();
    //   });
    // });

  }
}
