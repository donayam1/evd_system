

export class Language{
    constructor(obj?:any){
      this.flagIcon = obj && obj.flagIcon;
      this.text = obj && obj.text;
      this.shortCode = obj && obj.shortCode;
    }
    flagIcon:string;
    text:string;
    shortCode:string;
  }
  