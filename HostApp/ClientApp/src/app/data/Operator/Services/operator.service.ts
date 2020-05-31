import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { Operator, OperatorResponse, Operator_Response } from "../Models/operator.model";
import { HttpClient } from "@angular/common/http";
import { AppConfig } from '../../Configs/Services/app.config';
import { error } from "util";

@Injectable({
  providedIn: "root",
})
export class OperatorService {
  private readonly url = "/api/operators/operators";

  constructor(private http: HttpClient) { }

  getOperator(id: String) {
    const operatorResponse: Operator_Response = new Operator_Response();
    const operator = new Operator({
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
    return new Observable(observer => {
      this.http.get<OperatorResponse>(url).subscribe(data => {
        const response = new OperatorResponse(data);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

  saveOperator(operator: Operator): Observable<any> {
    const rurl = AppConfig.settings.apiServers.authServer + this.url;
    return new Observable(observer => {
      this.http.post<any>(rurl, operator).subscribe(x => {
        observer.next(new OperatorResponse(x));
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    // return this.http.post<any>(this.url, operator);
  }
}
