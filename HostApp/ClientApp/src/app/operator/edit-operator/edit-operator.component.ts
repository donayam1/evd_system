import { Component, OnInit } from '@angular/core';
import { Operator } from 'src/app/data/Operator/Models/operator.model';
import { OperatorService } from 'src/app/data/Operator/Services/operator.service';

@Component({
  selector: 'app-edit-operator',
  templateUrl: './edit-operator.component.html',
  styleUrls: ['./edit-operator.component.css']
})
export class EditOperatorComponent implements OnInit {
  operator: Operator;
  constructor(private operatorService: OperatorService) { }

  ngOnInit() {
    // this.operatorService.getOperator().subscribe(x=>{}, err=>{})
  }

  updateOperator() {
    this.operatorService.saveOperator(this.operator).subscribe(
      (x) => {},
      (err) => {}
    );
  }

}
