import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VoucherBatchRoutingModule } from './voucher-batch-routing.module';
import { HomeComponent } from './home/home.component';
import { ListvoucherBatchComponent } from './listvoucher-batch/listvoucher-batch.component';

@NgModule({
  declarations: [ListvoucherBatchComponent, HomeComponent],
  imports: [
    CommonModule,
    VoucherBatchRoutingModule,
  ]
})
export class VoucherBatchModule { }
