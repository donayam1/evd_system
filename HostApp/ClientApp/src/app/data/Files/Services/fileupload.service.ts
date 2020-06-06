import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AppConfig } from '../../Configs/Services/app.config';
import { ResponseBase } from '../../Shared/Models/responseBase';

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {
    constructor(private http: HttpClient) {
    }

    uploadFiles(file: File, url: string, data?: any): Observable<any> {

        return new Observable(observer => {
            const tUrl = AppConfig.settings.apiServers.authServer + url;
            const formDate: FormData = new FormData();
            formDate.append('theFile', file, file.name);
            if (data != null) {
                data.forEach(element => {
                    formDate.append(element.name, element.value);
                });
            }


            this.http.post(tUrl, formDate).subscribe(x => {
                observer.next(new ResponseBase(x));
                observer.complete();
            }, error => {

            });
        });


        // const tUrl = AppConfig.settings.apiServers.authServer + url;
        // const formDate: FormData = new FormData();
        // formDate.append('theFile', file, file.name);
        // return this.http.post(tUrl, formDate);

    }

}
