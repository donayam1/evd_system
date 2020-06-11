import { UserBankAccount } from "../Models/user-bank-account.model";
import { UserBankAccountActions, SELECT_USER_BANK_ACCOUNT_ACTION } from "../Actions/userBankAccount.actions";
import { createFeatureSelector, createSelector } from "@ngrx/store";


export class UserBankAccountState {
    userBankAccount: UserBankAccount;
}

const initUserBankAccountState = {
    userBankAccount: null
}

export function UserBankAccountReducers(state: UserBankAccountState = initUserBankAccountState, action: UserBankAccountActions): UserBankAccountState {
    switch (action.type) {
        case SELECT_USER_BANK_ACCOUNT_ACTION:

            return { ...state, userBankAccount: action.payload };

        default:
            return state;
    }
}

export const SelectUserBankAccountState =
    createFeatureSelector<UserBankAccountState>("userBankAccounts");
export const SelectCurrentUserBankAccount = createSelector(
    SelectUserBankAccountState,
    (state: UserBankAccountState) => state.userBankAccount
)