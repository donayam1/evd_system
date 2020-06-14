import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AirTimeResponse } from "../Models/airtime.models";
import { AppConfig } from '../../Configs/Services/app.config';


@Injectable({
    providedIn: 'root'
})
export class AirTimeService {

    constructor(private http: HttpClient) {

    }


    fetchOperator(): Observable<AirTimeResponse> {
        const url = AppConfig.settings.apiServers.authServer + "/api/accounting/AirTime" ;
         return new Observable(observer => {
           this.http.get<AirTimeResponse>(url).subscribe(data => {
             const response = new AirTimeResponse(data);
             observer.next(response);
             observer.complete();
           }, error => {
             observer.error(error);
             observer.complete();
           });
         });
      }
}
