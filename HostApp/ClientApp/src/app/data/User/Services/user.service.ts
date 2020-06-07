import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewUserResponse, ListUserResponse, Users, PermissionGroup, Permission } from '../Models/user.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';
import { ObjectStatus } from '../../Shared/Models/newObjectStatus.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly api = "/api/evd/users/user";

  constructor(private http: HttpClient) { }

  fetchUser():Observable<ListUserResponse>{
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<ListUserResponse>(url).subscribe(data => {
        const response = new ListUserResponse(data);
        console.dir(response)
        observer.next(response);
        observer.complete();
      },error => {
        observer.error(error);
        observer.complete();
      })
    })

    //  const userResponse: ListUserResponse = new ListUserResponse();
    // const users = new Users([{
    //  Id: "1",
    //  UserName: "nat",
    //  email: "nat@gmail.com",
    //  phoneNumber: "0910935858",
    //  firstName: "natty",
    //  middleName: "teshome",
    //  lastName: "gudeta",
    //  userStatus: "Active"   
    // }]);

    // const usersList: Users[] = Array();
    // usersList.push(users);
    // userResponse.users = usersList;
    // console.log(userResponse)
    // return of(userResponse)


  }

  createUser(user: Users): Observable<NewUserResponse> {
    //Mock Data
    // let response = new NewUserResponse();
    // response.status = true;

    // let mes = new Message();
    //     mes.messageCode = '30';
    //     mes.messageType = 1;
    //     mes.systemMessage = "user data correctly traverses between service.";
    //     response.messages.push(mes);

    // let nu = new NewUser();
    //     nu.Id = '1';
    //     nu.UserName = user.UserName;
    //     nu.PicUrl = "";
    //     nu.email = user.email;
    //     nu.phoneNumber = user.phoneNumber;
    //     nu.firstName = user.firstName;
    //     nu.lastName = user.lastName;
    //     nu.rankId = user.rankId;
    //     nu.planId = user.planId;
    //     nu.objectStatus = user.objectStatus;

    //     response.newUser = nu;

    // return of(response);

    //Later to be used with the api.
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.post<NewUserResponse>(url, user).subscribe(x => {
        observer.next(new NewUserResponse(x));
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

  getUser(id: string):Observable<NewUserResponse>{
    //Mock Data
    // const userResponse: NewUserResponse = new NewUserResponse();
    // const user = new Users({
    //   id: '1',
    //   UserName: 'User-01',
    //   picUrl: "",
    //   email: 'example@example.com',
    //   phoneNumber: 12343445567,
    //   firstName: 'Abebe',
    //   middleName: 'Belete',
    //   lastName: 'Kebede',
    //   rankId: '12',
    //   planId: '1',
    //   objectStatus: ObjectStatus.NEW
    // });
    // userResponse.newUser = user;
    // userResponse.status = true;
    // console.log(userResponse);
    // return of(userResponse);

    //Later to be used with the api
    const url = AppConfig.settings.apiServers.authServer + this.api;
    return new Observable(observer => {
      this.http.get<NewUserResponse>(url).subscribe(x => {
        const response = new NewUserResponse(x);
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
        observer.complete();
      });
    });
  }

  getUserPermission(){
    //Mock data
    let adminPermission = new PermissionGroup();
    adminPermission.name = 'Administrator Permissions';
    adminPermission.description = 'This set of permissions are valid authorities given for Administrators.';

    let pr1 = new Permission({value: 'pr-1', name: 'validate users', description: 'you can validate new users.'});
    let pr2 = new Permission({value: 'pr-2', name: 'upload voucher', description: 'you can upload voucher lists.'});
    let pr3 = new Permission({value: 'pr-3', name: 'approve po', description: 'you can approve stalling purchase orders'});

    let prg: Permission[] = Array();
    prg.push(pr1, pr2, pr3);
    adminPermission.permissions = prg;

    return of(adminPermission);
  }
}
