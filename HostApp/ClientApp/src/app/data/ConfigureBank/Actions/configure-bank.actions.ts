import { Action } from '@ngrx/store';
import { Bank } from '../Models/configure-bank.model';
export const SELECT_BANK_ACTION = "[BANK] edit";

export class SelectBankAction implements Action{
    type: string;
    payload: Bank;
    constructor(payload: Bank){
        this.type = SELECT_BANK_ACTION;
        this.payload = payload;
    }
}

export type BankActions = SelectBankAction;