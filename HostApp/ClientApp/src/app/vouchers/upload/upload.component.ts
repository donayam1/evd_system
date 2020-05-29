import { Component, OnInit, ViewChild } from '@angular/core';
import { FileUploadService } from '../../data/Files/Services/fileupload.service';
import { NotificationService } from '../../data/Notification/Services/notification.services';
import { UploadVoucherResponse } from '../../data/Voucher/Models/voucherUpload.services';
import { MessageComponent } from '../../messages/message/message.component';

@Component({
  selector: 'app-voucher-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  fileToUpload: File;
  isError: boolean;

  @ViewChild('messages', { static: true })
  messagesCopmponent: MessageComponent;

  constructor(private fileUploadService: FileUploadService,
    private notificationService: NotificationService) {

  }

  ngOnInit() {
    this.notificationService.voucherUploadStatus.subscribe((x: UploadVoucherResponse) => {

      if (x.status === true) {

      } else {

      }
      this.messagesCopmponent.addMessages(x);

    });

  }

  fileToUploaded($event: File) {
    this.fileToUpload = $event;
  }

  uploadFile() {
    this.fileUploadService.uploadFiles(this.fileToUpload, "/api/Vouchers/vouchers/Upload").
      subscribe(x => {
        alert("sucess");
      }, error => {
        alert("faile");
      });
  }

}
