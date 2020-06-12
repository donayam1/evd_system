import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { CreateRetailerPlanResponse, RetailerPlan } from './../Models/retailer-plan.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { RetailerPlanResponse, CommissionRate, NewPlan } from '../Models/retailer-plan.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { CreatePurchaseOrderResponse } from '../../PurchaseOrder/Model/purchase-order.model';
import { Message } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class RetailerPlanService {

  private readonly api = "/api/retailerPlans/RetailerPlan";

  constructor(private http: HttpClient) { }

  fetchRetailerPlan():Observable<RetailerPlanResponse>{

    const url = AppConfig.settings.apiServers.authServer + this.api + "/list";
    const observer = Observable.create(observer=>{
      this.http.get<RetailerPlanResponse>(url).subscribe(data =>{
        const response = new RetailerPlanResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    })
    return observer;

    // const RpResponse : RetailerPlanResponse = new RetailerPlanResponse();
    // RpResponse.status = true;
    // const retailerPlan1 = new RetailerPlan({
    //   id: '1',
    //   code: "CO1",
    //   name: "Plan One",
    //   description: "10% Benefit",
    //   joiningAmount: 1000,
    //   renwalAmount: 100,
    //   renewalAmountChargingRate: 2,
    //   commissionRateType: 2,
    //   commissionRates: [{id:"1" ,amount:1 ,rate: 5}, {id: '2', amount: 100, rate: 10}, {id: '3', amount: 1000, rate: 20}],
    //   operatorId: 1,
    //   //objectStatus: ObjectStatus.NEW
    // });
    

    // const retailerPlan : RetailerPlan[] = Array();
    // retailerPlan.push(retailerPlan1);
    // RpResponse.retailerPlans = retailerPlan;
    // return of(RpResponse);


    
  }

  getRetailerPlan(id: String){
    const rpResponse: CreateRetailerPlanResponse = new CreateRetailerPlanResponse();
    const plan = new NewPlan({
      ui_id: '8',
      id: '1',
      name: "Plan 01",
      code: 'NP.001',
      description: 'Short description',
      joiningAmount: 10000,
      renwalAmount: 1000,
      renewalAmountChargingRate: 2,
      commissionRateType: 2,
      operatorId: '4',
      objectStatus: ObjectStatus.NEW
    });
    rpResponse.newRetailerPlan = plan;
    rpResponse.status = true;
    console.log(rpResponse);
    return of(rpResponse);
  }

  createRetailerPlan(newPlan: NewPlan):Observable<CreateRetailerPlanResponse>{
    //Mock Data
    // let response = new CreateRetailerPlanResponse();
    // response.status = true;
    
    // let mes = new Message();
    // mes.messageCode = '30';
    // mes.messageType = 1;
    // mes.systemMessage = "working";
    // response.messages.push(mes);

    // let nP = new NewPlan();
    // nP.ui_id = newPlan.ui_id;
    // nP.id = '12';
    // nP.code = newPlan.code;
    // nP.name = newPlan.name;
    // nP.description = newPlan.description;
    // nP.joiningAmount = newPlan.joiningAmount;
    // nP.renwalAmount = newPlan.renwalAmount;
    // nP.renewalAmountChargingRate = newPlan.renewalAmountChargingRate;
    // nP.commisionRateType = newPlan.commisionRateType;
    // nP.commissionRates = newPlan.commissionRates;
    // nP.operatorId = '1';
    // nP.objectStatus = newPlan.objectStatus;

    // response.newRetailerPlan = nP;

    // return of(response);

    //Later to be used with the api
    console.log(newPlan);
    const url = AppConfig.settings.apiServers.authServer + this.api + '/Create';
    const observer = Observable.create(observer => {
      this.http.post<CreateRetailerPlanResponse>(url, newPlan).subscribe(result => {
        const response = new CreateRetailerPlanResponse (result);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    return observer;
  }
}
