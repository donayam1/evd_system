import { NamedItem } from "../../Shared/Models/nameditem.model";
import { ResponseBase } from "../../Shared/Models/responseBase";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";

export class CommissionRate {
    constructor(obj? : any){
        this.id = obj && obj.id;
        this.amount = obj && obj.amount;
        this.rate = obj && obj.amount;
    }
    id: string;
    amount: number;
    rate: number;
}

export class RetailerPlan extends NamedItem {
    constructor(obj? : any){
        super(obj);
        this.code = obj && obj.code;
        this.description = obj && obj.description;
        this.joiningAmount = obj &&  obj.joiningAmount;
        this.renwalAmount = obj && obj.renwalAmount;
        this.renewalAmountChargingRate = obj && obj.renewalAmountChargingRate;
        this.commisionRateType = obj && obj.commisionRateType;
        this.commissionRates = obj && obj.commissionRates || Array();
        this.operatorId = obj && obj.operatorId;
        this.objectStatus = obj && obj.objectStatus;
    }
    code: string;
    description: string;
    joiningAmount: number;
    renwalAmount: number;
    renewalAmountChargingRate: number;
    commisionRateType: number;
    commissionRates: CommissionRate[];
    operatorId: string;
    objectStatus: number;
}

export class RetailerPlanResponse extends PagedItemResponseBase{
    constructor(obj? : any){
        super(obj);
        this.retailerPlans = obj && obj.retailerPlans && obj.retailerPlans.map(rp => new RetailerPlan(rp))

    }
    retailerPlans: RetailerPlan[]
}

export class NewPlan extends RetailerPlan {
    constructor(obj? : any){
        super(obj);
        this.ui_id = obj && obj.ui_id;
    }
    ui_id: string;

}

export class CreateRetailerPlanResponse extends ResponseBase{
    newRetailerPlan: NewPlan;
    constructor(obj?: any){
        super(obj);
        this.newRetailerPlan = obj && new NewPlan(obj.retailerPlan) || new NewPlan();
    }
}