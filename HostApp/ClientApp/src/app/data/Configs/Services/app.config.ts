import { IAppConfig } from '../models/app.config';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
// import { Observable } from 'rxjs';
import { Subject } from 'rxjs';


@Injectable({
    "providedIn": 'root'
})
export class AppConfig {
    static settings: IAppConfig;
    settings0: Subject<IAppConfig> = new Subject<IAppConfig>();
    // http:HttpClient;
    constructor(private http: HttpClient) { }//
    load() {

        const jsonFile = `assets/configs/config.${environment.name}.json`;
        return new Promise((resolve, reject) => {

            this.http.get(jsonFile).subscribe((response: IAppConfig) => {
                AppConfig.settings = <IAppConfig>response;
                this.settings0.next(response); // = <IAppConfig>response;
                resolve();
            }, (error: any) => {
                reject(`Could not load file '${jsonFile}': ${JSON.stringify(error)}`);
            });

        });
    }
}
