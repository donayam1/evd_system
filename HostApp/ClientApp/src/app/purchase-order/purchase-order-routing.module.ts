import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseOrderHomeComponent } from './purchase-order-home/purchase-order-home.component';
import { CreatePurchaseOrderComponent } from './create-purchase-order/create-purchase-order.component';
import { ListPurchaseOrderComponent } from './list-purchase-order/list-purchase-order.component';

const routes: Routes = [
  {path: '', component: PurchaseOrderHomeComponent, children:[
    {path: 'create', component: CreatePurchaseOrderComponent},
    {path: 'list', component: ListPurchaseOrderComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseOrderRoutingModule { }
