import { Component, OnInit, Input } from '@angular/core';
import { PurchaseOrder } from 'src/app/data/PurchaseOrder/Model/purchase-order.model';

@Component({
  selector: 'app-purchase-order',
  templateUrl: './purchase-order.component.html',
  styleUrls: ['./purchase-order.component.css']
})
export class PurchaseOrderComponent implements OnInit {

  @Input()
  purchaseOrder: PurchaseOrder;
  constructor() {
    this.purchaseOrder = new PurchaseOrder();
  }

  ngOnInit() {
  }

}
