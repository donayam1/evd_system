import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MoneyDepositRoutingModule } from './money-deposit-routing.module';
import { ListMoneyDepositComponent } from './list-money-deposit/list-money-deposit.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [ListMoneyDepositComponent, HomeComponent],
  imports: [
    CommonModule,
    MoneyDepositRoutingModule
  ]
})
export class MoneyDepositModule { }
