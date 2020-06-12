import { Component, OnInit } from '@angular/core';
import { ConfigureBankService } from 'src/app/data/ConfigureBank/Services/configure-bank.service';
import { ListConfigureBankResponse } from 'src/app/data/ConfigureBank/Models/configure-bank.model';

@Component({
  selector: 'app-list-configure-bank',
  templateUrl: './list-configure-bank.component.html',
  styleUrls: ['./list-configure-bank.component.css']
})
export class ListConfigureBankComponent implements OnInit {

  response: ListConfigureBankResponse;

  constructor(private bankService: ConfigureBankService) {
    this.response = new ListConfigureBankResponse ();
   }

  ngOnInit() {
    this.bankService.fetchConfigureBank().subscribe(data => {
      this.response = data;
      console.log(data)
    })
  }

}
