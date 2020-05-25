import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
// import { AuthService } from '../data/Account/Services/account.service';
import { State } from '@ngrx/store';
import { AccountState } from '../data/Account/Reducers/account.reducers';
import { SelectIsAuthenticated } from '../data/app.state';
import { AuthService } from '../data/Account/Services/account.service';
@Injectable({
  providedIn: 'root'
})
export class LoginPageGardService implements CanActivate {

  constructor(
    private state: State<AccountState>,
    private authService: AuthService,
    private router: Router
  ) {
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    this.authService.OnInit();
    const isLoggedIn = SelectIsAuthenticated(this.state.value);
    if (isLoggedIn) {
      this.router.navigate(["/home"]);
      return false;
    }
    return true;
  }
}
