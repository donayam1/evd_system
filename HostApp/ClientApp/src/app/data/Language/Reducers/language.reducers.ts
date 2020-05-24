import { LangugeActions, SET_CULTURE_ACTION } from '../Actions/language.actions';
import {  createSelector } from '@ngrx/store';
import { Language } from '../Models/language.model';


export class LanguageState{
    culture:Language;
}

const initLanguageState={
    culture:new Language({'flagIcon':'us',shortCode:'en',text:"English"})
}

export function LanguageReducers(state:LanguageState=initLanguageState,action:LangugeActions):LanguageState{
    switch(action.type)
    {
        case SET_CULTURE_ACTION:
             return{...state,culture:action.payload};
        default:
            return state;     
    }
}

export const SelectCultureState = (state:any) => state.culture;// createFeatureSelector<LanguageState>("lang");
export const SelectCurrentCulture = createSelector(
    SelectCultureState,
    (state:LanguageState) => state.culture
);