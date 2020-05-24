import { Component, OnInit } from "@angular/core";
import { CurrentUser } from "../../data/Account/Models/user.model";
import { AuthService } from "../../data/Account/Services/account.service";
import { Store } from "@ngrx/store";
import { AccountState } from "../../data/Account/Reducers/account.reducers";
import { SelectIsAuthenticated } from '../../data/app.state';

@Component({
  selector: "app-signin",
  templateUrl: "./signin.component.html",
  styleUrls: ["./signin.component.css"]
})
export class SigninComponent implements OnInit {
  isUserLoggedIn: Boolean = false;
  name: string;
  user: CurrentUser;
  registerUrl: string = "https://localhost:44334/Account/register";

  constructor(private authService: AuthService,
    private store:Store<AccountState>) {}

  ngOnInit() {

    this.isUserLoggedIn = this.authService.isLoggedIn();
    // this.authService.isLoggedIn().subscribe(logStatus => {
    //   this.isUserLoggedIn = logStatus;
    // });
    this.authService.getCurrentUser().subscribe(user => {
      this.user = user;
    });
  }

  logout() {
    this.authService.logout();
  }
  register(event) {
    // let returnUrl="";//window.location.origin.concat(this.router.url)  ;
    // let registerUrl=this.registerUrl+"?returnUrl="+encodeURI(returnUrl);
    // this.router.navigate(['/externalRedirect',{externalUrl:registerUrl}],{
    //   skipLocationChange:true,
    // });
    // event.preventDefault();
  }
}
