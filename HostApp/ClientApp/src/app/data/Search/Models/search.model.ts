import { PagingModel } from '../../Shared/Pagging/Models/pagging.models';

export class SearchModel {
    constructor(obj?: any) {
        this.searchText = obj && obj.searchText || "";
        this.pagingModel = new PagingModel(obj);
        this.searchItem = obj && obj.searchItem || Array();
        this.culture = obj && obj.culture || "en";
    }

    searchText: string;
    pagingModel: PagingModel;
    searchItem: number[];
    culture: string;
}

export class SearchIndex {
    constructor(obj?: any) {
        this.id = obj && obj.id || "";
        this.itemId = obj && obj.itemId || obj && obj.forItemId || "";
        this.name = obj && obj.name || "";
        this.description = obj && obj.description || "";
        this.url = obj && obj.url || "";
        this.picUrl = obj && obj.picUrl || "";
        this.videUrl = obj && obj.videoUrl || "";
        this.itemType = obj && obj.itemType || obj && obj.forItemType || "";
        this.culture = obj && obj.culture || "0";
    }
    id: string;
    itemId: string;
    name: string;
    description: string;
    url: string;
    picUrl: string;
    videUrl: string;
    itemType: number;
    culture: string;
}

export class SearchResult extends SearchModel {
    constructor(obj?: any) {
        super(obj);
        this.results = Array();
    }

    results: SearchIndex[];
}

export enum ItemTypes {
  MOVIE = 10,
  THEATER = 20,
  EVENT = 30,
  TRAVEL = 810
}
