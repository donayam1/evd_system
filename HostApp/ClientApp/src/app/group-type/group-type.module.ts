import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';

import { GroupTypeRoutingModule } from './group-type-routing.module';
import { CreateGroupTypeComponent } from './create-group-type/create-group-type.component';
import { ListGroupTypeComponent } from './list-group-type/list-group-type.component';
import { EditGroupTypeComponent } from './edit-group-type/edit-group-type.component';

@NgModule({
  declarations: [CreateGroupTypeComponent, ListGroupTypeComponent, EditGroupTypeComponent],
  imports: [
    CommonModule,
    GroupTypeRoutingModule,
    FormsModule,
  ]
})
export class GroupTypeModule { }
