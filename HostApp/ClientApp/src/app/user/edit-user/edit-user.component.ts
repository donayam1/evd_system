import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/data/Account/Models/user.model';
import { UserService } from 'src/app/data/User/Services/user.service';
import { OperatorState } from 'src/app/data/Operator/Reducer/operator.reducer';
import { Store, State } from '@ngrx/store';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
import { Users } from 'src/app/data/User/Models/user.model';
import { GroupType, GroupTypesResponse } from 'src/app/data/GroupType/Models/grouptype..models';
import { RetailerPlan, RetailerPlanResponse } from 'src/app/data/RetailerPlan/Models/retailer-plan.model';
import { findIndex } from 'rxjs/operators';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  user: Users;
  isError: boolean;
  messages: Message[];
  selectedgt: GroupType;
  selectedrp: RetailerPlan;
  selectedGt: GroupType;
  selectedRp: RetailerPlan;
  gtList: GroupTypesResponse;
  rpList: RetailerPlanResponse;

  constructor(private userServide: UserService, private gtServ: GrouptypeService, private rpServ: RetailerPlanService, private store: Store<OperatorState>, private state: State<OperatorState>) {
    this.user = new Users();
    this.isError = false;
    this.messages = Array();
    this.selectedgt = new GroupType();
    this.selectedrp = new RetailerPlan();
    this.selectedGt = new GroupType();
    this.selectedRp = new RetailerPlan();
    this.gtList = new GroupTypesResponse();
    this.rpList = new RetailerPlanResponse();
  }

  ngOnInit() {
    this.userServide.getUser('1').subscribe(x => {
      if (x.status === true){
        this.user = x.newUser;
        this.gtServ.getGroupType(x.newUser.roleTypeId).subscribe(x => {
          if (x.status === true){
            this.selectedgt = x.groupType;
          }
          else{
            this.isError = true;
            this.messages = x.messages
          }
        }, err => {this.isError = true;})
        this.rpServ.getRetailerPlan(x.newUser.planId).subscribe(x => {
          if (x.status === true){
            this.selectedrp = x.newRetailerPlan;
          }
          else{
            this.isError = true;
            this.messages = x.messages;
          }
        }, err => {this.isError = true;})
      }
      else{
        this.isError = true;
        this.messages = x.messages;
      }
    }, err => {
      this.isError = true;
    })

    this.gtServ.fetchGroupType().subscribe(x => {
      this.gtList = x;
      console.log(x);
    });

    this.rpServ.fetchRetailerPlan().subscribe(x => {
      this.rpList = x;
      console.log(x);
    })
  }

  gtSelected(gt: GroupType){
    this.gtServ.getGroupType(gt.id).subscribe(x => {
      this.selectedGt = x.groupType;
      console.log(x);
    });
    // this.gtTriggered = true;
  }

  rpSelected(rp: RetailerPlan){
    this.rpServ.getRetailerPlan(rp.id).subscribe(x => {
      this.selectedRp = x.newRetailerPlan;
      console.log(x);
    });
    //this.rpTriggered = true;
  }

  updateUser(){
    this.user.objectStatus = ObjectStatus.EDITTED;
    this.userServide.createUser(this.user).subscribe(x => {}, err => {})
  }

}
