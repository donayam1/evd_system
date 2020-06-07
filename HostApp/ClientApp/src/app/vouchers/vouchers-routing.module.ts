import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UploadComponent } from './upload/upload.component';
import { ListVouchersComponent } from './list-vouchers/list-vouchers.component';
import { VoucherComponent } from './voucher/voucher.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      { path: 'upload', component: UploadComponent },
      { path: 'list', component: ListVouchersComponent },
      { path: 'view', component: VoucherComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VouchersRoutingModule { }
