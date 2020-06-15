import { Component, OnInit, ViewChild } from '@angular/core';
import { NewMoneyDeposit } from 'src/app/data/MoneyDeposit/Models/money-deposit.model';
import { MoneyDepositService } from 'src/app/data/MoneyDeposit/Services/money-deposit.service';
import { UserService } from 'src/app/data/User/Services/user.service';
import { Users, ListUserResponse } from 'src/app/data/User/Models/user.model';
import { UserBankAccount, ListUserBankAccountResponse } from 'src/app/data/UserBankAccount/Models/user-bank-account.model';
import { ConfigureBankService } from 'src/app/data/ConfigureBank/Services/configure-bank.service';
import { UserBankAccountService } from 'src/app/data/UserBankAccount/Services/user-bank-account.service';
import { Bank, ListConfigureBankResponse } from 'src/app/data/ConfigureBank/Models/configure-bank.model';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { MessageComponent } from 'src/app/messages/message/message.component';

@Component({
  selector: 'app-create-money-deposit',
  templateUrl: './create-money-deposit.component.html',
  styleUrls: ['./create-money-deposit.component.css']
})
export class CreateMoneyDepositComponent implements OnInit {
  newMoneyDeposit: NewMoneyDeposit;
  userList: ListUserResponse;
  selectedUser: Users;
  selectedUserBankAccount: UserBankAccount;
  userBankList: UserBankAccount[];
  bankList: ListConfigureBankResponse;
  selectedBank: Bank;
  bankL: Bank[];
  isCheque: boolean;
  idCounter = 0;

  @ViewChild('messages', { static: true })
  messages: MessageComponent;

  constructor(private mdService: MoneyDepositService, private userService: UserService, 
    private bankService: ConfigureBankService,
    private ubService: UserBankAccountService) {
    this.newMoneyDeposit = new NewMoneyDeposit();
    this.userList = new ListUserResponse();
    this.selectedUser = new Users();
    this.userBankList = new Array();
    this.selectedUserBankAccount = new UserBankAccount();
    this.bankList = new ListConfigureBankResponse();
    this.selectedBank = new Bank();
    this.bankL = new Array();
    this.isCheque = false;
  }

  ngOnInit() {
    this.userService.fetchUser().subscribe(x => {
      if (x.status === true) {
        this.userList = x;
        console.log(x);
      }
    });
  }

  getbankAccount(id: string){
    this.ubService.fetchUserBankAccount(this.selectedUser.Id).subscribe(x => {
      if(x.status === true){
        this.userBankList = x.bankAccounts;
        this.bankService.fetchConfigureBank().subscribe(x => {
          if(x.status === true){
            // this.selectedBank = x.banks;
            for(let item of x.banks){
              for(let i of this.userBankList){
                if(i.bankId === item.id){
                  this.bankL.push(item);
                  this.selectedBank= item;
                }
              }
            }
          }
        })
      }
    }); 
  }

  isCheq(){
    this.isCheque = true;
  }

  saveDeposit(){
    this.idCounter--;
    this.newMoneyDeposit.id = this.idCounter + '';
    this.newMoneyDeposit.ui_id = this.idCounter + '';
    this.newMoneyDeposit.bankId = this.selectedBank.id;
    this.newMoneyDeposit.forUserId = this.selectedUser.Id;
    this.newMoneyDeposit.isCheque = this.isCheque;
    this.newMoneyDeposit.objectStatus = ObjectStatus.NEW;
    console.dir(this.newMoneyDeposit);
    this.mdService.createMoneyDeposit(this.newMoneyDeposit).subscribe(x => {
      this.messages.addMessages(x);
      if(x.status === true){
        console.log(x);
      }
    });
  }
  // whichUser(){

  // }

}
