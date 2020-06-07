import { Action } from '@ngrx/store';
import { Voucher } from '../Models/voucherUpload.models';


export const VOUCHER_SELECTED_ACTION = "[Voucher] Selected";



export class VoucherSelectedAction implements Action {
    type:string;
    payload:Voucher;
    constructor(payload:Voucher){
        this.type = VOUCHER_SELECTED_ACTION;
        this.payload = payload;
    }
}


export type VoucherActionTypes = VoucherSelectedAction;
