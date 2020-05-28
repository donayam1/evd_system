import { extend } from "webdriver-js-extender";
import { ResponseBase } from "../../Shared/Models/responseBase";

export class GroupType {
    constructor(obj?: any) {
        this.id = obj && obj.id;
        this.name = obj && obj.name;
        this.level = obj && obj.level;
        this.status = obj && obj.status;
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
