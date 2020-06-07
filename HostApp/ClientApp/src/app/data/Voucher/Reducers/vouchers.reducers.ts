import { Voucher } from '../Models/voucherUpload.models';
import { VoucherActionTypes, VOUCHER_SELECTED_ACTION, VoucherSelectedAction } from '../Actions/vouchers.actions';
import { createFeatureSelector, createSelector } from '@ngrx/store';


export class VoucherState {
    vouchers: Voucher[];
    currentVoucher: Voucher;
}

const initVoucherState = {
    vouchers: Array(),
    currentVoucher: null
};

export function VoucherReducers(state: VoucherState = initVoucherState,
    action: VoucherActionTypes): VoucherState {

    switch (action.type) {
        case VOUCHER_SELECTED_ACTION:
            const act = <VoucherSelectedAction>action;
            return { ...state, currentVoucher: act.payload };
        default:
            return state;
    }
}

const SelectVoucherState = createFeatureSelector("vouchers");

export const SelectCurrentVoucher = createSelector(
    SelectVoucherState,
    (state: VoucherState) => state.currentVoucher
);

