import { Component, OnInit } from '@angular/core';
import { Bank } from 'src/app/data/ConfigureBank/Models/configure-bank.model';
import { ConfigureBankService } from 'src/app/data/ConfigureBank/Services/configure-bank.service';
import { Message } from 'src/app/data/Shared/Models/responseBase';

@Component({
  selector: 'app-edit-bank',
  templateUrl: './edit-bank.component.html',
  styleUrls: ['./edit-bank.component.css']
})
export class EditBankComponent implements OnInit {
  bank: Bank;
  isError: boolean;
  messages: Message[];

  constructor(private bankService: ConfigureBankService) {
    this.bank = new Bank();
    this.isError = false;
    this.messages = Array();
  }

  ngOnInit() {
    this.bankService.getBank('1').subscribe(x => {
      if (x.status === true){
        this.bank = x.banks[0];
      }
      else{
        this.isError = true;
        this.messages = x.messages;
      }
    }, err => {
      this.isError = true;
    });
  }

  updateBank(bank: Bank){
    this.bankService.updateBank(bank).subscribe(x => {
      if(x.status === true){
        console.log(x);
      }
    })
  }
}
