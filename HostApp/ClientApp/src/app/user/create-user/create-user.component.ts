import { ObjectStatus } from './../../data/Shared/Models/newObjectStatus.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Users } from 'src/app/data/User/Models/user.model';
import { MessageComponent } from 'src/app/messages/message/message.component';
import { UserService } from 'src/app/data/User/Services/user.service';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { GroupTypesResponse, GroupType } from 'src/app/data/GroupType/Models/grouptype..models';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';
import { RetailerPlanResponse, RetailerPlan } from 'src/app/data/RetailerPlan/Models/retailer-plan.model';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  nUser: Users;
  gtList: GroupTypesResponse;
  rpList: RetailerPlanResponse;
  selectedRp: RetailerPlan;
  selectedGt: GroupType;
  gtTriggered: boolean;
  rpTriggered: boolean;

  @ViewChild('messages', {static: true})
  messagesComponent: MessageComponent;
  
  constructor(private userService: UserService, private gtService: GrouptypeService,
     private rpService: RetailerPlanService) {
    this.nUser = new Users();
    this.selectedRp = new RetailerPlan();
    this.selectedGt = new GroupType();
    this.gtList = new GroupTypesResponse();
    this.rpList = new RetailerPlanResponse();
    this.gtTriggered = false;
    this.rpTriggered = false;
  }

  ngOnInit() {
    this.gtService.fetchGroupType().subscribe(x => {
      if(x.status === true){
        this.gtList = x;
        this.selectedGt = x.groupTypes[0];
        console.log(x);
      }
    });

    this.rpService.fetchRetailerPlan().subscribe(x => {
      this.rpList = x;
      console.log(x);
    })
  }

  gtSelected(gt: GroupType){
    this.gtService.getGroupType(gt.id).subscribe(x => {
      this.selectedGt = x.groupType;
      console.log(x);
    });
    this.gtTriggered = true;
  }

  rpSelected(rp: RetailerPlan){
    this.rpService.getRetailerPlan(rp.id).subscribe(x => {
      this.selectedRp = x.newRetailerPlan;
      console.log(x);
    });
    this.rpTriggered = true;
  }

  createUser($event?: any){
    this.nUser.objectStatus = ObjectStatus.NEW;
    this.nUser.roleTypeId = this.selectedGt.id;
    this.nUser.groupName = this.selectedGt.name;
    this.nUser.planId = this.selectedRp.id;
    this.nUser.groupTypeName = this.selectedGt.name;
    this.nUser.password = '000000';
    this.userService.createUser(this.nUser).subscribe(x => {
      this.messagesComponent.addMessages(x);
      if(x.status === true){
        console.log(this.nUser);
      }
    }, err => {});
  }

}
