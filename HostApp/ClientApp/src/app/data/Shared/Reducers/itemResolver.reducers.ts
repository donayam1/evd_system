import { SearchIndex } from '../../Search/Models/search.model';
import { SearchIndexTypes, SEARCHINDEX_LOADED_ACTION,
         SearchIndexLoadedAction } from '../Actions/itemResoovler.actions';
import { createSelector } from '@ngrx/store';



export class ItemResolversState {
    searchIndexes: SearchIndex[] ; // ItemSchedule[];
}

const initItemResolversState = {
    searchIndexes: [],
};

export function ItemResolverReducer(state: ItemResolversState= initItemResolversState,
                                    action: SearchIndexTypes):
ItemResolversState {
    switch (action.type) {
        case SEARCHINDEX_LOADED_ACTION:
            const v = <SearchIndexLoadedAction>action;
            return {...state, searchIndexes: [...state.searchIndexes, v.payload]}; // TODO dont add repeated elements
        default:
            return state;
    }
}

export const searchIndexs = (state: any) => state.searchIndexes;


export const SelectSearchIndexes = createSelector(
    searchIndexs,
    (state: ItemResolversState) => state.searchIndexes
);
export const SelectSearchIndexForItem = createSelector(
    SelectSearchIndexes,
    (items: SearchIndex[]) => (itemId: String, itemType: number) =>
            items.find(a => a.itemId === itemId && a.itemType === itemType)
);
