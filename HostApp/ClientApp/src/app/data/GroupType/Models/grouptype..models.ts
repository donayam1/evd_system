import { extend } from "webdriver-js-extender";
import { ResponseBase } from "../../Shared/Models/responseBase";
import { NamedItem } from '../../Shared/Models/nameditem.model';

export class GroupType extends NamedItem {
    constructor(obj?: any) {
        super(obj);
        // this.id = obj && obj.id;
        // this.name = obj && obj.name;
        this.level = obj && obj.level || -1;
        this.objectStatus = obj && obj.objectStatus;
    }

    // id: number;
    // name: string;
    level: number;
    objectStatus: number;
}

export class GroupTypesResponse extends ResponseBase {
    constructor(obj?: any) {
        super(obj);
        this.totalItems = obj && obj.totalItems;
        this.groupTypes = obj && obj.roleTypes.map(x => new GroupType(x)) || Array();
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
