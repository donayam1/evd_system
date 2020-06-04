import { Action } from "@ngrx/store";
import { GroupType } from "../Models/grouptype..models";

export const SELECT_GROUPTYPE_ACTION = "[GROUPTYPE] edit" 
export class SelectGroupTypeAction implements Action{
    type: string;
    payload: GroupType;
    constructor(payload: GroupType){
        this.type = SELECT_GROUPTYPE_ACTION;
        this.payload = payload;
    }
}

export type GroupTypeActions = SelectGroupTypeAction;