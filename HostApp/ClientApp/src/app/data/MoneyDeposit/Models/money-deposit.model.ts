import { ResponseBase } from "../../Shared/Models/responseBase";

export class MoneyDeposit {
    constructor(obj?: any){
        this.id = obj && obj.id;
        this.bankId = obj && obj.bankId;
        this.ammount = obj && obj.ammount;
        this.forUserId = obj && obj.forUserId;
        this.isCheque = obj && obj.isCheque || false;
        this.refNumber = obj && obj.refNumber;
        this.objectStatus = obj && obj.objectStatus;

    }
    id: string;
    bankId: string;
    ammount: number;
    forUserId: string;
    isCheque: boolean;
    refNumber: string;
    objectStatus: number;
}

export class ListDepositResponse extends ResponseBase{
    constructor(obj?: any){
        super(obj);
        this.moneyDeposit = obj && obj.moneyDeposit && obj.moneyDeposit.map(md => new MoneyDeposit(md)) || Array();
    }
    moneyDeposit: MoneyDeposit[];

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