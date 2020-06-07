import { Component, OnInit } from '@angular/core';
import { VoucherService } from 'src/app/data/Voucher/Services/voucher.service';
import { Voucher } from 'src/app/data/Voucher/Models/voucherUpload.services';

@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.css']
})
export class VoucherComponent implements OnInit {
  voucher: Voucher;

  constructor() {
    this.voucher = new Voucher();
  }

  ngOnInit() {
    
  }

}
