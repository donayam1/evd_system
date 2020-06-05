import { Action } from '@ngrx/store';
import { Operator } from '../Models/operator.model';

export const SELECT_OPERATOR_ACTION = "[Operator] select operator"

export class SelectOperatorAction implements Action{
    type: string;
    payload: Operator;
    
    constructor(payload: Operator){
        this.type = SELECT_OPERATOR_ACTION;
        this.payload = payload;
    }

}

export type OperatorActions = SelectOperatorAction;