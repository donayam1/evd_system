import { Component, OnInit } from '@angular/core';
import { AirTimeService } from '../../data/AirTime/Services/airtime.services';
import { AirTimeModel } from '../../data/AirTime/Models/airtime.models';

@Component({
  selector: 'app-air-time-summery',
  templateUrl: './air-time-summery.component.html',
  styleUrls: ['./air-time-summery.component.css']
})
export class AirTimeSummeryComponent implements OnInit {

  model: AirTimeModel;

  constructor(private airTimeService: AirTimeService) {
    this.model = new AirTimeModel();
   }

  ngOnInit() {
    this.airTimeService.fetchOperator().subscribe(x => {
        this.model = x.airTime;
    });
  }

}
