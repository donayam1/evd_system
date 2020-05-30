import { Component, OnInit, ViewChild } from '@angular/core';
import { PurchaseOrderService } from 'src/app/data/PurchaseOrder/Service/purchase-order.service';
import { PurchaseOrder, PurchaseOrderItem } from 'src/app/data/PurchaseOrder/Model/purchase-order.model';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { MessageComponent } from 'src/app/messages/message/message.component';

@Component({
  selector: 'app-create-purchase-order',
  templateUrl: './create-purchase-order.component.html',
  styleUrls: ['./create-purchase-order.component.css']
})
export class CreatePurchaseOrderComponent implements OnInit {
  po: PurchaseOrder;
  currentPoItem: PurchaseOrderItem;
  idCounter = -1;
  @ViewChild('messages', {static: true})
  messages: MessageComponent;
  
  constructor(private poService: PurchaseOrderService) {
    this.po = new PurchaseOrder();
    this.currentPoItem = new PurchaseOrderItem();
   }

  ngOnInit() {
  }

  addPo($event?: any){
    this.idCounter--;
    this.currentPoItem.id = this.idCounter + "";
    this.po.purchaseOrderItems.push (new PurchaseOrderItem(this.currentPoItem));
    this.currentPoItem.denomination = 10;
    this.currentPoItem.quantity = 1;
  }

  createPo($event?: any){
    this.poService.createPurchaseOrder(this.po).subscribe((x)=>{
      this.messages.addMessages(x);
      if(x.status === true){
        
      }
    },err=>{});
  }

  deletePo(item: PurchaseOrderItem){
    const index = this.po.purchaseOrderItems.findIndex(x => x.id === item.id);
    this.po.purchaseOrderItems.splice(index, 1);
  }
}
