import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AirTimeSummeryComponent } from './air-time-summery/air-time-summery.component';

@NgModule({
  declarations: [AirTimeSummeryComponent],
  imports: [
    CommonModule
  ],
  exports:[AirTimeSummeryComponent]
})
export class AirTimeModule { }
