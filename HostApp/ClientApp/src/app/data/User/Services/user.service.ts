import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewUserResponse, NewUser, ListUserResponse, Users } from '../Models/user.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly api = "";

  constructor(private http: HttpClient) { }

  fetchUser():Observable<ListUserResponse>{
    const userResponse: ListUserResponse = new ListUserResponse();
    const users = new Users({
     Id: "1",
     UserName: "nat",
     email: "nat@gmail.com",
     phoneNumber: "0910935858",
     firstName: "natty",
     middleName: "teshome",
     lastName: "gudeta",
     userStatus: "Active"   
    });

    const usersList: Users[] = Array();
    usersList.push(users);
    userResponse.users = usersList;
    return of(userResponse)

    // const url = AppConfig.settings.apiServers.authServer + this.api + "/list";
    // return new Observable(observer => {
    //   this.http.get<ListUserResponse>(url).subscribe(data => {
    //     const response = new ListUserResponse(data);
    //     observer.next(response);
    //     observer.complete();
    //   },error => {
    //     observer.error(error);
    //     observer.complete();
    //   })
    // })

  }

  createUser(user: NewUser): Observable<NewUserResponse> {
    //Mock Data
    let response = new NewUserResponse();
    response.status = true;

    let mes = new Message();
        mes.messageCode = '30';
        mes.messageType = 1;
        mes.systemMessage = "user data correctly traverses between service.";
        response.messages.push(mes);

    let nu = new NewUser();
        nu.Id = '1';
        nu.UserName = user.UserName;
        nu.PicUrl = "";
        nu.email = user.email;
        nu.phoneNumber = user.phoneNumber;
        nu.firstName = user.firstName;
        nu.lastName = user.lastName;
        nu.rankId = user.rankId;
        nu.planId = '2';
        nu.objectStatus = user.objectStatus;

        response.newUser = nu;

    return of(response);

    //Later to be used with the api.
    // const url = AppConfig.settings.apiServers.authServer + this.api + "/Create";
    // return new Observable(observer => {
    //   this.http.post<NewUserResponse>(url, user).subscribe(x => {
    //     observer.next(new NewUserResponse(x));
    //     observer.complete();
    //   }, error => {
    //     observer.error(error);
    //     observer.complete();
    //   });
    // });
  }
}
