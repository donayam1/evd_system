import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateGroupTypeComponent } from './create-group-type/create-group-type.component';
import { EditGroupTypeComponent } from './edit-group-type/edit-group-type.component';
import { ListGroupTypeComponent } from './list-group-type/list-group-type.component';

const routes: Routes = [
  {path:'', component: CreateGroupTypeComponent},
  {path:'./edit', component: EditGroupTypeComponent},
  { path: "./grouptype", component: ListGroupTypeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupTypeRoutingModule {}
