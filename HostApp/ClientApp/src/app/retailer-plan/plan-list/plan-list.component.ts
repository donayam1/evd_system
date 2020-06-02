import { Component, OnInit } from '@angular/core';
import { RetailerPlanResponse } from 'src/app/data/RetailerPlan/Models/retailer-plan.model';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';

@Component({
  selector: 'app-plan-list',
  templateUrl: './plan-list.component.html',
  styleUrls: ['./plan-list.component.css']
})
export class PlanListComponent implements OnInit {
  response : RetailerPlanResponse;

  constructor(private retailerPlanService: RetailerPlanService) {
    this.response = new RetailerPlanResponse();
   }

  ngOnInit() {
    this.retailerPlanService.fetchRetailerPlan().subscribe((data : RetailerPlanResponse)=>{
    this.response = data;
    console.log(this.response)
  })
} 

}
