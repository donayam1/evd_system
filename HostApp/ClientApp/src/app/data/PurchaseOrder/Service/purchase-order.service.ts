import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PurchaseOrder, CreatePurchaseOrderResponse, NewPurchaseOrder, NewPurchaseOrderResult } from '../Model/purchase-order.model';
import { Observable, of } from 'rxjs';
import { Message } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseOrderService {

  constructor(private http:HttpClient) { }

  createPurchaseOrder(purchaseOrder: NewPurchaseOrder):Observable<CreatePurchaseOrderResponse>{
    //Mock Data
    let response = new CreatePurchaseOrderResponse();
    response.status = true;
    let mes = new Message();
    mes.messageCode = '30';
    mes.messageType = 1;
    mes.systemMessage = "working";
    response.messages.push(mes);

    let po = new NewPurchaseOrderResult();
    po.ui_id = purchaseOrder.id;
    po.id = '23';
    po.self = purchaseOrder.self;
    po.userId = purchaseOrder.userId;
    po.poNumber = purchaseOrder.poNumber;
    po.purchaseOrderItems = purchaseOrder.purchaseOrderItems;

    response.newPurchaseOrderResult = po;

    return of(response);

    //Later to be used with the api
    /*
    const url = AppConfig.settings.apiServers.authServer + this.url;
    return new Observable(observer => {
      this.http.post<CreatePurchaseOrderResponse>(url, purchaseOrder).subscribe(result => {
        const response = new CreatePurchaseOrderResponse(result);
        observer.next(response);
        observer.complete();
      }, error => {
        observe.error(error);
        observer.complete();
      });
    });
    */


  }

  getPurchaseOrder(){

  }
}
