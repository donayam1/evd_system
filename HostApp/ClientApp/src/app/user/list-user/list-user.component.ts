import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/data/User/Services/user.service';
import { ListUserResponse } from 'src/app/data/User/Models/user.model';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  response : ListUserResponse;
  constructor(private userSevice : UserService) { 
    this.response = new ListUserResponse();
   }

  ngOnInit() {
    this.userSevice.fetchUser().subscribe(data =>{
      this.response = data;
    })
  }

}
