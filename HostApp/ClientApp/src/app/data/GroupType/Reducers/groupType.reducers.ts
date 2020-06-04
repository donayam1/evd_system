import { GroupType } from "../Models/grouptype..models";
import { GroupTypeActions, SELECT_GROUPTYPE_ACTION } from "../Actions/groupType.actions";
import { createFeatureSelector, createSelector } from "@ngrx/store";

export class GroupTypeState {
    groupType: GroupType;
}

const initGroupTypeState = {
    groupType : null
}

export function GroupTypeReducers(state : GroupTypeState = initGroupTypeState , action: GroupTypeActions ):GroupTypeState{
    switch(action.type){
        case SELECT_GROUPTYPE_ACTION:
            return {...state, groupType: action.payload};
        default:
            return state;
    }
}

export const selectGroupTypeState = createFeatureSelector<GroupTypeState>("groupTypes");
export const selectCurrentGroupType = createSelector(
    selectGroupTypeState,
    (state: GroupTypeState)=>state.groupType
);