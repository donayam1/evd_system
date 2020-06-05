import { User } from './../../Account/Models/user.model';
import { ResponseBase } from 'src/app/data/Shared/Models/responseBase';
import { NamedItem } from "../../Shared/Models/nameditem.model";
import { PagedItemResponseBase } from '../../Shared/Models/PagedItemResponseBase';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';


export class Users extends User {
    email: string;
    phoneNumber: string;
    firstName: string;
    middleName: string;
    lastName: string;
    rankId: string;
    planId: string;
    userStatus: string;
    objectStatus: number;
    constructor(obj?: any) {
        super(obj);
        this.email = obj && obj.email;
        this.phoneNumber = obj && obj.phoneNumber;
        this.firstName = obj && obj.firstName;
        this.middleName = obj && obj.middleName;
        this.lastName = obj && obj.lastName;
        this.rankId = obj && obj.rankId;
        this.planId = obj && obj.planId;
        this.objectStatus = obj && obj.objectStatus;
        this.userStatus = obj && obj.userStatus
    }
}

export class NewUser extends User {
    email: string;
    phoneNumber: string;
    firstName: string;
    middleName: string;
    lastName: string;
    rankId: string;
    planId: string;
    objectStatus: number;

    constructor(obj?: any) {
        super(obj);
        this.email = obj && obj.email;
        this.phoneNumber = obj && obj.phoneNumber;
        this.firstName = obj && obj.firstName;
        this.middleName = obj && obj.middleName || "";
        this.lastName = obj && obj.lastName;
        this.rankId = obj && obj.rankId;
        this.planId = obj && obj.planId;
        this.objectStatus = obj && obj.objectStatus;
    }
}

export class Permission {
    value: string;
    name: string;
    description: string;

    constructor(obj?: any) {
        this.value = obj && obj.value;
        this.name = obj && obj.name;
        this.description = obj && obj.description;
    }
}

export class PremissionGroup {
    permissions: Permission[];
    name: string;
    description: string;

    constructor(obj?: any) {
        this.permissions = obj && obj.permissions.map(permission => new Permission(permission)) || Array();
        this.name = obj && obj.name;
        this.description = obj && obj.description;
    }
}

export class NewUserResponse extends ResponseBase{
    newUser: NewUser;

    constructor(obj?: any) {
        super(obj);
        this.newUser = obj &&  new NewUser(obj) || new NewUser();
    }
}


export class ListUserResponse extends PagedItemResponseBase {
    constructor(obj?: any) {
        super(obj);
        this.users = obj && obj.users.map(user => new Users(user));

    }
    users: Users[];
}