import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateGroupTypeComponent } from './create-group-type/create-group-type.component';

const routes: Routes = [
  {path:'', component: CreateGroupTypeComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupTypeRoutingModule { }
