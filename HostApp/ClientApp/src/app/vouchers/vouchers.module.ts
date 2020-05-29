import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VouchersRoutingModule } from './vouchers-routing.module';
import { UploadComponent } from './upload/upload.component';
import { FileUploadModule } from '../file-upload/file-upload.module';
import { HomeComponent } from './home/home.component';
import { ListVouchersComponent } from './list-vouchers/list-vouchers.component';
import { MessagesModule } from '../messages/messages.module';

@NgModule({
  declarations: [UploadComponent, HomeComponent, ListVouchersComponent],
  imports: [
    CommonModule,
    VouchersRoutingModule,
    FileUploadModule,
    MessagesModule
  ],
  exports: [
    UploadComponent
  ]
})
export class VouchersModule { }
