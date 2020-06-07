import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VoucherBatchRoutingModule } from './voucher-batch-routing.module';
import { HomeComponent } from './home/home.component';
import { ListvoucherBatchComponent } from './listvoucher-batch/listvoucher-batch.component';
// import { VouchersModule } from '../vouchers/vouchers.module';
// import { VoucherComponent } from './voucher/voucher.component';
import { FormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { VoucherReducers } from '../data/Voucher/Reducers/vouchers.reducers';

@NgModule({
  declarations: [ListvoucherBatchComponent, HomeComponent],//, VoucherComponent
  imports: [
    CommonModule,
    VoucherBatchRoutingModule,
    // VouchersModule,
    FormsModule,
    StoreModule.forFeature("vouchers", VoucherReducers)
  ]
})
export class VoucherBatchModule { }
