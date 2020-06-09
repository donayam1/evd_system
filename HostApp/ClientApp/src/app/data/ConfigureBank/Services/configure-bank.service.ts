import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { ListConfigureBankResponse } from '../Models/configure-bank.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class ConfigureBankService {

  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchConfigureBank():Observable<ListConfigureBankResponse> {
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<ListConfigureBankResponse>(url).subscribe(data => {
        const response = new ListConfigureBankResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });

  }
}
