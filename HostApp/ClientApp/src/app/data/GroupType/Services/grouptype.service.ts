import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { GroupType, GroupTypesResponse, GroupTypeResponse } from "../Models/grouptype..models";
import { of, Observable } from "rxjs";
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from "../../Shared/Models/responseBase";

@Injectable({
  providedIn: "root",
})
export class GrouptypeService {
  private readonly url = "/api/roles/roleTypes";

  constructor(private http: HttpClient) {}

  
  fetchGroupType(): Observable<GroupTypesResponse>{
    const url =  AppConfig.settings.apiServers.authServer + this.url;
    const observer = Observable.create(observer=>{
        this.http.get<GroupTypesResponse>(url).subscribe(data=>{
          const response = new GroupTypesResponse(data);
          observer.next(response);
          observer.complete();
        },error=>{
          observer.error(error);
          observer.complete();
        });
    })
     return observer;
  }

  saveGroupTypes(grouptypes: GroupType[]): Observable<any> {
    let groupTypesResponse = new GroupTypesResponse();
    groupTypesResponse.status = true;
    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 20;
    mes.systemMessage = 'working';
    groupTypesResponse.messages.push(mes);

    let gt = new GroupType([{id: 1, name: "ethioTel", level: 100, status: "active"}]);
    groupTypesResponse.grouptypes = gt;
    
    // groupTypesResponse.status = false;

    return of(groupTypesResponse);

      //return this.http.post<any>(this.url, grouptypes);
  }

  updateGroupType(grouptype: GroupType): Observable<any>{
    return this.http.post<any>(this.url, grouptype);
  }

}
