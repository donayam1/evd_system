import { ResponseBase } from "./responseBase";


export class PagedItemResponseBase extends ResponseBase {
    totalItems: number;
    constractor(obj?: any) {
        this.totalItems = obj && obj.totalItems;
    }

}
