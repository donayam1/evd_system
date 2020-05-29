import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateOperatorComponent } from './create-operator/create-operator.component';
import { ListOperatorComponent } from './list-operator/list-operator.component';
import { EditOperatorComponent } from './edit-operator/edit-operator.component';

const routes: Routes = [
  {path: '', component: CreateOperatorComponent},
  {path: './edit', component: EditOperatorComponent},
  { path: "operator-list", component: ListOperatorComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OperatorRoutingModule { }
