import { Component, OnInit } from '@angular/core';
import { ListPurchaseOrderResponse, PurchaseOrder } from 'src/app/data/PurchaseOrder/Model/purchase-order.model';
import { PurchaseOrderService } from 'src/app/data/PurchaseOrder/Service/purchase-order.service';

@Component({
  selector: 'app-list-purchase-order',
  templateUrl: './list-purchase-order.component.html',
  styleUrls: ['./list-purchase-order.component.css']
})
export class ListPurchaseOrderComponent implements OnInit {

  response: ListPurchaseOrderResponse;

  constructor(private purchaseOrderService: PurchaseOrderService) { 
    this.response = new ListPurchaseOrderResponse();
  }

  ngOnInit() {
    this.purchaseOrderService.fetchPurchaseOrder().subscribe((response: ListPurchaseOrderResponse)=>{
      this.response = response;
      console.log(this.response)
    })

  }

}
