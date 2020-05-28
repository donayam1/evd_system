import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { GroupType, GroupTypesResponse } from '../Models/grouptype..models';
import { of, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class GrouptypeService {
  private readonly url = '/api/grouptype';
  constructor(private http: HttpClient) { }

    getGroupType(): Observable<GroupTypesResponse>{

        let groupTypesResponse: GroupTypesResponse = new GroupTypesResponse();

        let types: GroupType[] = Array();
        let gt = new GroupType({id:"1",level:2});
        types.push(gt);

        groupTypesResponse.groupTypes = types;
        groupTypesResponse.status = false;

        return of(groupTypesResponse);// this.http.get<GroupType[]>(this.url);
  }

  fetchGroupType(): Observable<GroupTypesResponse>{
    return this.http.get<GroupTypesResponse>(this.url);
  }

  saveGroupTypes(grouptypes: GroupType): Observable<any> {
    return this.http.post<any>(this.url, grouptypes);
  }

  updateGroupType(grouptype: GroupType): Observable<any>{
    return this.http.post<any>(this.url, grouptype);
  }

}
