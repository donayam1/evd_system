import { Component, OnInit, ViewChild } from '@angular/core';
import { NewUserBankAccount } from 'src/app/data/UserBankAccount/Models/user-bank-account.model';
import { Users } from 'src/app/data/User/Models/user.model';
import { Bank, ListConfigureBankResponse } from 'src/app/data/ConfigureBank/Models/configure-bank.model';
import { MessageComponent } from 'src/app/messages/message/message.component';
import { UserBankAccountService } from 'src/app/data/UserBankAccount/Services/user-bank-account.service';
import { ConfigureBankService } from 'src/app/data/ConfigureBank/Services/configure-bank.service';
import { Store, State } from '@ngrx/store';
import { UserState, SelectCurrentUser } from 'src/app/data/User/Reducers/user.resucers';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';

@Component({
  selector: 'app-create-bank-account',
  templateUrl: './create-bank-account.component.html',
  styleUrls: ['./create-bank-account.component.css']
})
export class CreateBankAccountComponent implements OnInit {
  newAccount: NewUserBankAccount;
  selectedUser: Users;
  selectedBank: Bank;
  banks: ListConfigureBankResponse;
  uiCounter = 0;
  idCounter = 0;

  @ViewChild('messages', {static: true})
  messagesComponent: MessageComponent;

  constructor(private ubService: UserBankAccountService, private bankService: ConfigureBankService, private store: Store<UserState>, private state: State<UserState>) {
    this.newAccount = new NewUserBankAccount();
    this.selectedUser = new Users();
    this.banks = new ListConfigureBankResponse();
    this.selectedBank = new Bank();
  }

  ngOnInit() {
    const currentUser = SelectCurrentUser(this.state.value);
    console.dir(currentUser);
    if(currentUser != null){
      this.selectedUser = currentUser;
      console.log(this.selectedUser);
    }

    this.bankService.fetchConfigureBank().subscribe(x => {
      if(x.status === true){
        this.banks = x;
        console.log(x);
      }
    });
  }

  saveBankData(){
    this.uiCounter--;
    this.idCounter++;
    this.newAccount.status = ObjectStatus.NEW;
    this.newAccount.userId = this.selectedUser.Id;
    this.newAccount.bankId = this.selectedBank.id;
    //this.newAccount.ui_id = this.uiCounter + "";
    this.newAccount.id = this.idCounter + "";
    console.dir(this.newAccount);
    this.ubService.saveUserBankAccount(this.newAccount).subscribe(x => {
      this.messagesComponent.addMessages(x);
      if(x.status === true){
        console.log(x);
      }
    });
  }

}
