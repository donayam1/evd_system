import { Bank } from "../Models/configure-bank.model";
import { BankActions, SELECT_BANK_ACTION } from "../Actions/configure-bank.actions";
import { createFeatureSelector, createSelector } from "@ngrx/store";

export class BankState{
    bank: Bank;
}

const initBankState = { bank: null };

export function BankReducers(state: BankState = initBankState, action: BankActions):BankState{
    switch(action.type){
        case SELECT_BANK_ACTION:
            return{...state, bank: action.payload};
        default:
            return state;
    }
}

export const selectBankState = createFeatureSelector<BankState>('banks');
export const selectCurrentBankState = createSelector(
    selectBankState,
    (state: BankState) => state.bank
);