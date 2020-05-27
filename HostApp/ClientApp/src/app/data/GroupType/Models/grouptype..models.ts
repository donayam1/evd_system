import { extend } from "webdriver-js-extender";
import { ResponseBase } from "../../Shared/Models/responseBase";

export class GroupType {
    push(arg0: GroupType) {
        //To DB
      throw new Error("Method not implemented.");
    }

    constructor(obj?: any) {
        this.id = obj && obj.id;

    }

    id: number;
    name: string;
    level: number;
    status: string;
}

export class GroupTypesResponse extends ResponseBase {

    constructor(obj?: any) {
        super(obj);
        this.totalItems = obj && obj.totalItems;
        this.groupTypes = obj && obj.groupTypes.map(x => new GroupType(x));

    }

    totalItems: number;
    groupTypes: GroupType[];
}
