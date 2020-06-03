import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';
import { NewPlan, CommissionRate } from './../../data/RetailerPlan/Models/retailer-plan.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MessageComponent } from 'src/app/messages/message/message.component';
import { ArrayType } from '@angular/compiler';

@Component({
  selector: 'app-create-plan',
  templateUrl: './create-plan.component.html',
  styleUrls: ['./create-plan.component.css']
})
export class CreatePlanComponent implements OnInit {
  np: NewPlan;
  cr: CommissionRate;
  crs: CommissionRate[];
  commissionType: Array<string>;
  renewalRate: Array<string>;
  selectedType: string;
  selectedRenewalRate: string;
  idCounter = -1;
  crId = 0;

  @ViewChild('messages', {static: true})
  messagesComponent: MessageComponent;

  constructor(private retailerPlanService: RetailerPlanService) {
    this.np = new NewPlan();
    this.cr = new CommissionRate();
    this.crs = Array();
    this.commissionType = ['Flat Commission', 'Per-recharge Commission'];
    this.renewalRate = ['Per Day', 'Per Week', 'Per Month', 'Per Year'];
  }

  checkRenewalRate($event?: any){
    this.selectedRenewalRate = $event.target.value;
    if(this.selectedRenewalRate === 'Per Day'){
      this.np.renewalAmountChargingRate = 1;
      // console.log('Perday');
    }
    if(this.selectedRenewalRate === 'Per Week'){
      this.np.renewalAmountChargingRate = 2;
      //console.log('Perweek');
    }
    if(this.selectedRenewalRate === 'Per Month'){
      this.np.renewalAmountChargingRate = 3;
      //console.log('Permonth');
    }
    if(this.selectedRenewalRate === 'Per Year'){
      this.np.renewalAmountChargingRate = 4;
      // console.log('Peryear');
    }
    
  }

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
    this.crs.push(new CommissionRate(this.cr));
    //this.np.commissionRates.push(new CommissionRate(this.cr));
  }

  savePlan($event?: any){
    this.addCr();
    this.np.objectStatus = ObjectStatus.NEW;
    this.np.commissionRates = this.crs;
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
  }

}
