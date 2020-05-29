import { Component, OnInit } from '@angular/core';
// import { OAuthService } from 'angular-oauth2-oidc'
// import { LogInModel} from './LoginModel';
// import { AuthenticationEventService } from '../authentication-event.service';
// import { Router } from '@angular/router';
import { AppState, AccountErrorMessageSelector } from '../../data/app.state';
import { Store } from '@ngrx/store';
import { LogInModel } from '../../data/Account/Models/login.model';
import { LoginFailureAction } from '../../data/Account/Actions/account.actions';
import { AuthService } from '../../data/Account/Services/account.service';
// import { User } from '../../shared/data/Account/Models/user.model';
import { AppConfig } from '../../data/Configs/Services/app.config';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  model: LogInModel = new LogInModel();
  loginErrorMessage: string;
  // isDisabled: boolean = false;


  returnUrl: string;
  sub: any;
  isLoading: boolean;
  registerUrl = "/account/register";
  forgotPassword = "/Account/ForgotPassword";

  // private oauthService: OAuthService,
  // private authenticationevt: AuthenticationEventService,
  // private router: Router,
  // this.authenticationevt.authSource$.subscribe(res => {
  //   this.userLoggedIn(res);
  // });

  constructor(private store: Store<AppState>,
    private authService: AuthService//,private router:Router
  ) {

  }

  ngOnInit() {
    this.store.subscribe((state: AppState) => {
      this.loginErrorMessage = AccountErrorMessageSelector(state);
    });
  }
  login() {
    // this.store.dispatch(new LoginAction(this.model));
     this.isLoading = true;
    this.authService.login(this.model).subscribe((user) => {

       this.isLoading = false;
      this.authService.loggedIn(user, '/home');
      // this.router.navigateByUrl('/');
    }, error => {
      this.isLoading = false;
      console.log(error);
      this.store.dispatch(new LoginFailureAction({ error: error }));
    });
    // .map((user: User) => {
    //   console.log(user);
    //   this.store.dispatch(new LoginSuccessAction(user));
    // })
    // .catch(error => {
    //   console.log(error);
    //   this.store.dispatch(new LoginFailureAction({ error: error }));
    //   return null;
    // });


  }
  register(event?: any) {
    // let returnUrl="";//window.location.origin.concat(this.router.url)  ;
    const registerUrl = AppConfig.settings.apiServers.authServer + this.registerUrl + "?returnUrl=" +
      encodeURIComponent(AppConfig.settings.apiServers.authServer);

    document.location.href = registerUrl;
    // this.router.navigate(['/externalRedirect',{externalUrl:registerUrl}],{
    //   skipLocationChange:true,
    // });
    // event.preventDefault();
    return true;
  }
  resetPassword() {
    const registerUrl = AppConfig.settings.apiServers.authServer + this.forgotPassword + "?returnUrl=" +
    encodeURIComponent(AppConfig.settings.apiServers.authServer);

    document.location.href = registerUrl;
    return true;
  }
}
