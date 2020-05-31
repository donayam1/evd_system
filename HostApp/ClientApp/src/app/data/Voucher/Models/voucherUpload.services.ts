import { ResponseBase } from '../../Shared/Models/responseBase';
import { PagedItemResponseBase } from '../../Shared/Models/PagedItemResponseBase';

export class UploadVoucherResponse extends ResponseBase {
    constructor(obj?: any) {
        super(obj);
    }
}

export class Voucher{
    constructor(obj? : any){
        this.id = obj && obj.id;
        this.serialNumber = obj && obj.serialNumber;
        this.pinNumber = obj && obj.pinNumber;
        this.stopDate = obj && obj.stopDate;
        this.denomination = obj && obj.denomination;
        this.voucherStatus = obj && obj.voucherStatus;
    }

    id: number;
    serialNumber: number;
    pinNumber : number;
    stopDate : string;
    denomination : number;
    voucherStatus: number;     

} 


export class ListVoucherResponse extends PagedItemResponseBase {
    constructor(obj? : any) {
        super(obj);
        this.vouchers = obj && obj.vouchers.map(v => new Voucher(v))
    }

    vouchers:Voucher[];

 
}
