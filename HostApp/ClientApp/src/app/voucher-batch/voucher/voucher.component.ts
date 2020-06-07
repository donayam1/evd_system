import { Component, OnInit, Input } from '@angular/core';
import { Voucher } from '../../data/Voucher/Models/voucherUpload.services';

@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.css']
})
export class VoucherComponent implements OnInit {
  
  @Input()
  voucher: Voucher;

  constructor() {
    this.voucher = new Voucher();
  }

  ngOnInit() {
    
  }

}
