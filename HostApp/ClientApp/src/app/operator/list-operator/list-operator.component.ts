import { Component, OnInit } from "@angular/core";
import { OperatorService } from "src/app/data/Operator/Services/operator.service";
import { Operator, ListOperatorResponse } from "src/app/data/Operator/Models/operator.model";
import { Store } from "@ngrx/store";
import { OperatorState } from "src/app/data/Operator/Reducer/operator.reducer";
import { SelectOperatorAction } from "src/app/data/Operator/Action/operator.actions";

@Component({
  selector: "app-list-operator",
  templateUrl: "./list-operator.component.html",
  styleUrls: ["./list-operator.component.css"],
})
export class ListOperatorComponent implements OnInit {
  response: ListOperatorResponse;

  constructor(private operatorService: OperatorService,
    private store:Store<OperatorState>) {}

  ngOnInit() {
    this.operatorService.fetchOperator().subscribe((data) => {
      this.response = data;
      console.log(data)
    });
  }
  editOperator(operator:Operator){
    let selectOperatorAction= new SelectOperatorAction(operator);
    this.store.dispatch(selectOperatorAction);
  }
}
