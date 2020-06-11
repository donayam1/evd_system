import { Component, OnInit } from '@angular/core';
import { UserBankAccountService } from 'src/app/data/UserBankAccount/Services/user-bank-account.service';
import { ListUserBankAccountResponse, UserBankAccount } from 'src/app/data/UserBankAccount/Models/user-bank-account.model';
import { UserBankAccountState } from 'src/app/data/UserBankAccount/Reducers/userBankAccount.reducers';
import { Store } from '@ngrx/store';
import { SelectUserBankAccountAction } from 'src/app/data/UserBankAccount/Actions/userBankAccount.actions';

@Component({
  selector: 'app-list-user-bank-account',
  templateUrl: './list-user-bank-account.component.html',
  styleUrls: ['./list-user-bank-account.component.css']
})
export class ListUserBankAccountComponent implements OnInit {

  response: ListUserBankAccountResponse;

  constructor(private userBankAccountService: UserBankAccountService,
              private store: Store<UserBankAccountState>) { 
    this.response = new ListUserBankAccountResponse();
  }

  ngOnInit() {
    this.userBankAccountService.fetchUserBankAccount().subscribe(data => {
      this.response = data;
      console.log(data);
    })
  }


  editUserBankAccount(userBankAccount: UserBankAccount){
    let userBankAccountSelectedAction = new SelectUserBankAccountAction(userBankAccount);
    this.store.dispatch(userBankAccountSelectedAction);
  }
}
