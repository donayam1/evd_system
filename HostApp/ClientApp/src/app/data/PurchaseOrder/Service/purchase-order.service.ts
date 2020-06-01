import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PurchaseOrder, CreatePurchaseOrderResponse, NewPurchaseOrder, ListPurchaseOrderResponse } from '../Model/purchase-order.model';
import { Observable, of } from 'rxjs';
import { Message } from '../../Shared/Models/responseBase';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class PurchaseOrderService {

  private readonly api = "";

  constructor(private http:HttpClient) { }

  fetchPurchaseOrder():Observable<ListPurchaseOrderResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<ListPurchaseOrderResponse>(url).subscribe(data => {
        const response = new ListPurchaseOrderResponse(data);
        observer.next(response);
        observer.complete();
      }, error =>{
        observer.error(error);
        observer.complete();
      })
    })
  }
  

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
