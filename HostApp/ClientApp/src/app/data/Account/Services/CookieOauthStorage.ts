import { OAuthStorage } from 'angular-oauth2-oidc';
import { CookieService } from 'angular2-cookie';
import { CurrentUser } from '../Models/user.model';
import { Injectable } from '@angular/core';
import { Language } from '../../Language/Models/language.model';

const USERNAME_KEY = 'UserName';
const ACCESSTOKEN_KEY = 'access_token';
const ID_KEY = 'Id';
const PROFILE_PIC_KEY = 'ProPic';

const LANGUAGE_FLAG_ICON = "langFg";
const LANGUAGE_TEXT = "langText";
const LANGUAGE_ShortCode = "langSC";

@Injectable({
    providedIn: 'root'
})
export class CookieOAuthStorage extends OAuthStorage {

    constructor(private cookieService: CookieService) {
        super();
    }
    getItem(key: string): string | null {
        return this.cookieService.get(key);
    }
    removeItem(key: string): void {
        this.cookieService.remove(key);
    }
    setItem(key: string, data: string): void {
        this.cookieService.put(key, data);
    }
    saveUser(user: CurrentUser) {
        this.setItem(USERNAME_KEY, user.UserName);
        this.setItem(PROFILE_PIC_KEY, user.PicUrl);
        // this.setItem(ACCESSTOKEN_KEY,user.Token);
        this.setItem(ID_KEY, user.Id);
    }
    getUser(): CurrentUser {
        const userName = this.getItem(USERNAME_KEY);
        const profilePicUrl = this.getItem(PROFILE_PIC_KEY);
        const tok = this.getItem(ACCESSTOKEN_KEY);
        const id = this.getItem(ID_KEY);
        const user = new CurrentUser({ UserName: userName, PicUrl: profilePicUrl, Id: id, Token: tok });
        return user;
    }
    getAccessToken(): string {
        return this.getItem(ACCESSTOKEN_KEY);
    }
    cleanSessionData(): void {
        this.removeItem(USERNAME_KEY);
        this.removeItem(PROFILE_PIC_KEY);
        // this.removeItem(ACCESSTOKEN_KEY);
        this.removeItem(ID_KEY);
    }
    saveLanguage(lang: Language) {
        this.setItem(LANGUAGE_FLAG_ICON, lang.flagIcon);
        this.setItem(LANGUAGE_ShortCode, lang.shortCode);
        this.setItem(LANGUAGE_TEXT, lang.text);
    }
    getLanguage(): Language {

        const icon = this.getItem(LANGUAGE_FLAG_ICON);
        const sc = this.getItem(LANGUAGE_ShortCode);
        const txt = this.getItem(LANGUAGE_TEXT);
        const nl: Language = new Language();
        nl.flagIcon = icon;
        nl.shortCode = sc;
        nl.text = txt;
        return nl;
    }
}