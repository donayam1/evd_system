import { ResponseBase } from "../../Shared/Models/responseBase";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";

export class PurchaseOrderItem {
    id: String;
    denomination: Number;
    quantity: Number;

    constructor (obj?: any){
        this.id = obj && obj.id;
        this.denomination = obj && obj.denomination;
        this.quantity = obj && obj.quantity;
    }

}

export class PurchaseOrder{
    id: string;
    purchaseOrderItems: PurchaseOrderItem[];

    constructor (obj?: any){
        this.id = obj && obj.id;
        this.purchaseOrderItems = obj && obj.purchaseOrderItems || Array();
    }
}

export class NewPurchaseOrder extends PurchaseOrder{
    ui_id: string;

    constructor (obj?: any){
        super();
        this.ui_id = obj && obj.ui_id;
    }
}

export class CreatePurchaseOrderResponse extends ResponseBase{
    purchaseOrder: NewPurchaseOrder;

    constructor (obj?: any){
        super(obj);
        this.purchaseOrder = obj && new NewPurchaseOrder(obj.purchaseOrder) || new NewPurchaseOrder();
    }

}

export class ListPurchaseOrderResponse extends PagedItemResponseBase{
    constructor(obj?: any){
        super(obj);
        this.purchaseOrders = obj && obj.purchaseOrders.map(po => new PurchaseOrder(po)) || Array();
    }
    purchaseOrders: PurchaseOrder[];
}