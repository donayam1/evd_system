import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/data/User/Services/user.service';
import { State } from '@ngrx/store';
import { UserState, SelectCurrentUser } from 'src/app/data/User/Reducers/user.resucers';
import { Users } from 'src/app/data/User/Models/user.model';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  user: Users;
  constructor(private userService: UserService,
              private state: State<UserState> ) {
                this.user = new Users();
               }

  ngOnInit() {
    this.user = SelectCurrentUser(this.state.value);
  }

}
