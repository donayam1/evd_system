import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MoneyDepositRoutingModule } from './money-deposit-routing.module';
import { ListMoneyDepositComponent } from './list-money-deposit/list-money-deposit.component';
import { HomeComponent } from './home/home.component';
import { CreateMoneyDepositComponent } from './create-money-deposit/create-money-deposit.component';
import { FormsModule } from '@angular/forms';
import { MessagesModule } from '../messages/messages.module';


@NgModule({
  declarations: [ListMoneyDepositComponent, HomeComponent, CreateMoneyDepositComponent],
  imports: [
    CommonModule,
    MoneyDepositRoutingModule,
    FormsModule,
    MessagesModule
  ]
})
export class MoneyDepositModule { }
