import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewUserResponse, NewUser } from '../Models/user.model';
import { AppConfig } from '../../Configs/Services/app.config';
import { Message } from '../../Shared/Models/responseBase';
import { ObjectStatus } from '../../Shared/Models/newObjectStatus.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
private readonly api = "";

  constructor(private http: HttpClient) { }

  createUser(user: NewUser): Observable<NewUserResponse>{
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

  getUser(id: string){
    //Mock Data
    const userResponse: NewUserResponse = new NewUserResponse();
    const user = new NewUser({
      id: '1',
      UserName: 'User-01',
      picUrl: "",
      email: 'example@example.com',
      phoneNumber: 12343445567,
      firstName: 'Abebe',
      middleName: 'Belete',
      lastName: 'Kebede',
      rankId: '12',
      planId: '1',
      objectStatus: ObjectStatus.NEW
    });
    userResponse.newUser = user;
    userResponse.status = true;
    console.log(userResponse);
    return of(userResponse);

    //Later to be used with the api
    // const url = AppConfig.settings.apiServers.authServer + this.api + "/edit";
    // return new Observable(observer => {
    //   this.http.get<NewUserResponse>(url).subscribe(x => {
    //     const response = new NewUserResponse(x);
    //     observer.next(response);
    //     observer.complete();
    //   }, error => {
    //     observer.error(error);
    //     observer.complete();
    //   });
    // });
  }
}
