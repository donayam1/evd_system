import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { SelectCurrentOperator, OperatorState } from './../../data/Operator/Reducer/operator.reducer';
import { Component, OnInit } from '@angular/core';
import { Operator } from 'src/app/data/Operator/Models/operator.model';
import { OperatorService } from 'src/app/data/Operator/Services/operator.service';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { SelectOperatorAction } from 'src/app/data/Operator/Action/operator.actions';
import { State, Store } from '@ngrx/store';

@Component({
  selector: 'app-edit-operator',
  templateUrl: './edit-operator.component.html',
  styleUrls: ['./edit-operator.component.css']
})
export class EditOperatorComponent implements OnInit {
  operator: Operator;
  isError: boolean;
  messages: Message[];
  constructor(private operatorService: OperatorService, private store: Store<OperatorState>, private state: State<OperatorState>) {
    this.operator = new Operator();
    this.isError = false;
    this.messages = Array();
  }

  ngOnInit() {

    let currentOperator = SelectCurrentOperator(this.state.value);
    if(currentOperator == null){
      //go to listpage
    }
    this.operator = currentOperator;

    // this.operatorService.getOperator(this.operator.id).subscribe(x=>{
    //   if(x.status == true){
    //     this.operator = x.operator;
    //   }
    //   else{
    //     this.isError = true;
    //     this.messages = x.messages;
    //   }
    // }, err=>{
    //   this.isError = true;
    // })
  }



  updateOperator() {
    this.operator.status = ObjectStatus.EDITTED;
    this.operatorService.saveOperator(this.operator).subscribe(
      (x) => {},
      (err) => {}
    );
  }

}
