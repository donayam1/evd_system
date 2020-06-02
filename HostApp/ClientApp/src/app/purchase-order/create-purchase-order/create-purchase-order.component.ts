import { ObjectStatus } from './../../data/Shared/Models/newObjectStatus.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PurchaseOrderService } from 'src/app/data/PurchaseOrder/Service/purchase-order.service';
import { PurchaseOrder, PurchaseOrderItem, NewPurchaseOrder } from 'src/app/data/PurchaseOrder/Model/purchase-order.model';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { MessageComponent } from 'src/app/messages/message/message.component';

@Component({
  selector: 'app-create-purchase-order',
  templateUrl: './create-purchase-order.component.html',
  styleUrls: ['./create-purchase-order.component.css']
})
export class CreatePurchaseOrderComponent implements OnInit {
  po: NewPurchaseOrder;
  currentPoItem: PurchaseOrderItem;
  idCounter = -1;
  @ViewChild('messages', {static: true})
  messages: MessageComponent;
  
  constructor(private poService: PurchaseOrderService) {
    this.po = new NewPurchaseOrder();
    this.currentPoItem = new PurchaseOrderItem();
   }

  ngOnInit() {
  }

  isChecked($event){
    return this.po.self = true;
  }

  addPo($event?: any){
    this.idCounter--;
    this.currentPoItem.id = this.idCounter + "";
    this.currentPoItem.status = ObjectStatus.NEW;
    this.po.purchaseOrderItems.push (new PurchaseOrderItem(this.currentPoItem));
    this.currentPoItem.denomination = 10;
    this.currentPoItem.quantity = 1;
  }

  createPo($event?: any){
    if (this.isChecked($event) === true){
      this.po.self = true;
      this.po.userId = null;
    }
    else{
      this.po.self = false;
    }
    this.po.status = ObjectStatus.NEW;
    this.poService.createPurchaseOrder(this.po).subscribe((x)=>{
      this.messages.addMessages(x);
      if(x.status === true){
        console.log(this.po);   
      }
    },err=>{});
  }

  deletePo(item: PurchaseOrderItem){
    const index = this.po.purchaseOrderItems.findIndex(x => x.id === item.id);
    this.po.purchaseOrderItems.splice(index, 1);
  }
}
