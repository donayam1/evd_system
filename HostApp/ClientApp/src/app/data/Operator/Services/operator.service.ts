import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Operator } from "../Models/operator.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class OperatorService {
  private readonly url = "/api/operator";

  constructor(private http: HttpClient) {}

  getOperator(): Observable<Operator[]> {
    return this.http.get<Operator[]>(this.url);
  }

  saveOperator(operator: Operator): Observable<any> {
    return this.http.post<any>(this.url, operator);
  }
}
