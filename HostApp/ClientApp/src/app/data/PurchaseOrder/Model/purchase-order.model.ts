import { ResponseBase } from "../../Shared/Models/responseBase";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";

export class PurchaseOrderItem {
    id: String;
    denomination: Number;
    quantity: Number;
    status: Number;

    constructor (obj?: any){
        this.id = obj && obj.id;
        this.denomination = obj && obj.denomination;
        this.quantity = obj && obj.quantity;
        this.status = obj && obj.status;
    }

}

export class PurchaseOrder{
    id: string;
    poNumber: string;
    purchaseOrderItems: PurchaseOrderItem[];
    date: string;
    status: Number;

    constructor (obj?: any){
        this.id = obj && obj.id;
        this.purchaseOrderItems = obj && obj.purchaseOrderItems.map(poI => new PurchaseOrderItem(poI) ) || Array();
        this.poNumber = obj && obj.poNumber;
        this.date = obj && obj.date;
        this.status = obj && obj.status;
    }
}

export class NewPurchaseOrder extends PurchaseOrder{
    self: boolean;
    isExternal: boolean;
    userId: string;

    constructor (obj?: any){
        super();
        this.self = obj && obj.self || false;
        this.userId = obj && obj.userId || null;
    }
}

export class NewPurchaseOrderResult extends NewPurchaseOrder{
    ui_id: string;

    constructor (obj?: any){
        super();
        this.ui_id = obj && obj.ui_id;
    }
}

export class CreatePurchaseOrderResponse extends ResponseBase{
    newPurchaseOrderResult: NewPurchaseOrderResult;

    constructor (obj?: any){
        super(obj);
        this.newPurchaseOrderResult = obj && new NewPurchaseOrderResult(obj.newPurchaseOrder) || new NewPurchaseOrderResult();
    }

}

export class ListPurchaseOrderResponse extends PagedItemResponseBase{
    constructor(obj?: any){
        super(obj);
        this.purchaseOrders = obj && obj.purchaseOrders && obj.purchaseOrders.map(po => new PurchaseOrder(po)) || Array();
    }
    purchaseOrders: PurchaseOrder[];
}