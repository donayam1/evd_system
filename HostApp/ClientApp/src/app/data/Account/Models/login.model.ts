import {User} from './user.model';

export class LogInModel extends User{    
    Password:string;
    ReturnUrl:String;
    RememberMe:Boolean;
}