import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListVoucherResponse } from '../Models/voucherUpload.services';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class VoucherService {

  private readonly api = "";

  constructor(private http : HttpClient) { }

  fetchVoucher(): Observable<ListVoucherResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api;
    const observer = Observable.create(observer =>{
      this.http.get<ListVoucherResponse>(url).subscribe(data =>{
        const response = new ListVoucherResponse(data);
        observer.next(response);
        observer.complete();
      },error =>{
        observer.error(error);
        observer.complete();
      })
    })
    return observer
  }

}
