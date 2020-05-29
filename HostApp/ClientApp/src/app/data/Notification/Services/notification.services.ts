import { Injectable, EventEmitter } from "@angular/core";

import * as signalR from "@aspnet/signalr";
import { NamedItem } from '../../Shared/Models/nameditem.model';
import { UploadVoucherResponse } from "../../Voucher/Models/voucherUpload.services";

@Injectable({
    providedIn: 'root'
})
export class NotificationService {

    public hubConnection: signalR.HubConnection;
    singalRecived = new EventEmitter<NamedItem>();
    voucherUploadStatus = new EventEmitter<UploadVoucherResponse>();

    constructor() {
        this.buildConnection();
        this.startConnection();
        this.registerSignalEvents();
    }
    public buildConnection() {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("http://192.168.137.1:5001/singalHub")
            .build();
    }
    public startConnection() {
        this.hubConnection.
            start()
            .then(() => console.log("Connection started ... "))
            .catch(error => {
                console.log("Error while starting connection", error);
                setTimeout(function () { this.startConnection(); }, 3000);
            });
    }
    public registerSignalEvents() {
        this.hubConnection.on("RecevieMessage", (user: String, message: String) => {
            this.singalRecived.emit(new NamedItem({ "name": user, "id": message }));
        });
        this.hubConnection.on("VoutureUploadStatus", (response: UploadVoucherResponse) => {
            this.voucherUploadStatus.emit(response);
        });
    }



}
