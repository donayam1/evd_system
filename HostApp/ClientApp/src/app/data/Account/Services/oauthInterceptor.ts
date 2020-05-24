import { Injectable, Injector, Inject } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/throw'
import 'rxjs/add/operator/catch';
import { AuthService } from './account.service';
import {OAuthService} from 'angular-oauth2-oidc';
// @Injectable()
// export class MyHttpInterceptor implements HttpInterceptor {
//      //private accountService:AuthService
//     constructor(
//          //private injector:Injector
//         private accountService:AuthService 
//     ) { 
//     }

    

//     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

//         console.log("intercepted request ... ");
//          //this.accountService= <AuthService>this.injector.get(AuthService);
//         // Clone the request to add the new header.
//         var id_token= this.accountService.getToken();
//         const tokenValue = 'Bearer ' + id_token;
//         // this.headers = this.headers.set('Authorization', tokenValue);
//         const authReq = req.clone( { setHeaders:{"Authorization": tokenValue}  });//headers: req.headers.set("Authorization", tokenValue)

//         console.log("Sending request with new header now ...");

//         //send the newly created request
//         return next.handle(authReq)
//             .catch((error, caught) => {
//                 //intercept the respons error and displace it to the console
//                 console.log("Error Occurred");
//                 console.log(error);
//                 //return the error to the method that called it
//                 return Observable.throw(error);
//             }) as any;
//     }

// }

// @Injectable()
// export class MyHttpInterceptor implements HttpInterceptor {
//   private authService: AuthService;
//   constructor(private injector: Injector) {}
//   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     let oauthService = this.injector.get(OAuthService);
//     this.authService = new AuthService(oauthService); //this.injector.get(AuthService);
//     const token: string = this.authService.getToken();
//     request = request.clone({
//       setHeaders: {
//         'Authorization': `Bearer ${token}`,
//         'Content-Type': 'application/json'
//       }
//     });
//     return next.handle(request);
//   }
// }