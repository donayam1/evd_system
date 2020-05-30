import { Observable } from 'rxjs';
import { SearchResult, SearchModel, SearchIndex } from '../Models/search.model';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagingModel } from '../../Shared/Pagging/Models/pagging.models';
import { AppConfig } from '../../Configs/Services/app.config';

const searchApiUrl = "/api/search"; "https://localhost:44395/api/search";

@Injectable(
  {
    providedIn: 'root'
  }
)
export class SearchService {
  // private http:HttpClient
  constructor(private http: HttpClient) {

  }

  // searchText: string;
  // searchItem: number;
  // culture: string;
  // currentPage: number;
  // itemsPerPage: number;

  Search(request: SearchModel): Observable<SearchResult> {
    const sUrl = AppConfig.settings.apiServers.authServer + searchApiUrl;
    let obs = Observable.create((observer) => {
      const options = {
        params: new HttpParams()
          .set("SearchText", request.searchText)
          .set("SearchItem", request.searchItem.toString())
          .set("Culture", request.culture.toString())
          .set("ItemsPerPage", request.pagingModel.itemsPerPage.toString())
          .set("CurrentPage", request.pagingModel.currentPage.toString())
      };
      this.http.get(sUrl, options).subscribe(
        (response: Response) => {
          //console.log(response);
          var res: SearchResult = new SearchResult(response);
          let sis: SearchIndex[] = (<any>response).results.map((res) => new SearchIndex(res));
          let pm: PagingModel = new PagingModel((<any>response).pagingModel);

          res.results = sis;
          res.pagingModel = pm;

          observer.next(res);
          observer.complete();
        },
        error => {
          observer.error(error);
          observer.complete();
        }
      );
    });
    return obs;
  }

}
