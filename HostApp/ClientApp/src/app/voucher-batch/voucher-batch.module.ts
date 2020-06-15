import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VoucherBatchRoutingModule } from './voucher-batch-routing.module';
import { HomeComponent } from './home/home.component';
import { ListvoucherBatchComponent } from './listvoucher-batch/listvoucher-batch.component';
// import { VouchersModule } from '../vouchers/vouchers.module';
// import { VoucherComponent } from './voucher/voucher.component';
import { FileUploadModule } from '../file-upload/file-upload.module';

import { FormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { VoucherReducers } from '../data/Voucher/Reducers/vouchers.reducers';
import { UploadComponent } from './upload/upload.component';
import { PoItemModule } from '../po-item/po-item.module';
import { MessagesModule } from '../messages/messages.module';


@NgModule({
  declarations: [ListvoucherBatchComponent, HomeComponent, UploadComponent], // , VoucherComponent
  imports: [
    CommonModule,
    VoucherBatchRoutingModule,
    // VouchersModule,
    FileUploadModule,
    FormsModule,
    StoreModule.forFeature("vouchers", VoucherReducers),
    PoItemModule,
    MessagesModule
  ]
})
export class VoucherBatchModule { }
