import { Component, OnInit } from '@angular/core';
import { ListVoucherResponse } from 'src/app/data/Voucher/Models/voucherUpload.services';
import { VoucherService } from 'src/app/data/Voucher/Services/voucher.service';

@Component({
  selector: 'app-list-vouchers',
  templateUrl: './list-vouchers.component.html',
  styleUrls: ['./list-vouchers.component.css']
})
export class ListVouchersComponent implements OnInit {

  vouchers: ListVoucherResponse;

  constructor(private voucherService: VoucherService) {
    this.vouchers = new ListVoucherResponse();
   }

  ngOnInit() {
    this.voucherService.fetchVoucher().subscribe((response: ListVoucherResponse)=>{
      this.vouchers = response;
      console.log(this.vouchers);
    })
  }

}
