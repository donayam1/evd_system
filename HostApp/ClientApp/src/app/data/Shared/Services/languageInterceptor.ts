import { Injectable, Injector, Inject } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieOAuthStorage } from '../../Account/Services/CookieOauthStorage';

@Injectable()
export class LanguageInterceptor implements HttpInterceptor {
  constructor(private injector: Injector) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const cookie = this.injector.get(CookieOAuthStorage);
    const culture = cookie.getLanguage();
    request = request.clone({
      setHeaders: {
        'culture': ` ${culture.shortCode}`,
      }
    });
    return next.handle(request);
  }
}
