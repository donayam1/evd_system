import { BrowserModule } from "@angular/platform-browser";
import { NgModule, APP_INITIALIZER, InjectionToken } from "@angular/core";
import { FormsModule } from "@angular/forms";
import {
  HttpClientModule,
  HTTP_INTERCEPTORS,
  HttpClient,
} from "@angular/common/http";
import { RouterModule, ActivatedRouteSnapshot, Router } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { AppConfig } from "./data/Configs/Services/app.config";
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { SigninComponent } from "./authentication/signin/signin.component";
import { LoginComponent } from "./authentication/login/login.component";
import { LanguageComponent } from "./language/language.component";
import {
  OAuthModule,
  OAuthModuleConfig,
  OAuthStorage,
} from "angular-oauth2-oidc";
import { MyAuthConfig } from "./data/Configs/Services/auth.model.config";
import { CookieOAuthStorage } from "./data/Account/Services/CookieOauthStorage";
import { LanguageInterceptor } from "./data/Shared/Services/languageInterceptor";
import { HttpErrorInterceptor } from "./data/Shared/Services/httpErorResponseInterceptor";
import { AuthGuard } from "./authentication/auth-guard.service";
import { CookieService } from "ngx-cookie-service";
import { AuthService } from "./data/Account/Services/account.service";
import { LoginPageGardService } from "./authentication/login-page-gard.service";
import { NotFoundComponent } from "./not-found/not-found.component";
import { LoadingModule } from "./loading/loading.module";
import { StoreModule } from "@ngrx/store";
import { AppReducers } from "./data/app.state";
import { ItemResolverReducer } from "./data/Shared/Reducers/itemResolver.reducers";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";


import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule} from '@angular/material/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const externalUrlProvider = new InjectionToken("externalUrlRedirectResolver");

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SigninComponent,
    LoginComponent,
    LanguageComponent,
    NotFoundComponent,
   
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    FormsModule,
    LoadingModule,
    NgbDropdownModule,
    StoreModule.forRoot(AppReducers, {}),
    StoreModule.forFeature("searchIndexes", ItemResolverReducer),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
      isolate: true,
    }),
    OAuthModule.forRoot(),
    RouterModule.forRoot([
      { path: "", redirectTo: "login", pathMatch: "full" },
      // { path: "grouptype", component: ListGroupTypeComponent },
      // { path: "operator-list", component: ListOperatorComponent },
      {
        path: "home",
        loadChildren: "./admin-home/admin-home.module#AdminHomeModule",
        canActivate: [AuthGuard],
      },
      {
        path: "login",
        component: LoginComponent,
        canActivate: [LoginPageGardService],
      },
      {
        path: "externalRedirect",
        resolve: {
          url: externalUrlProvider,
        },
        component: NotFoundComponent,
      },
    ]),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [AppConfig],
      multi: true,
    },
    { provide: OAuthModuleConfig, useClass: MyAuthConfig },
    { provide: OAuthStorage, useClass: CookieOAuthStorage },
    AuthGuard,
    CookieService,
    AuthService,
    { provide: HTTP_INTERCEPTORS, useClass: LanguageInterceptor, multi: true },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true,
      deps: [Router, AuthService],
    },
    {
      provide: externalUrlProvider,
      useValue: (route: ActivatedRouteSnapshot) => {
        const externalUrl = route.paramMap.get("externalUrl");
        window.open(externalUrl, "_self");
      },
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, "/assets/i18n/app/", ".json");
}

export function initializeApp(appConfig: AppConfig) {
  return () => appConfig.load();
}
