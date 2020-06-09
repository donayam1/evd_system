import { NamedItem } from "../../Shared/Models/nameditem.model";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";


export class ConfigureBank extends NamedItem {
    constructor(obj?: any){
        super(obj);
    }
}

export class ListConfigureBankResponse extends PagedItemResponseBase{
    constructor(obj?: any){
        super(obj)
        this.configureBank = obj && obj.configureBank && obj.configureBank.map(cb => new ConfigureBank(cb)) || Array();
    }
    configureBank: ConfigureBank[];
}