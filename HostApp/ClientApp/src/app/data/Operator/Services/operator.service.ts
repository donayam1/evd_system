import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { Operator, OperatorResponse, Operator_Response } from "../Models/operator.model";
import { HttpClient } from "@angular/common/http";
import { AppConfig } from "../../Configs/Services/app.config";
import { error } from "util";

@Injectable({
  providedIn: "root",
})
export class OperatorService {
  private readonly url = "/api/operator";

  constructor(private http: HttpClient) {}

  getOperator(id: String){
    let operatorResponse: Operator_Response = new Operator_Response();
    let operator = new Operator({
      id: '1',
      name: "ethioTel",
      ussdCode: '*805#',
      status: 'active'
    });
    operatorResponse.operator = operator;
    operatorResponse.status = true;
    console.log(operatorResponse)
    return of(operatorResponse);
  }

  fetchOperator(): Observable<OperatorResponse> {
    const url = AppConfig.settings.apiServers.authServer + this.url;
    const observer = Observable.create(observer =>{
      this.http.get<OperatorResponse>(url).subscribe(data =>{
        const response = new OperatorResponse(data);
        observer.next(response);
        observer.complete();
      },error =>{
        observer.error(error);
        observer.complete();
      });
    })
    return observer;
  }

  saveOperator(operator: Operator): Observable<any> {
    return this.http.post<any>(this.url, operator);
  }
}
