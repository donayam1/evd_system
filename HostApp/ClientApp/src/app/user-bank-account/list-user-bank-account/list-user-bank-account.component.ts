import { State } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { UserBankAccountService } from 'src/app/data/UserBankAccount/Services/user-bank-account.service';
import { ListUserBankAccountResponse, UserBankAccount } from 'src/app/data/UserBankAccount/Models/user-bank-account.model';
import { UserBankAccountState } from 'src/app/data/UserBankAccount/Reducers/userBankAccount.reducers';
import { Store } from '@ngrx/store';
import { SelectUserBankAccountAction } from 'src/app/data/UserBankAccount/Actions/userBankAccount.actions';
import { UserState, SelectCurrentUser } from 'src/app/data/User/Reducers/user.resucers';
import { Users } from 'src/app/data/User/Models/user.model';

@Component({
  selector: 'app-list-user-bank-account',
  templateUrl: './list-user-bank-account.component.html',
  styleUrls: ['./list-user-bank-account.component.css']
})
export class ListUserBankAccountComponent implements OnInit {

  response: ListUserBankAccountResponse;
  user: Users;

  constructor(private userBankAccountService: UserBankAccountService,
              private store: Store<UserBankAccountState>,
              private userstore: Store<UserState>, private state: State<UserState>) { 
    this.response = new ListUserBankAccountResponse();
    this.user = new Users();
  }

  ngOnInit() {
    const cUser = SelectCurrentUser(this.state.value);
    console.dir(cUser);
    if(cUser != null){
      this.user = cUser;
    }
    this.userBankAccountService.fetchUserBankAccount(this.user.Id).subscribe(data => {
      this.response = data;
      console.log(data);
    })
  }


  editUserBankAccount(userBankAccount: UserBankAccount){
    let userBankAccountSelectedAction = new SelectUserBankAccountAction(userBankAccount);
    this.store.dispatch(userBankAccountSelectedAction);
  }
}
