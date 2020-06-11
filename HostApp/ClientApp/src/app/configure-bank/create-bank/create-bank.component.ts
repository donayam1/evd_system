import { Component, OnInit, ViewChild } from '@angular/core';
import { NewBank } from 'src/app/data/ConfigureBank/Models/configure-bank.model';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { MessageComponent } from 'src/app/messages/message/message.component';
import { ConfigureBankService } from 'src/app/data/ConfigureBank/Services/configure-bank.service';

@Component({
  selector: 'app-create-bank',
  templateUrl: './create-bank.component.html',
  styleUrls: ['./create-bank.component.css']
})
export class CreateBankComponent implements OnInit {
  banks: NewBank[];
  currentBank: NewBank;
  isError: boolean;
  messages: Message[];
  idCounter = 0;

  @ViewChild('messages', {static: true})
  messageComponent: MessageComponent;

  constructor(private bankService: ConfigureBankService) {
    this.banks = Array();
    this.currentBank = new NewBank();
    this.isError = false;
    this.messages = Array();
  }

  ngOnInit() {
  }

  addBank($event?: any){
    this.idCounter++;
    this.currentBank.id = this.idCounter + '';
    this.currentBank.ui_id = this.idCounter + '';
    console.log(this.currentBank);
    this.banks.push(new NewBank(this.currentBank));
    this.currentBank.name = '';
    
  }

  saveBanks($event?: any){
    this.bankService.createBank(this.banks).subscribe(x => {
      //console.dir(x);
      if (x.status === true){
        this.banks = x.banks;
        console.log(this.banks);
      }
      else{
        this.isError = true;
        this.messages = x.messages;
        console.log('error');
        console.log(this.messages);
      }
    }, error => {
      this.isError = true;
    });
  }

  deleteBank(item: NewBank){
    const index = this.banks.findIndex(x => x.id === item.id);
    this.banks.splice(index, 1);
  }
}
