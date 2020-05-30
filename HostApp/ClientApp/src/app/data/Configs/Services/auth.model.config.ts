import { OAuthModuleConfig, OAuthResourceServerConfig, AuthConfig } from 'angular-oauth2-oidc';
import { AppConfig } from './app.config';
import { Injectable } from '@angular/core';


@Injectable()
export class MyAuthConfig extends OAuthModuleConfig{


    constructor(private appConfig:AppConfig) {
        super();
        this.getResourceServerConfig();
    }

    getResourceServerConfig(){
        this.appConfig.settings0.subscribe(x => {
            const y = {
                allowedUrls: [AppConfig.settings.apiServers.authServer],
                sendAccessToken: true
            };
            this.resourceServer = y;
        })
        // if(this.appConfig.settings0 !== undefined && this.appConfig.settings0 != null){
        //     return {
        //         allowedUrls: [this.appConfig..apiServers.moviesBackendServer],
        //         sendAccessToken: true
        //     };
        // }
        // return {
        //     allowedUrls: [],
        //     sendAccessToken: false
        // };
    }
}