
export interface INamedItem{
  id: string;
  name: string;
}

export  class NamedItem implements INamedItem {
  constructor(obj?: any) {
    this.id = obj && obj.id || "";
    this.name = obj && obj.name || "";
    // this.itemType = obj && obj.itemType;
  }
  id: string;
  // itemType: number;
  name: string;
}
