import { Component, OnInit } from '@angular/core';
import { RetailerPlanResponse } from 'src/app/data/RetailerPlan/Models/retailer-plan.model';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';

@Component({
  selector: 'app-plan-list',
  templateUrl: './plan-list.component.html',
  styleUrls: ['./plan-list.component.css']
})
export class PlanListComponent implements OnInit {
  retailerPlans : RetailerPlanResponse;

  constructor(private retailerPlanService: RetailerPlanService) {
    this.retailerPlans = new RetailerPlanResponse();
   }

  ngOnInit() {
    this.retailerPlanService.fetchRetailerPlan().subscribe((response : RetailerPlanResponse)=>{
    this.retailerPlans = response;
    console.log(this.retailerPlans)
  })
} 

}
