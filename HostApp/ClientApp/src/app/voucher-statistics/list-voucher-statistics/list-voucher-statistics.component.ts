import { Component, OnInit } from '@angular/core';
import { VoucherStatisticsService } from 'src/app/data/VoucherStatistics/Services/voucher-statistics.service';
import { VoucherStatistics, VoucherStatisticsResponse } from 'src/app/data/VoucherStatistics/Models/voucher-statistics.model';

@Component({
  selector: 'app-list-voucher-statistics',
  templateUrl: './list-voucher-statistics.component.html',
  styleUrls: ['./list-voucher-statistics.component.css']
})
export class ListVoucherStatisticsComponent implements OnInit {
  
  response: VoucherStatisticsResponse;
  constructor(private voucherStatistics: VoucherStatisticsService) {
    this.response = new VoucherStatisticsResponse();
   }

  ngOnInit() {
    this.voucherStatistics.fetchVoucherStatistics().subscribe((data: VoucherStatisticsResponse) =>{
      this.response = data;
      console.log(data);
    })
  }

}
