import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { CreateUserComponent } from './create-user/create-user.component';
import { FormsModule } from '@angular/forms';
import { MessagesModule } from '../messages/messages.module';
import { UserHomeComponent } from './user-home/user-home.component';
import { ListUserComponent } from './list-user/list-user.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { StoreModule } from '@ngrx/store';
import { UserReducers } from '../data/User/Reducers/user.resucers';

@NgModule({
  declarations: [CreateUserComponent, UserHomeComponent, ListUserComponent, UserDetailComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    MessagesModule,
    StoreModule.forFeature("users", UserReducers)
  ]
})
export class UserModule { }
