import { Component, OnInit } from '@angular/core';
import { ListVoucherResponse } from 'src/app/data/Voucher/Models/voucherUpload.services';
import { VoucherService } from 'src/app/data/Voucher/Services/voucher.service';

@Component({
  selector: 'app-list-vouchers',
  templateUrl: './list-vouchers.component.html',
  styleUrls: ['./list-vouchers.component.css']
})
export class ListVouchersComponent implements OnInit {
 
  response: ListVoucherResponse;

  constructor(private voucherService: VoucherService) {
    this.response = new ListVoucherResponse();
   }

  ngOnInit() {
    this.voucherService.fetchVoucher().subscribe((response: ListVoucherResponse)=>{
      this.response = response;
      console.log(this.response);
    })
  }

}
