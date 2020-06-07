import { Component, OnInit, Input } from '@angular/core';
import { Voucher } from '../../data/Voucher/Models/voucherUpload.models';
import { State, Store } from '@ngrx/store';
import { VoucherState } from 'src/app/data/Voucher/Reducers/vouchers.reducers';
import { SelectCurrentVoucher } from '../../data/Voucher/Reducers/vouchers.reducers';

@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.css']
})
export class VoucherComponent implements OnInit {

  // @Input()
  voucher: Voucher;

  constructor(private store:Store<VoucherState>) {
    this.voucher = new Voucher();

  }

  ngOnInit() {
    this.store.select(SelectCurrentVoucher).subscribe(x => {
      if (x != null) {
        this.voucher = x;
      }
    });
    // const v = SelectCurrentVoucher(this.state.value);
    // if (v != null) {
    //   this.voucher = v;
    // }
  }

}
