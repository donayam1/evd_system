import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Router, ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from '../../Account/Services/account.service';


@Injectable({
    providedIn:'root'
})
export class HttpErrorInterceptor implements HttpInterceptor
{
    constructor(private router:Router,
        private accountServie:AuthService//,
        // private route:ActivatedRoute
        ){
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

     return  next.handle(req)
        .pipe(
            map((x:HttpEvent<any>)=>{
              return x;
            }),catchError((err:HttpErrorResponse) => {
                if(err.status === 401 ) //anauthorized 
                {
                    const route = this.router.url;// this.route.snapshot.url;
                    // console.log(route);
                    this.accountServie.logout();
                    this.router.navigate(['/login'],{queryParams:{returnUrl:route}});
                }
                return throwError(err);// Observable.throw(err);
            })
        )
    }
}