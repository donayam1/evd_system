
export class PagedItemRequestBase {
    page: number;
    itemsPerPage: number;

    constructor(obj?: any) {
        this.page = obj && obj.page || 1;
        this.itemsPerPage = obj && obj.itemsPerPage || 10;
    }

}

