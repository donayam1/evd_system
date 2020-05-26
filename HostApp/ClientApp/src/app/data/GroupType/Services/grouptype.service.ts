import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import {HttpClient} from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class GrouptypeService {
  private readonly url = '/api/grouptype';
  constructor(private http: HttpClient) { }

  getGroupType(){
    return this.http.get(this.url)
  }
}
