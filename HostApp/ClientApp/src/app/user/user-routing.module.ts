import { CreateUserComponent } from './create-user/create-user.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditUserComponent } from './edit-user/edit-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { EditUserPermissionComponent } from './edit-user-permission/edit-user-permission.component';
import { ListUserBankAccountComponent } from './list-user-bank-account/list-user-bank-account.component';
import { CreateBankAccountComponent } from '../user-bank-account/create-bank-account/create-bank-account.component';

const routes: Routes = [
  {
    path: '', component: UserHomeComponent, children: [
      { path: 'create', component: CreateUserComponent },
      { path: 'list', component: ListUserComponent },
      {
        path: 'detail', component: UserDetailComponent, children: [
          { path: '', redirectTo: 'bankAccountList' },
          { path: 'edit', component: EditUserComponent },
          { path: 'permissions', component: EditUserPermissionComponent },
          { path: 'bankdata', component: CreateBankAccountComponent },
          { path: 'bankAccountList', component: ListUserBankAccountComponent }
        ]
      },
      // {path: 'permissions', component: EditUserPermissionComponent},
      // {path: 'bankdata', component: CreateBankAccountComponent},
      // {path: 'bankAccountList', component: ListUserBankAccountComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
