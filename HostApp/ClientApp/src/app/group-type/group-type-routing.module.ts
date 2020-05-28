<<<<<<< HEAD
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateGroupTypeComponent } from './create-group-type/create-group-type.component';
import { EditGroupTypeComponent } from './edit-group-type/edit-group-type.component';

const routes: Routes = [
  {path:'', component: CreateGroupTypeComponent},
  {path:'./edit', component: EditGroupTypeComponent}
];
=======
import { NgModule, Component } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CreateGroupTypeComponent } from "./create-group-type/create-group-type.component";

const routes: Routes = [{ path: "", component: CreateGroupTypeComponent }];
>>>>>>> a4f1ebfa2725210257481ce53fc64fb56509f9e0

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupTypeRoutingModule {}
