import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateGroupTypeComponent } from './create-group-type/create-group-type.component';
import { EditGroupTypeComponent } from './edit-group-type/edit-group-type.component';
import { ListGroupTypeComponent } from './list-group-type/list-group-type.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'', component: HomeComponent ,children:[
    {path:'list', component: ListGroupTypeComponent},
    {path:'edit', component: EditGroupTypeComponent},
    {path:'add', component: CreateGroupTypeComponent}
  ]}
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupTypeRoutingModule {}
