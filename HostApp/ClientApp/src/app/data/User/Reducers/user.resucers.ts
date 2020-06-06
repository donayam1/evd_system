import { Users } from "../Models/user.model";
import { UserActions, SELECT_USER_ACTION } from "../Actions/user.actions";
import { createFeatureSelector, createSelector } from "@ngrx/store";

export class UserState {
    user: Users;
}

const initUserState = {
    user : null
}

export function UserReducers(state : UserState = initUserState , action: UserActions): UserState{
    switch(action.type) {
        case SELECT_USER_ACTION:
            return {...state , user: action.paylod};
        default:
            return state; 
    }
}

export const SelectUserState = createFeatureSelector<UserState>("users");
export const SelectCurrentUser = createSelector(
    SelectUserState,
    (state: UserState)=>state.user
);