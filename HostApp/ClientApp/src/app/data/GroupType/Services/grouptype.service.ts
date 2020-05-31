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

  getGroupType(id: String): Observable<GroupTypeResponse>{
    let groupTypeResponse: GroupTypeResponse = new GroupTypeResponse();
    let gt = new GroupType({
      id: '12',
      name: 'Admin',
      level: 2,
      status: 'active'
    });
    groupTypeResponse.groupType = gt;
    groupTypeResponse.status = true;
    console.log(groupTypeResponse)
    return of(groupTypeResponse);
  }

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

  saveGroupTypes(grouptypes: GroupType[]): Observable<GroupTypesResponse> {
    const url = AppConfig.settings.apiServers.authServer + this.url;
    return new Observable(observer => {
      this.http.post<GroupTypesResponse>(url, grouptypes).subscribe(res => {
        const response = new GroupTypesResponse(res);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });

    // let groupTypesResponse = new GroupTypesResponse();
    // groupTypesResponse.status = true;
    // let mes = new Message();
    // mes.messageCode = '30';
    // mes.messageType = 20;
    // mes.systemMessage = 'working';
    // groupTypesResponse.messages.push(mes);

    // let gt = new GroupType([{id: 1, name: "ethioTel", level: 100, status: "active"}]);
    // groupTypesResponse.grouptypes = gt;
    
    // groupTypesResponse.status = false;

    //return of(groupTypesResponse);

    //return this.http.post<any>(url, grouptypes);
  }

  updateGroupType(grouptype: GroupType): Observable<any>{
    return this.http.post<any>(this.url, grouptype);
  }

}
