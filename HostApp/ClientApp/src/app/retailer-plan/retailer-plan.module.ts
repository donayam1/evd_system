import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RetailerPlanRoutingModule } from './retailer-plan-routing.module';
import { PlanListComponent } from './plan-list/plan-list.component';
import { PlanHomeComponent } from './plan-home/plan-home.component';

@NgModule({
  declarations: [PlanListComponent, PlanHomeComponent],
  imports: [
    CommonModule,
    RetailerPlanRoutingModule
  ]
})
export class RetailerPlanModule { }
