import { Component, OnInit } from '@angular/core';
import { GroupType } from 'src/app/data/GroupType/Models/grouptype..models';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';

@Component({
  selector: 'app-edit-group-type',
  templateUrl: './edit-group-type.component.html',
  styleUrls: ['./edit-group-type.component.css']
})
export class EditGroupTypeComponent implements OnInit {
  grouptype: GroupType;
  constructor(private grouptypeService: GrouptypeService) { }

  updateGroupType(){
    this.grouptypeService.updateGroupType(this.grouptype).subscribe(success=>{}, err=>{});
  }

  ngOnInit() {
    this.grouptypeService.fetchGroupType().subscribe(x => {
      /* if (x.status == true) {
          this.grouptype = x.groupTypes;
      } else {
          this.isError = true;
          this.messages = x.messages;
      }
      
  }, error => {
          this.isError = true; */
  });
  }

}
