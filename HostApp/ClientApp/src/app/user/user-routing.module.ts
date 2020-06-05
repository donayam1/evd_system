import { CreateUserComponent } from './create-user/create-user.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditUserComponent } from './edit-user/edit-user.component';

const routes: Routes = [
  { path: '', component: UserHomeComponent , children:[
    { path: 'create', component: CreateUserComponent },
    { path: 'edit', component: EditUserComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
