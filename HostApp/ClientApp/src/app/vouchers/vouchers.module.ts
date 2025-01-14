import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VouchersRoutingModule } from './vouchers-routing.module';
// import { UploadComponent } fro../voucher-batch/upload/upload.componentent';
// import { FileUploadModule } from '../file-upload/file-upload.module';
import { HomeComponent } from './home/home.component';
import { ListVouchersComponent } from './list-vouchers/list-vouchers.component';
import { MessagesModule } from '../messages/messages.module';
import { FormsModule } from '@angular/forms';
import { VoucherComponent } from './voucher/voucher.component';
import { StoreModule } from '@ngrx/store';
import { VoucherReducers } from '../data/Voucher/Reducers/vouchers.reducers';
// import { PoItemModule } from '../po-item/po-item.module';


@NgModule({
  declarations: [ HomeComponent, ListVouchersComponent,VoucherComponent],
  imports: [
    CommonModule,
    VouchersRoutingModule,
    // FileUploadModule,
    MessagesModule,
    FormsModule,
    StoreModule.forFeature("vouchers", VoucherReducers)//,
    // PoItemModule
  ],
  exports: [
    
  ]
})
export class VouchersModule { }
