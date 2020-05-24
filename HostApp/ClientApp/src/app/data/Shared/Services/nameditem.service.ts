import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { NamedItem } from '../Models/nameditem.model';
import { NamedOwnedItem, OwnerItem } from '../Models/oweneditem.model';




@Injectable({
  providedIn: 'root'
})
export class NamedItemService {
  constructor(private http: HttpClient) {
  }

  listNamedItems(apiUrl: string): Observable<NamedItem[]> {
    const obser = Observable.create((observer) => {
      this.http.get<NamedItem[]>(apiUrl).subscribe((data) => {
        const shows = data.map(x => {
          return new NamedItem(x);
        })
        observer.next(shows);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    return obser;
  }

  listNamedOwnedItems(apiUrl: string, owner: NamedItem): Observable<NamedOwnedItem[]> {
    const obser = Observable.create((observer) => {
      const options = {
        params: new HttpParams()
          .set("OwnerId", owner.id)
          .set("OwnerType", "600")
      };

      this.http.get<NamedOwnedItem[]>(apiUrl, options).subscribe((data) => {
        const shows = data.map(x => {
          return new NamedOwnedItem(x);
        })
        observer.next(shows);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    return obser;
  }

  createNamedItem(namedItem: NamedItem, apiUrl: string): Observable<NamedItem> {
    const obser = Observable.create((observer) => {
      this.http.post<NamedItem>(apiUrl, namedItem).subscribe((data) => {
        observer.next(new NamedItem(data));
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    return obser;
  }

  createNamedOwnedItem(namedItem: NamedOwnedItem, apiUrl: string): Observable<NamedOwnedItem> {
    const obser = Observable.create((observer) => {
      this.http.post<NamedOwnedItem>(apiUrl, namedItem).subscribe((data) => {
        observer.next(new NamedOwnedItem(data));
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
    return obser;
  }
}
