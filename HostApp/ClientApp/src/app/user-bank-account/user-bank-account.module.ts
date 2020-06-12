import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//import { UserBankAccountRoutingModule } from './user-bank-account-routing.module';
import { FormsModule } from '@angular/forms';
import { EditUserBankAccountComponent } from './edit-user-bank-account/edit-user-bank-account.component';
import { MessagesModule } from '../messages/messages.module';
import { ListUserBankAccountComponent } from './list-user-bank-account/list-user-bank-account.component';
import { StoreModule } from '@ngrx/store';
import { UserBankAccountReducers } from '../data/UserBankAccount/Reducers/userBankAccount.reducers';
import { CreateBankAccountComponent } from './create-bank-account/create-bank-account.component';

@NgModule({
  declarations: [EditUserBankAccountComponent, ListUserBankAccountComponent, CreateBankAccountComponent],
  imports: [
    CommonModule,
    //UserBankAccountRoutingModule,
    FormsModule,
    MessagesModule,
    StoreModule.forFeature("userBankAccounts" , UserBankAccountReducers)
  ],
  exports: [EditUserBankAccountComponent, CreateBankAccountComponent]
})
export class UserBankAccountModule { }
