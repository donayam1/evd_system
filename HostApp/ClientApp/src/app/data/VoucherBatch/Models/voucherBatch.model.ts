import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";


export class VoucherBatch {
    constructor(obj? : any){
        this.purchaserOrderNumber = obj && obj.purchaserOrderNumber;
        this.batch = obj && obj.batch;
        this.startSequence = obj && obj.startSequence;
        this.stopDate = obj && obj.stopDate;
        this.quantity = obj && obj.quantity;
        this.denomination =obj && obj.denomination;
    }

    purchaserOrderNumber: string;
    batch: string;
    stopDate: string;
    startSequence: string;
    quantity: number;
    denomination: number;
}

export class ListVoucherBatchResponse extends PagedItemResponseBase{
    constructor(obj? : any){
        super(obj);
        this.voucherBatch = obj && obj.voucherBatch.map(vouchBatch => new VoucherBatch(vouchBatch)) || Array();
    }

    voucherBatch: VoucherBatch[]; 
}