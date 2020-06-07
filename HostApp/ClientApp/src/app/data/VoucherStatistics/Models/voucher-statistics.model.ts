import { ResponseBase } from "../../Shared/Models/responseBase";


export class  VoucherStatistics {
    constructor(obj? : any){
        this.denomination = obj && obj.denomination;
        this.quantity = obj && obj.quantity;

    }

    denomination: number;
    quantity: number;
}

export class VoucherStatisticsResponse extends ResponseBase {
    constructor(obj?: any){
      super(obj)
      this.voucherStatistics = obj && obj.voucherStatistics && obj.voucherStatistics.map(vs => new VoucherStatistics(vs)) || Array();
    }

    voucherStatistics: VoucherStatistics[];

}