import { CurrentUser, User } from '../Models/user.model';
import { AccountActionTypes, LoginAction,
     LoginFailureAction, LoginSuccessAction, 
     LogoutAction, USER_PROFILE_LOADED_ACTION, UserProfileLoaddedAction } from '../Actions/account.actions';
import { LOGIN_ACTION, LOGOUT_ACTION, LOGIN_SUCCESS_ACTION, LOGIN_FAILURE_ACTION } from '../Actions/account.actions';
import { createSelector, createFeatureSelector } from '@ngrx/store';
import { AppReducers } from '../../app.state';

export class AccountState {
    isAuthenticated: boolean;
    currentUser: CurrentUser;
    errorMessage: string;
    users: User[];
}

const initAccountState: AccountState = {
    currentUser: new CurrentUser(), isAuthenticated: false, errorMessage: "", users: []
};

export function AccountReducer(
    state: AccountState = initAccountState,
    action: AccountActionTypes
): AccountState {
    switch (action.type) {
        case LOGIN_SUCCESS_ACTION:
            const la = <LoginSuccessAction>action;
            return { ...state, isAuthenticated: true, currentUser: la.payload };
        case LOGOUT_ACTION:
            return initAccountState;
        case LOGIN_FAILURE_ACTION:
            const laf = <LoginFailureAction>action;
            return { ...state, errorMessage: laf.payload.error };
        case USER_PROFILE_LOADED_ACTION:
            const ups = (<UserProfileLoaddedAction>action).payload;
            return { ...state, users: [...state.users, ...ups] }
        default:
            return state;
    }
}

// export const SelectOrgState = createFeatureSelector<AppReducers>('orgs');
// export const SelectCurrentOrg = createSelector(
//     SelectOrgState,
//     (state: OrganizationState) => state.currentOrg);
