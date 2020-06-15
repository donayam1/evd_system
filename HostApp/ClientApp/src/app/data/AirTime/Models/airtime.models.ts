import { ResponseBase } from '../../Shared/Models/responseBase';

export class AirTimeModel  {
    id: String ;
    airTime: String;
    lastUpdatedDate: String;
    objectStatus: number;

    constructor(obj?: any){
        this.id = obj && obj.id;
        this.airTime = obj && obj.airTime;
        this.lastUpdatedDate = obj && obj.lastUpdatedDate;
        this.objectStatus = obj && obj.objectStatus;
    }
}

export class AirTimeResponse extends ResponseBase {
    airTime: AirTimeModel;
    constructor(obj?: any) {
        super(obj);
        this.airTime = obj && new AirTimeModel(obj.airTime);
    }
}

