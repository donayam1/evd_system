import { ResponseBase } from "../../Shared/Models/responseBase";

export class MoneyDeposit {
    constructor(obj?: any){
        this.id = obj && obj.id;
        this.bankId = obj && obj.bankId;
        this.amount = obj && obj.amount;
        this.forUserId = obj && obj.forUserId;
        this.isCheque = obj && obj.isCheque || false;
        this.referanceNumber = obj && obj.referanceNumber;
        this.objectStatus = obj && obj.objectStatus;

    }
    id: string;
    bankId: string;
    amount: number;
    forUserId: string;
    isCheque: boolean;
    referanceNumber: string;
    objectStatus: number;
}

export class ListDepositResponse extends ResponseBase{
    constructor(obj?: any){
        super(obj);
        this.response = obj && obj.response && obj.response.map(md => new MoneyDeposit(md)) || Array();
    }
    response: MoneyDeposit[];

} 

export class NewMoneyDeposit extends MoneyDeposit{
    ui_id: string;
    constructor(obj?: any){
        super(obj);
        this.ui_id = obj && obj.ui_id
    }
}

export class CreateMoneyDepositResponse extends ResponseBase{
    newMoneyDeposit: NewMoneyDeposit;
    constructor(obj?: any){
        super(obj);
        this.newMoneyDeposit = obj && new NewMoneyDeposit(obj) || new NewMoneyDeposit();
    }
}