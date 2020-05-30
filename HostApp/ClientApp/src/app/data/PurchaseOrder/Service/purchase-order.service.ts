import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PurchaseOrder, CreatePurchaseOrderResponse, NewPurchaseOrder } from '../Model/purchase-order.model';
import { Observable, of } from 'rxjs';
import { Message } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseOrderService {

  constructor(private http:HttpClient) { }

  createPurchaseOrder(purchaseOrder: PurchaseOrder):Observable<CreatePurchaseOrderResponse>{
    let response = new CreatePurchaseOrderResponse();
    response.status = true;
    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 1;
    mes.systemMessage = "working";
    response.messages.push(mes);

    let po = new NewPurchaseOrder();
    po.ui_id = purchaseOrder.id;
    po.id = '23';
    po.purchaseOrderItems = purchaseOrder.purchaseOrderItems;

    response.purchaseOrder = po;

    return of(response);


  }

  getPurchaseOrder(){

  }
}
