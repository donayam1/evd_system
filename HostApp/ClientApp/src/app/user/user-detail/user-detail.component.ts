import { Component, OnInit } from '@angular/core';
import { Users, PermissionGroup } from 'src/app/data/User/Models/user.model';
import { Message } from 'src/app/data/Shared/Models/responseBase';
import { GroupType, GroupTypesResponse } from 'src/app/data/GroupType/Models/grouptype..models';
import { RetailerPlan, RetailerPlanResponse } from 'src/app/data/RetailerPlan/Models/retailer-plan.model';
import { OperatorState } from 'src/app/data/Operator/Reducer/operator.reducer';
import { State, Store } from '@ngrx/store';
import { RetailerPlanService } from 'src/app/data/RetailerPlan/Services/retailer-plan.service';
import { GrouptypeService } from 'src/app/data/GroupType/Services/grouptype.service';
import { UserService } from 'src/app/data/User/Services/user.service';
import { ObjectStatus } from 'src/app/data/Shared/Models/newObjectStatus.model';
// import { UserService } from 'src/app/data/User/Services/user.service';
// import { State } from '@ngrx/store';
import { UserState, SelectCurrentUser } from 'src/app/data/User/Reducers/user.resucers';
//import { Users } from 'src/app/data/User/Models/user.model';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  user: Users;
  isError: boolean;
  messages: Message[];
  selectedgt: GroupType;
  selectedrp: RetailerPlan;
  selectedGt: GroupType;
  selectedRp: RetailerPlan;
  gtList: GroupTypesResponse;
  rpList: RetailerPlanResponse;
  userPermissions: PermissionGroup;
  
  constructor(private userService: UserService, private gtServ: GrouptypeService, private rpServ: RetailerPlanService, private store: Store<OperatorState>, private state: State<OperatorState>) {
    this.user = new Users();
    this.isError = false;
    this.messages = Array();
    this.selectedgt = new GroupType();
    this.selectedrp = new RetailerPlan();
    this.selectedGt = new GroupType();
    this.selectedRp = new RetailerPlan();
    this.gtList = new GroupTypesResponse();
    this.rpList = new RetailerPlanResponse();
    this.userPermissions = new PermissionGroup();

  }

  ngOnInit() {
    this.userService.getUser('1').subscribe(x => {
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
        this.userService.getUserPermission().subscribe(x => {
          this.userPermissions = x;
          console.log(this.userPermissions);
        });
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
    });
  }
  // user: Users;
  // constructor(private userService: UserService,
  //             private state: State<UserState> ) {
  //               this.user = new Users();
  //              }

  // ngOnInit() {
  //   // this.user = SelectCurrentUser(this.state.value);
  // }

  // gtSelected(gt: GroupType){
  //   this.gtServ.getGroupType(gt.id).subscribe(x => {
  //     this.selectedGt = x.groupType;
  //     console.log(x);
  //   });
  //   // this.gtTriggered = true;
  // }

  // rpSelected(rp: RetailerPlan){
  //   this.rpServ.getRetailerPlan(rp.id).subscribe(x => {
  //     this.selectedRp = x.newRetailerPlan;
  //     console.log(x);
  //   });
  //   //this.rpTriggered = true;
  // }

  // editPermission(id: string){

  // }

  // updateUser(){
  //   this.user.objectStatus = ObjectStatus.EDITTED;
  //   this.userService.createUser(this.user).subscribe(x => {}, err => {})
  // }

}
