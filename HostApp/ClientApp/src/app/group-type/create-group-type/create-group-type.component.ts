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
  grouptype: GroupType[];
  isError: boolean;
  messages:Message[];
  constructor(private grouptypeService: GrouptypeService) { 
    this.grouptype = Array();
    this.isError = false;
    this.messages = Array();
  }

  addGroupType({ level, label }: { level: HTMLInputElement; label: HTMLInputElement; }): boolean{
    console.log('Adding new group type');
    this.grouptype.push(new GroupType(level.value, label.value, 0));
    level.value = '';
    label.value = '';
    return false;
  }

  ngOnInit() {
  }

}
