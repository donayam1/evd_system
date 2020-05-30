import { NamedItem } from "../../Shared/Models/nameditem.model";
import { ResponseBase } from "../../Shared/Models/responseBase";

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

export class OperatorResponse extends ResponseBase {

  constructor(obj? : any){
    super(obj);
    this.totalItems = obj && obj.totalItems;
    this.operators = obj && obj.operators.map(op => new Operator(op));
  }
  totalItems: number;
  operators: Operator[];
}
