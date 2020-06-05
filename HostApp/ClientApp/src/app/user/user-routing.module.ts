import { CreateUserComponent } from './create-user/create-user.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: UserHomeComponent , children:[
    { path: 'create', component: CreateUserComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
