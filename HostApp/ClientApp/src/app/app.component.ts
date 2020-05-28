import { Component } from '@angular/core';
import { NotificationService } from './data/Notification/Services/notification.services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  message: string;
  constructor(private notificationService: NotificationService){
    this.notificationService.singalRecived.subscribe(x=>{
        this.message = x;
    });

  }
}
