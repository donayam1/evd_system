import { Action } from '@ngrx/store';
import { User, CurrentUser } from '../Models/user.model';
import { LogInModel } from '../Models/login.model';
import { Error } from '../../Shared/Models/error.model';

export const LOGIN_ACTION = '[Account] Login';
export const LOGIN_SUCCESS_ACTION = '[Account] Login success';
export const LOGIN_FAILURE_ACTION = '[Account] Login failer';
export const LOGOUT_ACTION = '[Account] Logout';

export const LOAD_USERS_PROFILE_ACTION = '[Account] Load users profile';
export const USER_PROFILE_LOADED_ACTION = '[Account] Users profile loadded';

export class LoadUserProfilesAction implements Action {
    type: string;
    payload: string[];
    constructor(payload: string[]) {
        this.type = LOAD_USERS_PROFILE_ACTION;
        this.payload = payload;
    }
}
export class UserProfileLoaddedAction implements Action {
    type: string;
    payload: User[]
    constructor(payload: User[]) {
        this.type = USER_PROFILE_LOADED_ACTION;
        this.payload = payload;
    }
}

export class LoginSuccessAction implements Action {
    type: string;
    payload: CurrentUser;
    constructor(payload: CurrentUser) {
        this.type = LOGIN_SUCCESS_ACTION;
        this.payload = payload;
    }
}
export class LoginFailureAction implements Action {
    type: string;
    payload: Error;
    constructor(payload: Error) {
        this.type = LOGIN_FAILURE_ACTION;
        this.payload = payload;
    }
}

export class LoginAction implements Action {
    type: string;
    payload: User;
    constructor(payload: LogInModel) {
        this.type = LOGIN_ACTION;
        this.payload = payload;
    }
}

export class LogoutAction implements Action {
    type: string;
    constructor() {
        this.type = LOGOUT_ACTION;
    }

}

export type AccountActionTypes = LoginAction | LogoutAction |
    LoginSuccessAction | UserProfileLoaddedAction | LoadUserProfilesAction;