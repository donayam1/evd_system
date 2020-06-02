import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { RetailerPlanResponse, RetailerPlan, CommissionRate } from '../Models/retailer-plan.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class RetailerPlanService {

  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchRetailerPlan():Observable<RetailerPlanResponse>{
    const RpResponse : RetailerPlanResponse = new RetailerPlanResponse();
    const retailerPlan1 = new RetailerPlan({
      code: "CO1",
      name: "Plan one",
      description: "10% Benefit",
      commissionRates: {id:"1" ,amount:10 ,rate: 5}
    });

    const retailerPlan : RetailerPlan[] = Array();
    retailerPlan.push(retailerPlan1);
    RpResponse.retailerPlans = retailerPlan;
    return of(RpResponse);


    // const url = AppConfig.settings.apiServers.authServer + this.api;
    // const observer = Observable.create(observer=>{
    //   this.http.get<RetailerPlanResponse>(url).subscribe(data =>{
    //     const response = new RetailerPlanResponse(data);
    //     observer.next(response);
    //     observer.complete();
    //   }, error => {
    //     observer.error(error);
    //     observer.complete();
    //   });
    // })
    // return observer;
  }
}
