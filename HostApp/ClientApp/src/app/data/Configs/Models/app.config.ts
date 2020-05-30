

export interface IAppConfig {
    env: {
        name: string;
    };
    apiServers: {
        authServer: string;
    };
    authSettings: {
        redirectUri: string;
        clientId: string;
        dummyClientSecret: string;
        oidc: boolean;
        skipSubjectCheck: boolean;
        scope: string;
        issuer: string;
        responseType: string;
        showDebugInformation: boolean;
        requireHttps: boolean;
    }
}