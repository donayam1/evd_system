import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { Operator, ListOperatorResponse, NewOperatorResponse } from "../Models/operator.model";
import { HttpClient } from "@angular/common/http";
import { AppConfig } from '../../Configs/Services/app.config';


@Injectable({
  providedIn: "root",
})
export class OperatorService {
  private readonly url = "/api/operators/operator";

  constructor(private http: HttpClient) { }

  getOperator(id: String) {
    const operatorResponse: NewOperatorResponse = new NewOperatorResponse();
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

  fetchOperator(): Observable<ListOperatorResponse> {
    const ListOpResponse: ListOperatorResponse = new ListOperatorResponse();
    const operator = new Operator({
      id: '1',
      name: "ethioTel",
      uSSDRechargeCode: '*805#',
      lastUpdatedDate: '6/1/2020',
      status: 'active',
    });
    const op :Operator[] = Array();
    op.push(operator);
    ListOpResponse.operators = op;
    return of(ListOpResponse);
    //const url = AppConfig.settings.apiServers.authServer + this.url + "/list";
    // return new Observable(observer => {
    //   this.http.get<ListOperatorResponse>(url).subscribe(data => {
    //     const response = new ListOperatorResponse(data);
    //     observer.next(response);
    //     observer.complete();
    //   }, error => {
    //     observer.error(error);
    //     observer.complete();
    //   });
    // });
  }

  saveOperator(operator: Operator): Observable<NewOperatorResponse> {
    const rurl = AppConfig.settings.apiServers.authServer + this.url + "/Create";
    return new Observable(observer => {
      this.http.post<NewOperatorResponse>(rurl, operator).subscribe(x => {
        observer.next(new NewOperatorResponse(x));
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    // return this.http.post<any>(this.url, operator);
  }
}
