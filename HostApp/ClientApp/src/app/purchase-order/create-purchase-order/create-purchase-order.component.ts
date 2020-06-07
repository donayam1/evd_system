import { UserService } from 'src/app/data/User/Services/user.service';
import { ObjectStatus } from './../../data/Shared/Models/newObjectStatus.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PurchaseOrderService } from 'src/app/data/PurchaseOrder/Service/purchase-order.service';
import { PurchaseOrder, PurchaseOrderItem, NewPurchaseOrder } from 'src/app/data/PurchaseOrder/Model/purchase-order.model';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { MessageComponent } from 'src/app/messages/message/message.component';
import { ListUserResponse, Users } from 'src/app/data/User/Models/user.model';

@Component({
  selector: 'app-create-purchase-order',
  templateUrl: './create-purchase-order.component.html',
  styleUrls: ['./create-purchase-order.component.css']
})
export class CreatePurchaseOrderComponent implements OnInit {
  po: NewPurchaseOrder;
  uList: ListUserResponse;
  selectedUser: Users;
  currentPoItem: PurchaseOrderItem;
  isSelf: boolean;
  isEx: boolean;
  idCounter = -1;
  @ViewChild('messages', {static: true})
  messages: MessageComponent;
  
  constructor(private poService: PurchaseOrderService, private uService: UserService) {
    this.po = new NewPurchaseOrder();
    this.currentPoItem = new PurchaseOrderItem();
    this.uList = new ListUserResponse();
    this.isSelf = false;
    this.isEx = false;
   }

  ngOnInit() {
    this.uService.fetchUser().subscribe(x => {
      if (x.status === true){
        this.uList = x;
        console.log(x);
      }
    })
  }

  isChecked($event){
    this.isSelf = true;
    return this.po.self = true;
  }

  isExternal($event){
    this.isEx = true;
    return this.po.isExternal = true;
  }

  checkUser(user: Users){
    this.uService.getUser(user.Id).subscribe(x => {
      this.selectedUser = x.newUser;
    })
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
    if (this.isSelf === true){
      this.po.self = true;
      this.po.userId = null;
    }
    else{
      this.po.self = false;
      this.po.userId = this.selectedUser.Id;
    }
    if (this.isEx === true){
      this.po.isExternal = true;
    }
    else{
      this.po.isExternal = false;
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
