import { Component, OnInit } from '@angular/core';
import { GroupType } from 'src/app/data/GroupType/Models/grouptype..models';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { Message } from 'src/app/data/Shared/Models/responseBase';

@Component({
  selector: 'app-edit-group-type',
  templateUrl: './edit-group-type.component.html',
  styleUrls: ['./edit-group-type.component.css']
})
export class EditGroupTypeComponent implements OnInit {
  grouptype: GroupType;
  isError: boolean;
  messages: Message[];
  constructor(private grouptypeService: GrouptypeService) {
    this.grouptype = new GroupType();
    this.isError = false;
    this.messages = Array();
  }

  updateGroupType(){
    this.grouptypeService.updateGroupType(this.grouptype).subscribe(success=>{}, err=>{});
  }

  ngOnInit() {
    this.grouptypeService.getGroupType("12").subscribe(x => {
       if (x.status == true) {
          this.grouptype = x.groupType;
      } else {
          this.isError = true;
          this.messages = x.messages;
      }
      
      }, error => {
          this.isError = true; 
  });
  }

}
