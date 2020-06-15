import { Component, OnInit } from '@angular/core';
import { MoneyDepositService } from 'src/app/data/MoneyDeposit/Services/money-deposit.service';
import { ListDepositResponse } from 'src/app/data/MoneyDeposit/Models/money-deposit.model';
import { MoneyDeposit } from '../../data/MoneyDeposit/Models/money-deposit.model';


@Component({
  selector: 'app-list-money-deposit',
  templateUrl: './list-money-deposit.component.html',
  styleUrls: ['./list-money-deposit.component.css']
})
export class ListMoneyDepositComponent implements OnInit {

  response: ListDepositResponse;

  constructor(private moneyDepositService: MoneyDepositService) {
    this.response = new ListDepositResponse();
  }

  ngOnInit() {
    this.moneyDepositService.fetchMoneyDeposit().subscribe(data => {
      this.response = data;
      console.log(this.response);
    })
  }

  approve(deposit: MoneyDeposit) {
    this.moneyDepositService.approveMoneyDeposit(deposit).subscribe(x => {
      if (x.status == true) {
        alert("Sucess");
      } else {
        alert("failer");
      }
    });
  }


}
