import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from "@angular/router";
// import { AuthService } from '../data/Account/Services/account.service';
import { State } from "@ngrx/store";
import { AccountState } from "../data/Account/Reducers/account.reducers";
import { SelectIsAuthenticated } from "../data/app.state";
@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate {
  constructor(
    // private authService: AuthService,
    private state: State<AccountState>,
    private router: Router
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const isLoggedIn = true; //SelectIsAuthenticated(this.state.value);
    if (isLoggedIn) {
      return true;
    }
    this.router.navigateByUrl("/login");
    return false;
  }
}
