import { NamedItem } from "../../Shared/Models/nameditem.model";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";
import { ResponseBase } from "../../Shared/Models/responseBase";


export class Bank extends NamedItem {
    constructor(obj?: any){
        super(obj);
    }
}

export class ListConfigureBankResponse extends PagedItemResponseBase{
    constructor(obj?: any){
        super(obj)
        this.bank = obj && obj.bank && obj.bank.map(cb => new Bank(cb)) || Array();
    }
    bank: Bank[];
}

export class NewBank extends Bank{
    ui_id: string;
    constructor(obj?: any){
        super(obj);
        this.ui_id = obj && obj.ui_id;
    }
}

export class CreateBankResponse extends ResponseBase{
    banks: NewBank[];
    constructor(obj?: any){
        super(obj);
        this.banks = obj && obj.banks && obj.banks.map(bank => new NewBank(bank)) || Array();
    }
}