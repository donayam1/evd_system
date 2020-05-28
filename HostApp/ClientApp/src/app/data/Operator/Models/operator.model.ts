import { NamedItem } from "../../Shared/Models/nameditem.model";

export class Operator extends NamedItem {
  constructor(obj?: any) {
    super();
    //this.id = obj && obj.id;
    //this.name = obj && obj.name;
    this.ussdCode = obj && obj.ussdCode;
    this.status = obj && obj.status;
    this.lastUpdate = obj && obj.lastUpdate;
  }
  ussdCode: string;
  status: number;
  lastUpdate: Date;
}
