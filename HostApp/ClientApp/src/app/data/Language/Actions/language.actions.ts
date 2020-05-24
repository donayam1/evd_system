import { Action } from '@ngrx/store';
import { Language } from '../Models/language.model';

export const SET_CULTURE_ACTION="[Language] set culture";


export class SetCultureAction implements Action{
    type:string;
    payload:Language;
    constructor(payload:Language){
        this.type = SET_CULTURE_ACTION;
        this.payload = payload;
    }
}

export type LangugeActions = SetCultureAction;