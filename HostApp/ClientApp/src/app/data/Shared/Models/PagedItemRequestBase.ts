
export class PagedItemRequestBase {
    page: number;
    itemsPerPage: number;

    constractor(obj?: any) {
        this.page = obj && obj.page;
        this.itemsPerPage = obj && obj.itemsPerPage;
    }

}

