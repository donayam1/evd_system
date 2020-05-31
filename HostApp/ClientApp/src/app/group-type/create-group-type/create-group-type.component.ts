import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { GroupType, GroupTypesResponse } from '../../data/GroupType/Models/grouptype..models';
import { Message } from '../../data/Shared/Models/responseBase';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
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
  idCounter = 0;
  constructor(private grouptypeService: GrouptypeService) {
    this.grouptypes = Array();
    this.isError = false;
    this.messages = Array();
    this.currentGroupType = new GroupType();
    //this.status;
  }

  addGroupType($event?: any) {
    this.idCounter++;
    this.currentGroupType.id = this.idCounter + "";
    this.currentGroupType.objectStatus = ObjectStatus.NEW;
    //this.currentGroupType.itemType = 0;
    console.log(this.currentGroupType);
    this.grouptypes.push(new GroupType(this.currentGroupType));
    this.currentGroupType.level = 0;
    this.currentGroupType.name = '';
  }

  saveGroupTypes($event?: any) {
    this.grouptypeService.saveGroupTypes(this.grouptypes).subscribe(x => {
      //this.grouptypes = x;
      console.log(x);
    });
    // this.grouptypeService.saveGroupTypes(this.grouptypes).subscribe(x=>{
    //   if (x.status == true){
    //     this.grouptypes = x.grouptypes;
    //     console.log(this.grouptypes);
    //   }
    //   else{
    //     this.isError = true;
    //     this.messages = x.messages;
    //     console.log("error");
    //   }
    // }, err=>{
    //     this.isError = true;
    // })
  }

  deleteGroupType(item: GroupType) {
    const index = this.grouptypes.findIndex(x => x.id === item.id);
    this.grouptypes.splice(index, 1);
  }

  ngOnInit() {
  }

}
