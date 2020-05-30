import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RetailerPlanResponse } from '../Models/retailer-plan.model';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class RetailerPlanService {

  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchRetailerPlan():Observable<RetailerPlanResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api;
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
  }
}
