
export class User{
    constructor(obj?:any)
    {
        this.UserName = obj && obj.UserName || obj&&obj.name || "";
        this.Id = obj && obj.Id || obj && obj.id || "";
        this.PicUrl = obj && obj.PicUrl|| obj&& obj.picUrl || "assets/images/user.jpg";
    }
    UserName:string;
    Id:string;
    PicUrl:string;  
}
export class CurrentUser extends User{
    constructor(obj?:any)
    {
        super(obj);
        this.Token = obj&&obj.Token || "";
    }
    Token?:string;
}