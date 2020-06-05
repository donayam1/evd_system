import { CreateUserComponent } from './create-user/create-user.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListUserComponent } from './list-user/list-user.component';
import { UserDetailComponent } from './user-detail/user-detail.component';

const routes: Routes = [
  { path: '', component: UserHomeComponent , children:[
    { path: 'create', component: CreateUserComponent },
    {path: 'list', component: ListUserComponent},
    {path: 'detail', component: UserDetailComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
