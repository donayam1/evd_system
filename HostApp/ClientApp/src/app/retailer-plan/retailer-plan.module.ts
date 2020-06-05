import { StoreModule } from '@ngrx/store';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RetailerPlanRoutingModule } from './retailer-plan-routing.module';
import { PlanListComponent } from './plan-list/plan-list.component';
import { PlanHomeComponent } from './plan-home/plan-home.component';
import { FormsModule } from '@angular/forms';
import { CreatePlanComponent } from './create-plan/create-plan.component';
import { MessagesModule } from '../messages/messages.module';
import { EditPlanComponent } from './edit-plan/edit-plan.component';
import { OperatorReducers } from '../data/Operator/Reducer/operator.reducer';

@NgModule({
  declarations: [PlanListComponent, PlanHomeComponent, CreatePlanComponent, EditPlanComponent],
  imports: [
    CommonModule,
    RetailerPlanRoutingModule,
    FormsModule,
    MessagesModule,
    StoreModule.forFeature("org", OperatorReducers)
  ]
})
export class RetailerPlanModule { }
