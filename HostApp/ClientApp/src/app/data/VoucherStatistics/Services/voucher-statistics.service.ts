import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VoucherStatisticsResponse } from '../Models/voucher-statistics.model';
import { Observable } from 'rxjs';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class VoucherStatisticsService {
  
 private readonly api = "/api/vouchers/vouchers/Statistics";

  constructor(private http: HttpClient) { }

  fetchVoucherStatistics():Observable<VoucherStatisticsResponse> {
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<VoucherStatisticsResponse>(url).subscribe(data =>{
        const response = new VoucherStatisticsResponse(data);
        observer.next(response);
        observer.complete();
      },error =>{
        observer.error(error);
        observer.complete();
      })
    })
  }
}
