import { Component, OnInit } from '@angular/core';
import { Operator } from 'src/app/data/Operator/Models/operator.model';
import { OperatorService } from 'src/app/data/Operator/Services/operator.service';
import { Message } from 'src/app/data/Shared/Models/responseBase';

@Component({
  selector: 'app-edit-operator',
  templateUrl: './edit-operator.component.html',
  styleUrls: ['./edit-operator.component.css']
})
export class EditOperatorComponent implements OnInit {
  operator: Operator;
  isError: boolean;
  messages: Message[];
  constructor(private operatorService: OperatorService) {
    this.operator = new Operator();
    this.isError = false;
    this.messages = Array();
  }

  ngOnInit() {
    this.operatorService.getOperator('1').subscribe(x=>{
      if(x.status == true){
        this.operator = x.operator;
      }
      else{
        this.isError = true;
        this.messages = x.messages;
      }
    }, err=>{
      this.isError = true;
    })
  }

  updateOperator() {
    this.operatorService.saveOperator(this.operator).subscribe(
      (x) => {},
      (err) => {}
    );
  }

}
