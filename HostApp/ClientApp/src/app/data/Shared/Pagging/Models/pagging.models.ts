import { OwnedItem } from '../../Models/oweneditem.model';


export class PagingModel extends OwnedItem {
    
    constructor(obj?: any) {
        super(obj);
        this.currentPage = obj && obj.currentPage || 0;
        this.totalItems = obj && obj.totalItems || 0;
        this.itemsPerPage = obj && obj.itemsPerPage || 10;
        this.isReady = true;
    }
    isReady:boolean;
    currentPage: number;
    totalItems: number;
    itemsPerPage: number;
}