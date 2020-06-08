import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ListVoucherResponse, Voucher, CheckOutVoucherResponse, 
  ListVouchersRequest } from '../Models/voucherUpload.models';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class VoucherService {

  private readonly api = "/api/vouchers/vouchers";

  constructor(private http: HttpClient) { }

  fetchVoucher(request?: ListVouchersRequest): Observable<ListVoucherResponse> {
    // const ListVouchResponse: ListVoucherResponse = new ListVoucherResponse();
    // const voucher = new Voucher({
    //   serialNumber: 1209343,
    //   denomination: 10,
    //   stopDate: "6/2/2020 ",
    //   voucherStatus: "Active"
    // });
    // const vouch : Voucher[]= Array();
    // vouch.push(voucher);
    // ListVouchResponse.vouchers = vouch;
    // return of(ListVouchResponse)
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<ListVoucherResponse>(url).subscribe(data => {
        const response = new ListVoucherResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }
  checkOutVoucher(id: string): Observable<CheckOutVoucherResponse> {
    const theapi = "/api/vouchers/VoucherCheckOut";
    const req = {
      id: id
    };
    const url = AppConfig.settings.apiServers.authServer + theapi;
    return new Observable(observer => {
      this.http.post<CheckOutVoucherResponse>(url, req).subscribe(data => {
        const response = new CheckOutVoucherResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

}
