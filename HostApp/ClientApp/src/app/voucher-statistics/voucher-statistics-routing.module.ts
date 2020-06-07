import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListVoucherStatisticsComponent } from './list-voucher-statistics/list-voucher-statistics.component';

const routes: Routes = [
  {path: '', component: ListVoucherStatisticsComponent , children:[
    {path: "home" , component: HomeComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VoucherStatisticsRoutingModule { }
