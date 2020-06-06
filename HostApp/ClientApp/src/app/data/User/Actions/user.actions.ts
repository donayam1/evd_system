import {Action} from "@ngrx/store"
import { Users } from "../Models/user.model";


export const  SELECT_USER_ACTION = "[USER]  detail"

export class SelectUserAction implements Action{
    type: string;
    paylod: Users;
    constructor(payload: Users){
        this.type = SELECT_USER_ACTION;
        this.paylod = payload;
    }
}

export type UserActions = SelectUserAction;