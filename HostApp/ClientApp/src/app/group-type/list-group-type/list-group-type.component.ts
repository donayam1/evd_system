import { Component, OnInit } from "@angular/core";
import { GrouptypeService } from "src/app/data/GroupType/Services/grouptype.service";
import { GroupType, GroupTypesResponse } from "../../data/GroupType/Models/grouptype..models";
import { Message } from "../../data/Shared/Models/responseBase";

@Component({
  selector: "app-list-group-type",
  templateUrl: "./list-group-type.component.html",
  styleUrls: ["./list-group-type.component.css"],
})
export class ListGroupTypeComponent implements OnInit {
  grouptype: GroupTypesResponse[];
  isError: boolean;

  messages: Message[];
  constructor(private grouptypeService: GrouptypeService) {
    //this.grouptype = Array();
    this.isError = false;
    this.messages = Array();
  }

  ngOnInit() {
    this.grouptypeService.fetchGroupType().subscribe((response : GroupTypesResponse[])=>{
     console.log(response);
     this.grouptype =response;
    })
     
  }
}
