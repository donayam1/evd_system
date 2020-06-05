import { createSelector } from '@ngrx/store';
import { createFeatureSelector } from '@ngrx/store';
import { SelectOperatorAction } from './../Action/operator.actions';
import { Operator } from 'src/app/data/Operator/Models/operator.model';
import { OperatorActions, SELECT_OPERATOR_ACTION } from '../Action/operator.actions';

export class OperatorState{
    selectedOperator: Operator;
}

const initOperatorState = {
    selectedOperator: null
};

export function OperatorReducers(state: OperatorState = initOperatorState, action: OperatorActions): OperatorState{
    switch(action.type){
        case SELECT_OPERATOR_ACTION:
            return{...state, selectedOperator: action.payload};
        default:
            return state;
    }
}

export const SelectOperatorState = createFeatureSelector<OperatorState>("opr");
export const SelectCurrentOperator = createSelector(
    SelectOperatorState,
    (state: OperatorState) => state.selectedOperator
);