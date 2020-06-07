import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListVoucherStatisticsComponent } from './list-voucher-statistics/list-voucher-statistics.component';

const routes: Routes = [
  {path: '', component: HomeComponent , children:[
    {path: "list" , component: ListVoucherStatisticsComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VoucherStatisticsRoutingModule { }
