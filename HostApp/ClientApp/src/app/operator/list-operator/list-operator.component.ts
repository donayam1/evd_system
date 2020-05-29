import { Component, OnInit } from "@angular/core";
import { OperatorService } from "src/app/data/Operator/Services/operator.service";
import { Operator } from "src/app/data/Operator/Models/operator.model";

@Component({
  selector: "app-list-operator",
  templateUrl: "./list-operator.component.html",
  styleUrls: ["./list-operator.component.css"],
})
export class ListOperatorComponent implements OnInit {
  operator: any;

  constructor(private operatorService: OperatorService) {}

  ngOnInit() {
    this.operatorService.getOperator().subscribe((data: Operator[]) => {
      this.operator = data;
    });
  }
}