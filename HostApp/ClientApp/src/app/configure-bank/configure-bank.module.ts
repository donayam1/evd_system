import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigureBankRoutingModule } from './configure-bank-routing.module';
import { HomeComponent } from './home/home.component';
import { ListConfigureBankComponent } from './list-configure-bank/list-configure-bank.component';

@NgModule({
  declarations: [HomeComponent, ListConfigureBankComponent],
  imports: [
    CommonModule,
    ConfigureBankRoutingModule
  ]
})
export class ConfigureBankModule { }
