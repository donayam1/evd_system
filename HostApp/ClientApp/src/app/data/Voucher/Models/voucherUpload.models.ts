import { ResponseBase } from '../../Shared/Models/responseBase';
import { PagedItemResponseBase } from '../../Shared/Models/PagedItemResponseBase';
import { PagedItemRequestBase } from '../../Shared/Models/PagedItemRequestBase';

export class UploadVoucherResponse extends ResponseBase {
    constructor(obj?: any) {
        super(obj);
    }
}

export class Voucher {
    constructor(obj?: any) {
        this.id = obj && obj.id;
        this.serialNumber = obj && obj.serialNumber;
        this.pinNumber = obj && obj.pinNumber;
        this.stopDate = obj && obj.stopDate;
        this.denomination = obj && obj.denomination;
        this.voucherStatus = obj && obj.voucherStatus;
        this.batchNumber = obj && obj.batchNumber;
    }

    id: string;
    serialNumber: number;
    pinNumber: number;
    stopDate: string;
    denomination: number;
    voucherStatus: number;
    batchNumber: String;

}


export class ListVoucherResponse extends PagedItemResponseBase {
    constructor(obj?: any) {
        super(obj);
        this.vouchers = obj && obj.vouchers.map(v => new Voucher(v)) || Array();
    }

    vouchers: Voucher[];


}

export class CheckOutVoucherResponse extends ResponseBase {
    constructor(obj?: any) {
        super(obj);
        this.voucher = obj && new Voucher(obj.voucher);
    }

    voucher: Voucher;


}

export class ListVouchersRequest extends PagedItemRequestBase {
    purchaseOrderId: string;
    batchId: string;
    voucherStatus: number;
    constructor(obj?: any) {
        super(obj);
        this.purchaseOrderId = obj && obj.purchaseOrderId;
        this.voucherStatus = obj && obj.voucherStatus;
        this.batchId = obj && obj.batchId;
    }
}