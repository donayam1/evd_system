import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PurchaseOrderRoutingModule } from './purchase-order-routing.module';
import { CreatePurchaseOrderComponent } from './create-purchase-order/create-purchase-order.component';
import { PurchaseOrderHomeComponent } from './purchase-order-home/purchase-order-home.component';
import { MessagesModule } from '../messages/messages.module';
import { FormsModule } from '@angular/forms';
import { ListPurchaseOrderComponent } from './list-purchase-order/list-purchase-order.component';
import { PoItemModule } from '../po-item/po-item.module';


@NgModule({
  declarations: [CreatePurchaseOrderComponent, PurchaseOrderHomeComponent, ListPurchaseOrderComponent],
  imports: [
    CommonModule,
    PurchaseOrderRoutingModule,
    MessagesModule,
    FormsModule,
    PoItemModule
  ]
})
export class PurchaseOrderModule { }
