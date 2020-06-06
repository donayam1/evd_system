import { Component, OnInit } from '@angular/core';
import { PermissionGroup } from 'src/app/data/User/Models/user.model';
import { UserService } from 'src/app/data/User/Services/user.service';

@Component({
  selector: 'app-edit-user-permission',
  templateUrl: './edit-user-permission.component.html',
  styleUrls: ['./edit-user-permission.component.css']
})
export class EditUserPermissionComponent implements OnInit {
  perm: PermissionGroup;

  constructor(private userService: UserService) {
    this.perm = new PermissionGroup();
  }

  ngOnInit() {
    this.userService.getUserPermission().subscribe(x => {
      this.perm = x;
    })
  }

  isChecked($event?: any){

  }

}
