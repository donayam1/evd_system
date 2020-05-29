import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FileUploadService } from '../../data/Files/Services/fileupload.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {

  @Output()
  fileToUploadedEvent: EventEmitter<File> = new EventEmitter() ;

  constructor() {
    this.fileToUploadedEvent = new EventEmitter();
  }

  handelFileInput($event: any) {
    const files = $event.target.files;
    this.fileToUploadedEvent.emit(files[0]);

    // this.fileUploadService.uploadFiles(this.fileToUpload).subscribe(x => {
    //       alert("Sucess");
    //   }, error => {
    //       alert("failer");
    //   });
  }



}
