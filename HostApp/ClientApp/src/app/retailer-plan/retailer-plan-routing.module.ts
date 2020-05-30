import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlanHomeComponent } from './plan-home/plan-home.component';
import { PlanListComponent } from './plan-list/plan-list.component';

const routes: Routes = [
  {path: '', component: PlanHomeComponent , children:[
    {path: 'list', component: PlanListComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RetailerPlanRoutingModule { }
