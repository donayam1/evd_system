import { Action } from "@ngrx/store";
import { UserBankAccount } from "../Models/user-bank-account.model";


export const SELECT_USER_BANK_ACCOUNT_ACTION = "[USER_BANK_ACCOUNT] edit";
export class SelectUserBankAccountAction implements Action {
    type: string;
    payload: UserBankAccount;
    constructor(payload: UserBankAccount) {
        this.type = SELECT_USER_BANK_ACCOUNT_ACTION;
        this.payload = payload;
    }
}

export type UserBankAccountActions = SelectUserBankAccountAction;