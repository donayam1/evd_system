import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";


export class VoucherBatch {
    constructor(obj?: any){
        this.id = obj && obj.id;
        this.purchaserOrderId = obj && obj.purchaserOrderId;
        this.batch = obj && obj.batch;
        this.startSequence = obj && obj.startSequence;
        this.stopDate = obj && obj.stopDate;
        this.quantity = obj && obj.quantity;
        this.denomination = obj && obj.denomination;
    }

    id: String;
    purchaserOrderId: string;
    batch: string;
    stopDate: string;
    startSequence: string;
    quantity: number;
    denomination: number;
}

export class ListVoucherBatchResponse extends PagedItemResponseBase{
    constructor(obj? : any){
        super(obj);
        this.voucherBatches = obj && obj.voucherBatches.map(vouchBatch => new VoucherBatch(vouchBatch)) || Array();
    }

    voucherBatches: VoucherBatch[]; 
}