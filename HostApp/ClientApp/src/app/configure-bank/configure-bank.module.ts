import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigureBankRoutingModule } from './configure-bank-routing.module';
import { HomeComponent } from './home/home.component';
import { ListConfigureBankComponent } from './list-configure-bank/list-configure-bank.component';
import { CreateBankComponent } from './create-bank/create-bank.component';
import { FormsModule } from '@angular/forms';
import { MessagesModule } from '../messages/messages.module';

@NgModule({
  declarations: [HomeComponent, ListConfigureBankComponent, CreateBankComponent],
  imports: [
    CommonModule,
    ConfigureBankRoutingModule,
    FormsModule,
    MessagesModule
  ]
})
export class ConfigureBankModule { }
