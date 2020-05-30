import { extend } from "webdriver-js-extender";
import { ResponseBase } from "../../Shared/Models/responseBase";
import { NamedItem } from '../../Shared/Models/nameditem.model';

export class GroupType extends NamedItem {
    constructor(obj?: any) {
        super(obj);
        // this.id = obj && obj.id;
        // this.name = obj && obj.name;
        this.level = obj && obj.level;
        this.status = obj && obj.status;
    }

    // id: number;
    // name: string;
    level: number;
    status: string;
}

export class GroupTypesResponse extends ResponseBase {
     
    constructor(obj?: any) {
        super(obj);
        this.totalItems = obj && obj.totalItems;
        this.groupTypes = obj && obj.roleTypes.map(x => new GroupType(x));

    }

    totalItems: number;
    groupTypes: GroupType[];
}

export class GroupTypeResponse extends ResponseBase {
     
    constructor(obj?: any) {
        super(obj);
        this.totalItems = obj && obj.totalItems;
        this.groupType = obj && new GroupType(obj);

    }

    totalItems: number;
    groupType: GroupType;
}