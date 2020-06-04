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
    // const url =  AppConfig.settings.apiServers.authServer + this.url;
    // const observer = Observable.create(observer=>{
    //     this.http.get<GroupTypesResponse>(url).subscribe(data=>{
    //       const response = new GroupTypesResponse(data);
    //       observer.next(response);
    //       observer.complete();
    //     },error=>{
    //       observer.error(error);
    //       observer.complete();
    //     });
    // })
    //  return observer;
    let groupTypesResponse = new GroupTypesResponse();
    groupTypesResponse.status = true;

    let gt = new GroupType({
      id: "1", name: "ethioTel", level: 100, status: "active"});

      let gt1 = new GroupType({
        id: "2", name: "tack", level: 1, status: "active"});

    const gpt :GroupType[] = Array();
    gpt.push(gt,gt1);
    groupTypesResponse.groupTypes = gpt
    

    return of(groupTypesResponse);
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

    

   
  }

  updateGroupType(grouptype: GroupType): Observable<any>{
    return this.http.post<any>(this.url, grouptype);
  }

}
