import { Component } from '@angular/core';
import { NotificationService } from '../../data/Notification/Services/notification.services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private notificationService:NotificationService){

  }
  sendMessage(){
    this.notificationService.hubConnection.invoke("SendMessage","Donayam","Nega")
    .catch(error=>{
      console.dir(error);
    });
  }
}
