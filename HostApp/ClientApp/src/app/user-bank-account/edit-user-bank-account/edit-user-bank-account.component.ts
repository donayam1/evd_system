import { SelectUserAction } from 'src/app/data/User/Actions/user.actions';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { NewUserBankAccount, UserBankAccount } from 'src/app/data/UserBankAccount/Models/user-bank-account.model';
import { Users } from 'src/app/data/User/Models/user.model';
import { UserBankAccountService } from 'src/app/data/UserBankAccount/Services/user-bank-account.service';
import { ConfigureBankService } from 'src/app/data/ConfigureBank/Services/configure-bank.service';
import { Store, State } from '@ngrx/store';
import { UserState, SelectCurrentUser } from 'src/app/data/User/Reducers/user.resucers';
import { Bank, ListConfigureBankResponse } from 'src/app/data/ConfigureBank/Models/configure-bank.model';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { MessageComponent } from 'src/app/messages/message/message.component';

@Component({
  selector: 'app-edit-user-bank-account',
  templateUrl: './edit-user-bank-account.component.html',
  styleUrls: ['./edit-user-bank-account.component.css']
})
export class EditUserBankAccountComponent implements OnInit {
  
  //@Input()
  nub: UserBankAccount;
  selectedUser: Users;
  selectedBank: Bank;
  banks: ListConfigureBankResponse;

  @ViewChild('messages', { static: true })
  messagesCopmponent: MessageComponent;
  
  constructor(private ubService: UserBankAccountService, private bankService: ConfigureBankService, private store: Store<UserState>, private state: State<UserState>) {
    this.nub = new UserBankAccount();
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

    this.ubService.getUserBankAccount(this.selectedUser.Id).subscribe(x => {
      if(x.status === true){
        this.nub = x.userBa;
      }
    });
  }

  updateUserBankAccount(){
    this.nub.objectStatus = ObjectStatus.EDITTED;
    this.ubService.updateUserBankAccount(this.nub).subscribe(x => {
      if(x.status === true){
        console.log(x);
      }
    })
  }

}
