import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListVoucherBatchResponse, PeekVoucherResponse } from '../Models/voucherBatch.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { ResponseBase } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class VoucherBatchService {

  private readonly api = "/api/vouchers/VoucherBatchs";

  constructor(private http: HttpClient) { }

  fetchVoucherBatch(): Observable<ListVoucherBatchResponse> {
    const url = AppConfig.settings.apiServers.authServer + this.api + "?batchStatus=20";
    return new Observable(observer => {
      this.http.get<ListVoucherBatchResponse>(url).subscribe(data => {
        const response = new ListVoucherBatchResponse(data);
        console.log("response");
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });

  }

  activateVoucherBatch(id: String): Observable<ResponseBase> {
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      const obj = {
        id: id
      };
      this.http.post<ResponseBase>(url, obj).subscribe(data => {
        const response = new ResponseBase(data);
        console.log(response);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });

  }

  takeSample(batchId: String): Observable<PeekVoucherResponse> {
    const theapi = "/api/purchaseOrders/purchaseOrder";
    const url = AppConfig.settings.apiServers.authServer + theapi;
    return new Observable(observer => {
      const obj = {
        batchId: batchId
      };
      this.http.post<PeekVoucherResponse>(url, obj).subscribe(data => {
        const response = new PeekVoucherResponse(data);
        console.log(response);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

}
