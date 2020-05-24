import { Injectable, OnInit } from '@angular/core';
import { OAuthService, JwksValidationHandler, AuthConfig } from 'angular-oauth2-oidc';
import { LogInModel } from "../Models/login.model";
import { CurrentUser, User } from "../Models/user.model";
import { Observable, Subject } from 'rxjs';
import * as AuthConfigs from "./auth.config";
import {
  AppState,
  SelectIsAuthenticated,
  CurrentUserSelector,
  FiterUsersNotInStoreSelector
} from "../../app.state";
import { Store, State } from "@ngrx/store";
import {
  LoginSuccessAction,
  LogoutAction,
  LoginFailureAction
} from "..//Actions/account.actions";
import { CookieOAuthStorage } from "./CookieOauthStorage";
import { HttpParams, HttpClient } from "@angular/common/http";
import { UserProfileLoaddedAction } from "../Actions/account.actions";
import { Router } from "@angular/router";
import { AppConfig } from '../../Configs/Services/app.config';

const userProfileServieUrl: string =
  "/api/users/userinfo";

// {
//   providedIn: "root"
// }

@Injectable({
  providedIn: 'root'
}
)
export class AuthService {

  isUserLoggedIn: boolean;
  constructor(
    private oauthService: OAuthService,
    private cookieOAuthStorage: CookieOAuthStorage,
    private store: Store<AppState>,
    private state: State<AppState>,
    private http: HttpClient,
    private router: Router
  ) {
  }



  OnInit(): void {
    //.oauthService.configure(<AuthConfig>AppConfig.settings.authSettings );
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    //this.oauthService.loadDiscoveryDocument();

    if (this.cookieOAuthStorage.getAccessToken()) {
      const user = this.cookieOAuthStorage.getUser();
      this.loggedIn(user);
    } else {
      const that = this;
      setTimeout(function fireEvent() {
        that.store.dispatch(new LoginFailureAction({ error: "" }));
      }, 1000);
    }
  }

  isLoggedIn(): boolean {
    const isLoggedIn =  SelectIsAuthenticated(this.state.value);
    return isLoggedIn;
    // const obser = Observable.create(observer => {
    //   this.store.subscribe((state: AppState) => {
    //     // let user = CurrentUserSelector(state);
    //     this.isUserLoggedIn = LoginStatusSelector(state);
    //     observer.next(this.isUserLoggedIn);
    //   });
    // });
    // return obser;
  }
  getCurrentUser(): Observable<CurrentUser> {
    const obser = Observable.create(observer => {
      this.store.subscribe((state: AppState) => {
        const user = CurrentUserSelector(state);
        observer.next(user);
      });
    });
    return obser;
  }
  private _login(user: LogInModel, observer: any) {
    this.oauthService
      .fetchTokenUsingPasswordFlowAndLoadUserProfile(
        user.UserName,
        user.Password
      )
      .then((data: any) => {
        const ic = this.oauthService.getIdentityClaims();
        console.log(ic);
        const userName = this.oauthService.getIdentityClaims()["given_name"];
        const profilePicUrl =
          this.oauthService.getIdentityClaims()["ProfilePicUrl"] ||
          "assets/images/user.jpg";
        const tok = this.oauthService.getAccessToken();
        const user0 = new CurrentUser({
          UserName: userName,
          PicUrl: profilePicUrl,
          Id: data.sub,
          Token: tok
        });
        observer.next(user0);
        observer.complete();
      })
      .catch(error => {
        console.log("Error Logging in " + error);
        observer.error("User name or password is not correct");
        observer.complete();
      });
  }

  login(user: LogInModel): Observable<any> {
    const observable = Observable.create(observer => {
      this.oauthService.configure(<AuthConfig>AppConfig.settings.authSettings);
      // this.oauthService.loadDiscoveryDocument();
      if (!this.oauthService.discoveryDocumentLoaded) {
        this.oauthService.loadDiscoveryDocument().then((results) => {
          this._login(user, observer);
        }).catch((error) => {
          observer.error("Accounts server not found");
        });
      } else {
        this._login(user, observer);
      }
    });
    return observable;
  }
  logout() {
    this.oauthService.logOut();
    this.cookieOAuthStorage.cleanSessionData();
    this.store.dispatch(new LogoutAction());
  }
  loggedIn(user: CurrentUser, returnUrl?: string) {
    console.log(user);
    this.cookieOAuthStorage.saveUser(user);
    this.store.dispatch(new LoginSuccessAction(user));
    this.store.dispatch(new UserProfileLoaddedAction([user]));
    if (returnUrl != null) {
      this.router.navigateByUrl(returnUrl);
    }
  }
  loadUsersProfile(users: string[]) {
    const upUrl = AppConfig.settings.apiServers.authServer + userProfileServieUrl;
    let z = FiterUsersNotInStoreSelector(this.state.value)(users); //cache
    if (z.length <= 0) {
      return;
    }
    const options = {
      params: new HttpParams().set("Subs", z.join(","))
    };
    this.http
      .get(upUrl, options)
      .subscribe((response: Response) => {
        const users0: User[] = (<any>response).map(item => {
          return new User(item);
        });
        this.store.dispatch(new UserProfileLoaddedAction(users0));
      }, error => {

      });
  }
}
