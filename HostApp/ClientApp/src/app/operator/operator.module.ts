import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {HttpClientModule, HttpClient} from '@angular/common/http';

import { OperatorRoutingModule } from './operator-routing.module';
import { CreateOperatorComponent } from './create-operator/create-operator.component';
import { ListOperatorComponent } from './list-operator/list-operator.component';
import { EditOperatorComponent } from './edit-operator/edit-operator.component';


@NgModule({
  declarations: [CreateOperatorComponent, ListOperatorComponent, EditOperatorComponent],
  imports: [
    CommonModule,
    OperatorRoutingModule,
    FormsModule,
    HttpClientModule,
  ]
})
export class OperatorModule { }
