import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//import { UserBankAccountRoutingModule } from './user-bank-account-routing.module';
import { FormsModule } from '@angular/forms';
import { EditUserBankAccountComponent } from './edit-user-bank-account/edit-user-bank-account.component';
import { MessagesModule } from '../messages/messages.module';

@NgModule({
  declarations: [EditUserBankAccountComponent],
  imports: [
    CommonModule,
    //UserBankAccountRoutingModule,
    FormsModule,
    MessagesModule
  ],
  exports: [EditUserBankAccountComponent]
})
export class UserBankAccountModule { }
