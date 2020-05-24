import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationEventService {
  isUserLoggedIn:Boolean = false;
  private authenticationEvent = new Subject<Boolean>();

  authSource$ = this.authenticationEvent.asObservable();

  constructor() { 
    this.authSource$.subscribe(res=>{
      this.isUserLoggedIn = res;
    });
  }

   anounceAuth(ratting:Boolean)
   {
     this.authenticationEvent.next(ratting);
   }
}
