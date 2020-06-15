import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminRoutingModule } from './admin-routing.module';
// import { TreeModule } from 'angular-tree-component';
import { HomeComponent } from './home/home.component';
import { VoucherStatisticsModule } from '../voucher-statistics/voucher-statistics.module';
import { AirTimeModule } from '../air-time/air-time.module';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    VoucherStatisticsModule,
    AirTimeModule
    // ,
    // TreeModule.forRoot()
  ],
  declarations: [AdminHomeComponent, HomeComponent]
})
export class AdminHomeModule { }
