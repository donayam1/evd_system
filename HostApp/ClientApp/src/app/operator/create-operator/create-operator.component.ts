import { Component, OnInit, ViewChild } from "@angular/core";
import { Operator } from "src/app/data/Operator/Models/operator.model";
import { OperatorService } from "src/app/data/Operator/Services/operator.service";
import { State } from '@ngrx/store';
import { MessageComponent } from "src/app/messages/message/message.component";

@Component({
  selector: "app-create-operator",
  templateUrl: "./create-operator.component.html",
  styleUrls: ["./create-operator.component.css"],
})
export class CreateOperatorComponent implements OnInit {
  operator: Operator;

  @ViewChild('messages', {static: true})
  messagesComponent: MessageComponent;
  constructor(private operatorService: OperatorService) {
    this.operator = new Operator();
  }

  saveOperator() {
    this.operatorService.saveOperator(this.operator).subscribe(
      (x) => {
        this.messagesComponent.addMessages(x);
      },
      (err) => {}
    );
  }

  ngOnInit() {}
}
