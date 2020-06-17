import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminRoutingModule } from './admin-routing.module';
// import { TreeModule } from 'angular-tree-component';
import { HomeComponent } from './home/home.component';
import { VoucherStatisticsModule } from '../voucher-statistics/voucher-statistics.module';
import { AirTimeModule } from '../air-time/air-time.module';

import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule} from '@angular/material/menu';

import {MatCardModule} from '@angular/material/card';


@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    VoucherStatisticsModule,
    AirTimeModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule


    
    // ,
    // TreeModule.forRoot()
  ],
  declarations: [AdminHomeComponent, HomeComponent]
})
export class AdminHomeModule { }
