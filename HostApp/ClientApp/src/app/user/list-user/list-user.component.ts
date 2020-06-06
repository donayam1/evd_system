import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/data/User/Services/user.service';
import { ListUserResponse, Users } from 'src/app/data/User/Models/user.model';
import { Store, State } from '@ngrx/store';
import { UserState } from 'src/app/data/User/Reducers/user.resucers';
import { SelectUserAction } from 'src/app/data/User/Actions/user.actions';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  response : ListUserResponse;

  constructor(private userSevice : UserService ,
              private store: Store<UserState>,
              private state: State<UserState> ) { 
    this.response = new ListUserResponse();
   }

  ngOnInit() {
    this.userSevice.fetchUser().subscribe((data: ListUserResponse) =>{
      this.response = data;
      console.log(data)
    })
  }

  detailUser(user: Users) {
    let userSelectedAction = new SelectUserAction(user);
    this.store.dispatch(userSelectedAction);
  }

}
