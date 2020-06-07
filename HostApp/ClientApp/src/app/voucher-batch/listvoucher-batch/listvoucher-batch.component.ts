import { Component, OnInit } from '@angular/core';
import { ListVoucherBatchResponse } from 'src/app/data/VoucherBatch/Models/voucherBatch.model';
import { VoucherBatchService } from 'src/app/data/VoucherBatch/Services/voucher-batch.service';
import { VoucherBatch } from '../../data/VoucherBatch/Models/voucherBatch.model';
import { Voucher } from 'src/app/data/Voucher/Models/voucherUpload.services';

@Component({
  selector: 'app-listvoucher-batch',
  templateUrl: './listvoucher-batch.component.html',
  styleUrls: ['./listvoucher-batch.component.css']
})
export class ListvoucherBatchComponent implements OnInit {

  response: ListVoucherBatchResponse;
  voucher:Voucher;

  constructor(private voucherBatchService: VoucherBatchService) {
    this.response = new ListVoucherBatchResponse();
    this.voucher = new Voucher(); 
  }

  ngOnInit() {
    this.voucherBatchService.fetchVoucherBatch().subscribe(data => {
      this.response = data;
      console.log(data);
    })
  }
  activateBatch(batch: VoucherBatch) {
    this.voucherBatchService.activateVoucherBatch(batch.id).subscribe(x => {
      if (x.status === true) {
        alert("sucess");
      }
      else {
        alert("error");
      }
    });
  }

  takeSamepl(batch: VoucherBatch) {
    this.voucherBatchService.takeSample(batch.id).subscribe(x => {
      if(x.status === true)
      {
        this.voucher = x.voucher;
      }
    });
  }


}
