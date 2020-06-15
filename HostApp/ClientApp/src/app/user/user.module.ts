import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { CreateUserComponent } from './create-user/create-user.component';
import { FormsModule } from '@angular/forms';
import { MessagesModule } from '../messages/messages.module';
import { UserHomeComponent } from './user-home/user-home.component';
import { ListUserComponent } from './list-user/list-user.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { EditUserPermissionComponent } from './edit-user-permission/edit-user-permission.component';
import { StoreModule } from '@ngrx/store';
import { UserReducers } from '../data/User/Reducers/user.resucers';
import { UserBankAccountModule } from '../user-bank-account/user-bank-account.module';
import { ListUserBankAccountComponent } from './list-user-bank-account/list-user-bank-account.component'

@NgModule({
  declarations: [
    CreateUserComponent,
    UserHomeComponent,
    ListUserComponent,
    UserDetailComponent,
    EditUserComponent,
    EditUserPermissionComponent,
    ListUserBankAccountComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    MessagesModule,
    StoreModule.forFeature("users", UserReducers),
    UserBankAccountModule
  ]
})
export class UserModule { }
