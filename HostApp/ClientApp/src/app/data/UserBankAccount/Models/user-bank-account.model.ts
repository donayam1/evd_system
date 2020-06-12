import { ObjectStatus } from "../../Shared/Models/newObjectStatus.model";
import { ResponseBase } from "../../Shared/Models/responseBase";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";

export class UserBankAccount {
    id: string;
    bankId: string;
    accountNumber: string;
    userId: string;
    objectStatus: ObjectStatus;
    constructor(obj?: any){
        this.id = obj && obj.id;
        this.bankId = obj && obj.bankId;
        this.accountNumber = obj && obj.accountNumber;
        this.userId = obj && obj.userId;
        this.objectStatus = obj && obj.objectStatus;
    }
}

export class NewUserBankAccount extends UserBankAccount{
    ui_id: string;
    constructor(obj?: any){
        super(obj);
        this.ui_id = obj && obj.ui_id;
    }
}

export class CreateUserBankAccoutResponse extends ResponseBase{
    newUserBankAccount: NewUserBankAccount;
    constructor(obj?: any){
        super(obj);
        this.newUserBankAccount = obj && new NewUserBankAccount(obj) || new NewUserBankAccount();
    }
}

export class ListUserBankAccountResponse extends PagedItemResponseBase {
    constructor(obj?: any){
        super(obj);
        this.bankAccounts = obj && obj.bankAccounts && obj.bankAccounts.map(uba => new UserBankAccount(uba)) || Array();
    }
    bankAccounts: UserBankAccount[];
}

export class UserBankAccountResponse extends ResponseBase{
    userBa: UserBankAccount;
    constructor(obj?: any){
        super(obj);
        this.userBa = new UserBankAccount();
    }
}