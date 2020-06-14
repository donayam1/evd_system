import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListvoucherBatchComponent } from './listvoucher-batch/listvoucher-batch.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [
  { path: '' , component: HomeComponent, children: [
      {path: 'list' , component: ListvoucherBatchComponent },
      {path: 'upload', component: UploadComponent },
      {path: 'peek/:id', loadChildren: "../vouchers/vouchers.module#VouchersModule" }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VoucherBatchRoutingModule { }
