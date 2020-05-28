import { Component, OnInit } from '@angular/core';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { GroupType } from '../../data/GroupType/Models/grouptype..models';
import { Message } from '../../data/Shared/Models/responseBase';
@Component({
  selector: 'app-list-group-type',
  templateUrl: './list-group-type.component.html',
  styleUrls: ['./list-group-type.component.css']
})
export class ListGroupTypeComponent implements OnInit {
    grouptype: GroupType[];
    isError: boolean;
    messages: Message[];
    constructor(private grouptypeService: GrouptypeService) {
        this.grouptype = Array();
        this.isError = false;
        this.messages = Array();
    }

    ngOnInit() {
        this.grouptypeService.getGroupType().subscribe(x => {
            if (x.status === true) {
                this.grouptype = x.groupTypes;
            } else {
                this.isError = true;
                this.messages = x.messages;
            }
            
        }, error => {
                this.isError = true;
                //this.messages = error;
        });
  }

}
