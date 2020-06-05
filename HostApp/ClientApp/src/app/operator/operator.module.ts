import { StoreModule } from '@ngrx/store';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {HttpClientModule, HttpClient} from '@angular/common/http';

import { OperatorRoutingModule } from './operator-routing.module';
import { CreateOperatorComponent } from './create-operator/create-operator.component';
import { ListOperatorComponent } from './list-operator/list-operator.component';
import { EditOperatorComponent } from './edit-operator/edit-operator.component';
import { HomeComponent } from './home/home.component';
import { MessagesModule } from '../messages/messages.module';
import { OperatorReducers } from '../data/Operator/Reducer/operator.reducer';


@NgModule({
  declarations: [CreateOperatorComponent, ListOperatorComponent, EditOperatorComponent, HomeComponent],
  imports: [
    CommonModule,
    OperatorRoutingModule,
    FormsModule,
    HttpClientModule,
    MessagesModule,
    StoreModule.forFeature("opr",OperatorReducers)
  ]
})
export class OperatorModule { }
