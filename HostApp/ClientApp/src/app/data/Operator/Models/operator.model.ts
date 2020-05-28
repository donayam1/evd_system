export class Operator {
    id: number;
    name: string;
    ussdCode: string;
    status: string;
    lastupdate: Date;

    constructor(obj?: any){
        this.id = obj && obj.id;
        this.name = obj && obj.name;
        this.ussdCode = obj && obj.ussdCode;
        this.status = obj && obj.status;
        this.lastupdate = obj && obj.lastupdate;        
    }
}
