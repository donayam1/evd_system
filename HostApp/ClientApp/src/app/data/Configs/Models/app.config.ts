

export interface IAppConfig{
    env:{
        name:string;
    };
    apiServers:{
        authServer:string;
        moviesBackendServer:string;
        billingServer:string;
        moivesFrontendServer:string;
    };
    authSettings:{
        redirectUri: string;
        clientId: string;
        dummyClientSecret: string;
        oidc:boolean;
        skipSubjectCheck:boolean;
        scope: string;
        issuer: string;
        responseType:string;
        showDebugInformation: boolean;
        requireHttps:boolean;
    }
}