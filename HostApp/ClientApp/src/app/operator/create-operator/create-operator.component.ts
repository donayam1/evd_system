import { Component, OnInit } from "@angular/core";
import { Operator } from "src/app/data/Operator/Models/operator.model";
import { OperatorService } from "src/app/data/Operator/Services/operator.service";

@Component({
  selector: "app-create-operator",
  templateUrl: "./create-operator.component.html",
  styleUrls: ["./create-operator.component.css"],
})
export class CreateOperatorComponent implements OnInit {
  operator: Operator;

  constructor(private operatorService: OperatorService) {}

  saveOperator() {
    this.operatorService.saveOperator(this.operator).subscribe(
      (x) => {},
      (err) => {}
    );
  }

  ngOnInit() {}
}
