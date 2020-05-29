import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FileUploadRoutingModule } from './file-upload-routing.module';
import { UploadComponent } from '../file-upload/upload/upload.component';

@NgModule({
  declarations: [UploadComponent],
  imports: [
    CommonModule,
    FileUploadRoutingModule
  ],
  exports : [UploadComponent]
})
export class FileUploadModule { }
