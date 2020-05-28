import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { GroupType } from '../../data/GroupType/Models/grouptype..models';
import { Message } from '../../data/Shared/Models/responseBase';
import { Title } from '@angular/platform-browser';
@Component({
  selector: 'app-create-group-type',
  templateUrl: './create-group-type.component.html',
  styleUrls: ['./create-group-type.component.css']
})
export class CreateGroupTypeComponent implements OnInit {
  grouptypes: GroupType[];
  isError: boolean;
  messages: Message[];
  currentGroupType: GroupType;
  idCounter = -1;
  constructor(private grouptypeService: GrouptypeService) {
    this.grouptypes = Array();
    this.isError = false;
    this.messages = Array();
    this.currentGroupType = new GroupType();
  }

  addGroupType($event?: any) {
    this.idCounter--;
    this.currentGroupType.id = this.idCounter + "";
    console.log('Adding new group type');
    this.grouptypes.push(new GroupType(this.currentGroupType));
    this.currentGroupType.level = -1;
    this.currentGroupType.name = '';
  }

  deleteGroupType(item: GroupType) {
    const index = this.grouptypes.findIndex(x => x.id === item.id);
    this.grouptypes.splice(index, 1);
  }

  ngOnInit() {
  }

}
