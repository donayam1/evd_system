import { OperatorService } from 'src/app/data/Operator/Services/operator.service';
import { OperatorState, SelectCurrentOperator } from './../../data/Operator/Reducer/operator.reducer';
import { Store, State } from '@ngrx/store';
import { Operator, ListOperatorResponse } from 'src/app/data/Operator/Models/operator.model';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';
import { NewPlan, CommissionRate } from './../../data/RetailerPlan/Models/retailer-plan.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MessageComponent } from 'src/app/messages/message/message.component';
import { ArrayType } from '@angular/compiler';
import { SelectOperatorAction } from 'src/app/data/Operator/Action/operator.actions';

@Component({
  selector: 'app-create-plan',
  templateUrl: './create-plan.component.html',
  styleUrls: ['./create-plan.component.css']
})
export class CreatePlanComponent implements OnInit {
  np: NewPlan;
  cr: CommissionRate;
  crs: CommissionRate[];
  opList: ListOperatorResponse;
  selectedOp: Operator;
  commissionType: Array<string>;
  renewalRate: Array<string>;
  selectedType: string;
  selectedRenewalRate: string;
  idCounter = -1;
  crId = 0;
  opTriggered: boolean;

  @ViewChild('messages', {static: true})
  messagesComponent: MessageComponent;

  constructor(private retailerPlanService: RetailerPlanService, private opService: OperatorService, private store: Store<OperatorState>, private state: State<OperatorState>) {
    this.np = new NewPlan();
    this.cr = new CommissionRate();
    this.crs = Array() || null;
    this.opTriggered = false;
    this.opList = new ListOperatorResponse();
    this.commissionType = ['Flat Commission', 'Per-recharge Commission'];
    this.renewalRate = ['Per Day', 'Per Week', 'Per Month', 'Per Year'];
  }

  operatorSelected(operator: Operator){
    this.opService.getOperator(operator.id).subscribe(x => {
      this.selectedOp = x.operator;
      console.log(x);
    });
    this.opTriggered = true;
    
    // let opSelectAction = new SelectOperatorAction(operator);
    // this.store.dispatch(opSelectAction);
    // let currentOperator = SelectCurrentOperator(this.state.value);
  }

  // checkRenewalRate($event?: any){
  //   this.selectedRenewalRate = $event.target.value;
  //   if(this.selectedRenewalRate === 'Per Day'){
  //     this.np.renewalAmountChargingRate = 1;
  //     // console.log('Perday');
  //   }
  //   if(this.selectedRenewalRate === 'Per Week'){
  //     this.np.renewalAmountChargingRate = 2;
  //     //console.log('Perweek');
  //   }
  //   if(this.selectedRenewalRate === 'Per Month'){
  //     this.np.renewalAmountChargingRate = 3;
  //     //console.log('Permonth');
  //   }
  //   if(this.selectedRenewalRate === 'Per Year'){
  //     this.np.renewalAmountChargingRate = 4;
  //     // console.log('Peryear');
  //   }
    
  // }

  checkCommissionType($event?: any){
    this.selectedType = $event.target.value;
    if(this.selectedType === 'Flat Commission'){
      this.np.commisionRateType = 1;
      // console.log('flat commission')
    }
    if(this.selectedType === 'Per-recharge Commission'){
      //this.selectedType = 'Per-recharge Commission';
      this.np.commisionRateType = 2;
      // console.log('per commission')
    }
  }

  addCr($event?: any){
    this.idCounter--;
    this.crId++;
    this.np.ui_id = this.idCounter + "";
    this.cr.id = this.crId + "";
    console.log(this.cr);
    this.crs.push(new CommissionRate(this.cr));
    //this.np.commissionRates.push(new CommissionRate(this.cr));
  }

  savePlan($event?: any){
    //this.addCr();
    this.np.status = ObjectStatus.NEW;
    if(this.selectedType === 'Flat Commission'){
      this.idCounter--;
      this.crId++;
      this.np.ui_id = this.idCounter + "";
      this.cr.id = this.crId + "";
      this.cr.amount = 0;
      this.np.commissionRates.push(this.cr);
    }
    else{
      this.np.commissionRates = this.crs;
    }
    this.np.code = '0';
    this.np.joiningAmount = 0;
    this.np.renwalAmount = 0;
    this.np.renewalAmountChargingRate = 0;
    this.np.operatorId = this.selectedOp.id;
    this.retailerPlanService.createRetailerPlan(this.np).subscribe(x => {
      this.messagesComponent.addMessages(x);
      if(x.status === true){
        console.log(this.np);
      }
    }, err => { });
  }

  delete(item: CommissionRate){
    const index = this.crs.findIndex(x => x.id === item.id);
    this.crs.splice(index, 1);
  }

  ngOnInit() {
    this.opService.fetchOperator().subscribe((data) => {
      if(data.status === true){
        this.opList = data;
        this.selectedOp = data.operators[0];
        console.log(data);
        this.opTriggered = true;
      }
    });
  }

}
