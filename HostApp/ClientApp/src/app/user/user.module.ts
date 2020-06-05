import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { CreateUserComponent } from './create-user/create-user.component';
import { FormsModule } from '@angular/forms';
import { MessagesModule } from '../messages/messages.module';
import { UserHomeComponent } from './user-home/user-home.component';
import { EditUserComponent } from './edit-user/edit-user.component';

@NgModule({
  declarations: [CreateUserComponent, UserHomeComponent, EditUserComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    MessagesModule
  ]
})
export class UserModule { }
