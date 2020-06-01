import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AppConfig } from '../../Configs/Services/app.config';

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {
    constructor(private http: HttpClient) {
    }

    uploadFiles(file: File, url: string): Observable<any> {

        const tUrl = AppConfig.settings.apiServers.authServer + url;
        const formDate: FormData = new FormData();
        formDate.append('theFile', file, file.name);
        return this.http.post(tUrl, formDate);

    }

}
