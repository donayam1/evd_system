
import { Action } from '@ngrx/store';
import { SearchIndex } from '../../Search/Models/search.model';
// import { type } from 'os';
// import { ScheduleModel } from '../../Reservation/Models/reservation.models';
export const SEARCHINDEX_LOADED_ACTION = "[ItemResolver] schedule loaded";


export class SearchIndexLoadedAction implements Action {
    type: string;
    payload: SearchIndex;
    constructor(payload: SearchIndex) {
        this.type = SEARCHINDEX_LOADED_ACTION;
        this.payload = payload;
    }
}

export type SearchIndexTypes = SearchIndexLoadedAction ;
