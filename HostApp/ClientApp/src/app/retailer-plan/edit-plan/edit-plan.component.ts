import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';
import { NewPlan } from './../../data/RetailerPlan/Models/retailer-plan.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MessageComponent } from 'src/app/messages/message/message.component';

@Component({
  selector: 'app-edit-plan',
  templateUrl: './edit-plan.component.html',
  styleUrls: ['./edit-plan.component.css']
})
export class EditPlanComponent implements OnInit {
  np: NewPlan;
  commissionType: Array<string>;
  renewalRate: Array<string>;
  selectedType: string;
  selectedRate: string;

  @ViewChild('messages', {static: true})
  messageComponent: MessageComponent;

  constructor(private retailerPlanService: RetailerPlanService) {
    this.np = new NewPlan();
    this.commissionType = ['Flat Commission', 'Per-recharge Commission'];
    this.renewalRate = ['Per Day', 'Per Week', 'Per Month', 'Per Year'];
  }

  updatePlan(){
    this.retailerPlanService.createRetailerPlan(this.np).subscribe(x => {
      this.messageComponent.addMessages(x);
      if(x.status === true){
      }
    }, err => {});
  }

  ngOnInit() {
    this.retailerPlanService.getRetailerPlan('1').subscribe(x => {
      this.messageComponent.addMessages(x);
      if(x.status === true){
        if(x.newRetailerPlan.renewalAmountChargingRate === 1){
          this.selectedRate = 'Per Day';
        }
        else if(x.newRetailerPlan.renewalAmountChargingRate === 2){
          this.selectedRate = 'Per Week';
        }
        else if(x.newRetailerPlan.renewalAmountChargingRate === 3){
          this.selectedRate = 'Per Month';
        }
        else if(x.newRetailerPlan.renewalAmountChargingRate === 4){
          this.selectedRate = 'Per Year';
        }

        if(x.newRetailerPlan.commisionRateType === 1){
          this.selectedType = 'Flat Commission';
        }

        else if(x.newRetailerPlan.commisionRateType === 2){
          this.selectedType = 'Per-recharge Commission';
        }

        this.np = x.newRetailerPlan;
      }
    }, err =>{});
  }

}
