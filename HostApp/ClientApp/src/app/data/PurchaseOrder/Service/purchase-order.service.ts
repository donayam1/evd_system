import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PurchaseOrder, CreatePurchaseOrderResponse, NewPurchaseOrder, NewPurchaseOrderResult, ListPurchaseOrderResponse, PurchaseOrderItem } from '../Model/purchase-order.model';
import { Observable, of } from 'rxjs';
import { Message } from '../../Shared/Models/responseBase';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
  providedIn: 'root'
})
export class PurchaseOrderService {

  private readonly api = "/api/purchaseOrders/purshaseOrder";

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
    // const purchaseOrdersResponce = new ListPurchaseOrderResponse();
    // const purchaseOrder = new PurchaseOrder(
    //   {id:"1",poNumber: 'PO1', purchaseOrderItems:[{id: "1", denomination:5 ,quantity: 100},
    //     {id: "1",denomination:10 ,quantity: 90},
    //     {id: "2",denomination:15 ,quantity: 100},
    //     {id: "3",denomination:25 ,quantity: 110},
    //     {id: "4",denomination:50 ,quantity: 50},
    //     {id: "5",denomination:100 ,quantity: 10},
    //  ], date: "6/4/2020" });
    //  const po: PurchaseOrder[]= Array();
    //  po.push(purchaseOrder);
    //  purchaseOrdersResponce.purchaseOrders = po;
    // return of(purchaseOrdersResponce)


 
  }
  

  createPurchaseOrder(purchaseOrder: NewPurchaseOrder):Observable<CreatePurchaseOrderResponse>{
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
    po.isExternal = purchaseOrder.isExternal;
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
        observer.error(error);
        observer.complete();
      });
    });
    */


  }

  getPurchaseOrder(){

  }
}
