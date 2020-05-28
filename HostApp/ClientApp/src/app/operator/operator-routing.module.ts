import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateOperatorComponent } from './create-operator/create-operator.component';

const routes: Routes = [
  {path: '', component: CreateOperatorComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OperatorRoutingModule { }
