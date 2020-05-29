import { IItemResolver } from './IItemResolver';
import { Injectable } from '@angular/core';
import { Observable, of, concat } from 'rxjs';
import { Resource } from '../Models/Network/Resource';
import { SearchIndex } from '../../Search/Models/search.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppConfig } from '../../Configs/Services/app.config';
import { State, Store } from '@ngrx/store';
import { ItemResolversState, SelectSearchIndexForItem } from '../Reducers/itemResolver.reducers';
import { SearchIndexLoadedAction } from '../Actions/itemResoovler.actions';



@Injectable({
    "providedIn": 'root'
})
export class RemoteItemResolver implements IItemResolver {

    type = 0;
    constructor(private http: HttpClient,
        private state: State<ItemResolversState>,
        private store: Store<ItemResolversState>) {

    }


    GetById(id: string, type: number): Observable<Resource<SearchIndex>> {



        const url = AppConfig.settings.apiServers.authServer + "/api/itemresolvers/ItemResolver";
        const item = SelectSearchIndexForItem(this.state.value)(id, type);
        if (item == null) {
            const obs = Observable.create(observer => {

                const options = {
                    params: new HttpParams()
                        .set("itemId", id)
                        .set("itemType", type + "")
                };
                this.http.get(url, options).subscribe(res => {
                    const res0 = new SearchIndex(res);
                    const actc = new SearchIndexLoadedAction(res0);
                    this.store.dispatch(actc);

                    observer.next(Resource.Success<SearchIndex>(res0));
                }, error => {
                    observer.next(Resource.Error<SearchIndex>(error));
                });
            });

            return concat(of(Resource.Loading<SearchIndex>()), obs);
        } else {
            return of(Resource.Success<SearchIndex>(item));
        }


    }

}
