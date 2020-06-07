import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListVoucherBatchResponse } from '../Models/voucherBatch.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class VoucherBatchService {

  private readonly api = "/api/vouchers/VoucherBatchs"

  constructor(private http: HttpClient) { }

  fetchVoucherBatch(): Observable<ListVoucherBatchResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api ;
    return new Observable(observer =>{
      this.http.get<ListVoucherBatchResponse>(url).subscribe(data =>{
        const response = new ListVoucherBatchResponse(data);
        console.log("response");
        observer.next(response);
        observer.complete();
      }, error =>{
        observer.error(error);
        observer.complete();
      })
    })

  }

}
