import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';

import { GroupTypeRoutingModule } from './group-type-routing.module';
import { CreateGroupTypeComponent } from './create-group-type/create-group-type.component';
import { ListGroupTypeComponent } from './list-group-type/list-group-type.component';
import { EditGroupTypeComponent } from './edit-group-type/edit-group-type.component';
import { HomeComponent } from './home/home.component';
import { MessagesModule } from '../messages/messages.module';
import { StoreModule } from '@ngrx/store';
import { GroupTypeReducers } from '../data/GroupType/Reducers/groupType.reducers';

@NgModule({
  declarations: [CreateGroupTypeComponent, ListGroupTypeComponent, EditGroupTypeComponent, HomeComponent],
  imports: [
    CommonModule,
    GroupTypeRoutingModule,
    FormsModule,
    MessagesModule,
    StoreModule.forFeature("groupTypes",GroupTypeReducers)
  ]
})
export class GroupTypeModule { }
