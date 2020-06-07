import { Component, OnInit } from '@angular/core';
import { ListVoucherBatchResponse } from 'src/app/data/VoucherBatch/Models/voucherBatch.model';
import { VoucherBatchService } from 'src/app/data/VoucherBatch/Services/voucher-batch.service';
import { VoucherBatch } from '../../data/VoucherBatch/Models/voucherBatch.model';

@Component({
  selector: 'app-listvoucher-batch',
  templateUrl: './listvoucher-batch.component.html',
  styleUrls: ['./listvoucher-batch.component.css']
})
export class ListvoucherBatchComponent implements OnInit {

  response: ListVoucherBatchResponse;

  constructor(private voucherBatchService: VoucherBatchService) {
    this.response = new ListVoucherBatchResponse();
   }

  ngOnInit() {
    this.voucherBatchService.fetchVoucherBatch().subscribe(data =>{
      this.response = data;
      console.log(data);
    })
  }
  activateBatch(batch:VoucherBatch){
    this.voucherBatchService.activateVoucherBatch(batch.id).subscribe(x=> {
      if(x.status === true){
        alert("sucess");
      }
      else {
        alert("error");
      }
    });
  }
  
  takeSamepl(batch:VoucherBatch){

  }


}
