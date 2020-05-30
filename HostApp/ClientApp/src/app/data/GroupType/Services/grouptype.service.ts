import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { GroupType, GroupTypesResponse } from "../Models/grouptype..models";
import { of, Observable } from "rxjs";
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: "root",
})
export class GrouptypeService {
  private readonly url = "/api/roles/roleTypes";

  constructor(private http: HttpClient) {}

  // getGroupType(): Observable<GroupTypesResponse> {
  //   let groupTypesResponse: GroupTypesResponse = new GroupTypesResponse();

  //   let types: GroupType[] = Array();
  //   let gt = new GroupType({
  //     id: "1",
  //     name: "new",
  //     level: 2,
  //     status: "active",
  //   });
  //   types.push(gt);

  //   groupTypesResponse.groupTypes = types;
  //   groupTypesResponse.status = false;
  //   console.log(groupTypesResponse)

  //   return of(groupTypesResponse); // this.http.get<GroupType[]>(this.url);
  // }

  fetchGroupType(): Observable<GroupTypesResponse>{
    const url =  AppConfig.settings.apiServers.authServer + this.url;
    const observer = Observable.create(observer=>{
        this.http.get<GroupTypesResponse>(url).subscribe(x=>{
          const response = new GroupTypesResponse(x);
          observer.next(response);
          observer.complete();
        },error=>{
          observer.error(error);
          observer.complete();
        });
    })
     return observer;
  }

  saveGroupTypes(grouptypes: GroupType): Observable<any> {
    let groupTypesResponse: GroupTypesResponse = new GroupTypesResponse();
    
    let gt = new GroupType({id: 1, name: "ethioTel", level: 100, status: "active"});
    groupTypesResponse.grouptype = gt;
    groupTypesResponse.status = false;

    return of(groupTypesResponse);

      //return this.http.post<any>(this.url, grouptypes);
  }

  updateGroupType(grouptype: GroupType): Observable<any>{
    return this.http.post<any>(this.url, grouptype);
  }

}
