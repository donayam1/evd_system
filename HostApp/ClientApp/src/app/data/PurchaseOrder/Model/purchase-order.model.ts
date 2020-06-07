import { ResponseBase } from "../../Shared/Models/responseBase";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";
import { extend } from 'webdriver-js-extender';
import { PagedItemRequestBase } from '../../Shared/Models/PagedItemRequestBase';

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
    purchaseOrderNumber: string;
    items: PurchaseOrderItem[];
    date: string;
    status: Number;

    constructor (obj?: any){
        this.id = obj && obj.id;
        this.items = obj && obj.items.map(poI => new PurchaseOrderItem(poI) ) || Array();
        this.purchaseOrderNumber = obj && obj.purchaseOrderNumber;
        this.date = obj && obj.date;
        this.status = obj && obj.status;
    }
}

export class NewPurchaseOrder extends PurchaseOrder{
    self: boolean;
    isExternalOrder: boolean;
    userId: string;

    constructor (obj?: any){
        super();
        this.self = obj && obj.self || false;
        this.userId = obj && obj.userId || null;
        this.isExternalOrder = obj && obj.isExternal || false;
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

export class ListPurchaseOrdersRequest extends PagedItemRequestBase {
    
    isExternalOrder:boolean;
    constructor(obj?: any){
        super(obj);
        this.isExternalOrder = obj && obj.isExternalOrder || false;
    }
   
}
