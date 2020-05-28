import { Injectable, EventEmitter } from "@angular/core";

import * as signalR from "@aspnet/signalr";
import { NamedItem } from '../../Shared/Models/nameditem.model';

@Injectable({
    providedIn: 'root'
})
export class NotificationService {

    private hubConnection: signalR.HubConnection;
    singalRecived = new EventEmitter<NamedItem>();

    constructor() {
        this.buildConnection();
        this.startConnection();
    }
    public buildConnection()  {
        this.hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("")
        .build();
    }
    public startConnection() {
        this.hubConnection.
        start()
        .then(() => console.log("Connection started ... "))
        .catch(error => {
            console.log("Error while starting connection", error);
            setTimeout(function() { this.startConnection(); } , 3000);
        });
    }
    public registerSignalEvents() {
        this.hubConnection.on("RecevieMessage", (user: String, message: String) => {
                this.singalRecived.emit(new NamedItem({"name": user, "message": message}));
        });
    }



}
