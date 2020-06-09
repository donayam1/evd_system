import { ResponseBase } from "../../Shared/Models/responseBase";

export class MoneyDeposit {
    constructor(obj?: any){
        this.id = obj && obj.id;
        this.bankId = obj && obj.bankId;
        this.ammount = obj && obj.ammount;
        this.userId = obj && obj.userId;
        this.isCheque = obj && obj.isCheque;
        this.refNumber = obj && obj.refNumber;
        this.objectStatus = obj && obj.objectStatus;

    }
    id: string;
    bankId: string;
    ammount: number;
    userId: string;
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