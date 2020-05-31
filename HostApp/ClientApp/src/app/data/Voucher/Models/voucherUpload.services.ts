import { ResponseBase } from '../../Shared/Models/responseBase';

export class UploadVoucherResponse extends ResponseBase {
    constructor(obj?: any) {
        super(obj);
    }
}

export class Voucher{



    id: number;
    serialNumber: number;
    pinNumber : number;
    stopDate : string;
    denomination : number;
    voucherStatus: number;     

} 


export class ListVoucherResponse extends ResponseBase {
    constructor(obj? : any) {
        super(obj);
    }

    vouchers:Voucher[];

 
}
