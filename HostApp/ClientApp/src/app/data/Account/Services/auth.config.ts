import { AuthConfig } from 'angular-oauth2-oidc';


export const authConfigPassword: AuthConfig = {

    redirectUri : "http://localhost:6872",// window.location.origin;
    clientId : 'movies_admin',//'roclient',//'mvc.implicit',// 'mvc.implicit',//'js',  roclient.public  
    dummyClientSecret: 'secret',
    oidc:true, //for password flow 
    skipSubjectCheck:true,     //I don't know why this check is necessary during password flow, 
                               //the code is basically checking aginest empty store. 
    scope :'profile openid email MoviesApi ReservationApi',//api1 openid usersApi app
    issuer:"http://localhost:5000",         
    responseType:"token id_token", //token 
    showDebugInformation : true    
}

