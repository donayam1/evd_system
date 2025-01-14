import { Component, OnInit, ViewChild } from '@angular/core';
import { FileUploadService } from '../../data/Files/Services/fileupload.service';
import { NotificationService } from '../../data/Notification/Services/notification.services';
import { UploadVoucherResponse } from '../../data/Voucher/Models/voucherUpload.models';
import { MessageComponent } from '../../messages/message/message.component';
import { PurchaseOrder, ListPurchaseOrdersRequest } from '../../data/PurchaseOrder/Model/purchase-order.model';
import { PurchaseOrderService } from '../../data/PurchaseOrder/Service/purchase-order.service';

@Component({
  selector: 'app-voucher-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  fileToUpload: File;
  isError: boolean;
  currPo: PurchaseOrder;
  purchaseOrders: PurchaseOrder[];
  isTriggered: boolean;

  @ViewChild('messages', { static: true })
  messagesCopmponent: MessageComponent;

  constructor(private fileUploadService: FileUploadService,
    private notificationService: NotificationService,
    private poService: PurchaseOrderService) {
      this.currPo = new PurchaseOrder();
      this.purchaseOrders = Array();
      this.isTriggered = false;
  }

  ngOnInit() {
    this.notificationService.voucherUploadStatus.subscribe((x: UploadVoucherResponse) => {
      if (x.status === true) {
      } else {
      }
      this.messagesCopmponent.addMessages(x);
    });
    const req = new ListPurchaseOrdersRequest ({isExternalOrder: true});
    this.poService.fetchPurchaseOrder(req).subscribe(x => {
        this.purchaseOrders = x.purchaseOrders;
    });
  }

  poCheck(){
    return this.isTriggered = true;
  }

  fileToUploaded($event: File) {
    this.fileToUpload = $event;
  }

  uploadFile() {
    const data = [
      {
      "name" : "purchaseOrderId",
      "value": this.currPo.id
    }
  ];

    this.fileUploadService.uploadFiles(this.fileToUpload, "/api/Vouchers/vouchers", ///Upload
    data).
      subscribe(x => {
        this.messagesCopmponent.addMessages(x);
      }, error => {
        this.messagesCopmponent.addMessages(error);
      });
  }

}
