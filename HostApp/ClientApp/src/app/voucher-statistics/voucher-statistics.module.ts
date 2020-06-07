import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VoucherStatisticsRoutingModule } from './voucher-statistics-routing.module';
import { ListVoucherStatisticsComponent } from './list-voucher-statistics/list-voucher-statistics.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [ListVoucherStatisticsComponent, HomeComponent],
  imports: [
    CommonModule,
    VoucherStatisticsRoutingModule
  ],
  exports: [
    ListVoucherStatisticsComponent
  ]
})
export class VoucherStatisticsModule { }
