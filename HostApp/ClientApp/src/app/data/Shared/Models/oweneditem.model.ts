import { INamedItem } from './nameditem.model';



export class OwnerItem {
    constructor(obj?: any) {
        this.itemType = obj && obj.itemType || 0;
        this.itemId = obj && obj.itemId || "";
    }
    itemType: number;
    itemId: string;
}
export class OwnedItem {
    constructor(obj?: any) {
        this.ownerId = obj && obj.itemId || obj && obj.ownerId || "";
        this.ownerType = obj && obj.itemType || obj && obj.ownerType || 0;
    }

    ownerId: string;
    ownerType: number;
}

export class NamedOwnedItem extends OwnedItem implements INamedItem {
    id: string;
    name: string;
    constructor(obj?: any) {
        super(obj);
        this.id = obj && obj.id || "";
        this.name = obj && obj.name || "";
    }
}