import { CreatePlanComponent } from './create-plan/create-plan.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlanHomeComponent } from './plan-home/plan-home.component';
import { PlanListComponent } from './plan-list/plan-list.component';
import { EditPlanComponent } from './edit-plan/edit-plan.component';

const routes: Routes = [
  {path: '', component: PlanHomeComponent , children:[
    {path: 'list', component: PlanListComponent},
    { path: 'create', component: CreatePlanComponent },
    { path: 'edit', component: EditPlanComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RetailerPlanRoutingModule { }
