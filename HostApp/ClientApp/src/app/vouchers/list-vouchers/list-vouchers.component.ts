import { Component, OnInit } from '@angular/core';
import { ListVoucherResponse } from '../../data/Voucher/Models/voucherUpload.models';
import { VoucherService } from 'src/app/data/Voucher/Services/voucher.service';
import { Voucher } from '../../data/Voucher/Models/voucherUpload.models';
import { Store } from '@ngrx/store';
import { VoucherState } from 'src/app/data/Voucher/Reducers/vouchers.reducers';
import { VoucherSelectedAction } from '../../data/Voucher/Actions/vouchers.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-vouchers',
  templateUrl: './list-vouchers.component.html',
  styleUrls: ['./list-vouchers.component.css']
})
export class ListVouchersComponent implements OnInit {

  response: ListVoucherResponse;

  constructor(private voucherService: VoucherService,
    private store: Store<VoucherState>,
    private router:Router) {
    this.response = new ListVoucherResponse();
  }

  ngOnInit() {
    this.voucherService.fetchVoucher().subscribe((response: ListVoucherResponse) => {
      this.response = response;
      console.log(this.response);
    });
  }
  checkOutVoucher(voucher: Voucher) {
    this.voucherService.checkOutVoucher(voucher.id).subscribe(x => {
      if (x.status === true) {
        const action = new VoucherSelectedAction(x.voucher);
        this.store.dispatch(action);
        // this.router.navigateByUrl('../view',);
      }
    });

  }

}
