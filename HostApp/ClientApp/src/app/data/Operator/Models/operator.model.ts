import { NamedItem } from "../../Shared/Models/nameditem.model";
import { ResponseBase } from "../../Shared/Models/responseBase";
import { PagedItemResponseBase } from "../../Shared/Models/PagedItemResponseBase";

export class Operator extends NamedItem {
  constructor(obj?: any) {
    super(obj);
    this.uSSDRechargeCode = obj && obj.uSSDRechargeCode;
    this.status = obj && obj.status;
    this.lastUpdatedDate = obj && obj.lastUpdatedDate;
  }
  uSSDRechargeCode: string;
  status: number;
  lastUpdatedDate: Date;
}

export class ListOperatorResponse extends PagedItemResponseBase {

  constructor(obj?: any) {
    super(obj);
    this.operators = obj && obj.operators.map(op => new Operator(op));
  }
  operators: Operator[];
}

export class NewOperatorResponse extends ResponseBase {
  operator: Operator;

  constructor(obj?: any) {
    super(obj);
    this.operator = obj && new Operator(obj);
  }
}
