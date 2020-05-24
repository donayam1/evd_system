import { NetworkStatus } from './NetworkStatus';



export class Resource<T> {

    

    constructor(public status:NetworkStatus, 
        public data?:T, public message?:string) {

    }

    static  Error<T>(message:string):any {
        return new Resource<T>(NetworkStatus.ERROR,null, message);
    }
    static  Success<T>(data:T):any {
        return new Resource<T>(NetworkStatus.SUCCESS, data,"");
    }

    static  Loading<T>():any {
        return new Resource<T>(NetworkStatus.LOADING);
    }
    
    
}

