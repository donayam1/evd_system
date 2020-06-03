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
  grouptype: GroupTypesResponse;
  allGroupType: GroupTypesResponse;
  filter: any ={};


  isError: boolean;
  roleTypes=[]
  messages: Message[];
  
  constructor(private grouptypeService: GrouptypeService) {
    //this.grouptype = Array();
    this.isError = false;
    this.messages = Array();
    this.grouptype = new GroupTypesResponse();
  }

  ngOnInit() {
    this.grouptypeService.fetchGroupType().subscribe((response)=>{
     this.grouptype = this.allGroupType = response;
     //console.log(this.grouptype)
    })
     
  }

  onFilterChange(){
    var grouptypes = this.allGroupType;
    if(this.filter.id)
     grouptypes.groupTypes = grouptypes.groupTypes.filter(gt => gt.id == this.filter.id);

     this.grouptype = grouptypes
     console.log(this.grouptype)
  }

  // resetFilter(){
  //   this.filter = {};
  //   this.onFilterChange();
  // }
}
