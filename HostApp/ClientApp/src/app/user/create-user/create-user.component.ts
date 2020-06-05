import { ObjectStatus } from './../../data/Shared/Models/newObjectStatus.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NewUser } from 'src/app/data/User/Models/user.model';
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
  nUser: NewUser;
  gtList: GroupTypesResponse;
  rpList: RetailerPlanResponse;
  selectedRp: RetailerPlan;
  selectedGt: GroupType;
  gtTriggered: boolean;
  rpTriggered: boolean;

  @ViewChild('messages', {static: true})
  messagesComponent: MessageComponent;
  
  constructor(private userService: UserService, private gtService: GrouptypeService, private rpService: RetailerPlanService) {
    this.nUser = new NewUser();
    this.selectedRp = new RetailerPlan();
    this.selectedGt = new GroupType();
    this.gtTriggered = false;
    this.rpTriggered = false;
  }

  ngOnInit() {
    this.gtService.fetchGroupType().subscribe(x => {
      this.gtList = x;
      console.log(x);
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
    this.nUser.rankId = this.selectedGt.id;
    this.nUser.planId = this.selectedRp.id;
    this.userService.createUser(this.nUser).subscribe(x => {
      this.messagesComponent.addMessages(x);
      if(x.status === true){
        console.log(this.nUser);
      }
    }, err => {});
  }

}
