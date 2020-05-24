import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { CookieOAuthStorage } from '../data/Account/Services/CookieOauthStorage';
import { Language } from '../data/Language/Models/language.model';
import { LanguageState, SelectCultureState } from '../data/Language/Reducers/language.reducers';
import { Store } from '@ngrx/store';
import { SetCultureAction } from '../data/Language/Actions/language.actions';
import { Router } from '@angular/router';



@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent implements OnInit {

  model:Language[];
  lang:Language;
  constructor(private translate:TranslateService,
    private cookieOauthStorage:CookieOAuthStorage,
    private store:Store<LanguageState>,
    private router:Router
  ) { 
      const langEn = new Language({'flagIcon':'us',shortCode:'en',text:"English"});
      let culture = this.cookieOauthStorage.getLanguage();
      if(culture.shortCode === undefined)
      {
        culture = langEn;
        // this.cookieOauthStorage.saveLanguage(culture);
      }
      const a = new SetCultureAction(culture);
      this.store.dispatch(a); 

      this.model = Array();
      this.model.push(new Language({'flagIcon': 'et', shortCode: 'am', text: "አማርኛ"}));
      this.model.push(new Language({'flagIcon': 'us', shortCode: 'en', text: "English"}));

  }

  ngOnInit() {
    this.store.select(SelectCultureState).subscribe((x: LanguageState) => {
        this.lang = x.culture;
        this.cookieOauthStorage.saveLanguage(this.lang);
        this.translate.use(this.lang.shortCode);
    });
  }

  useLanguage(lang: Language) {
    // this.lang = this.cookieOauthStorage.getLanguage();
    if (lang.shortCode === this.lang.shortCode)
    {
    } else {


      this.cookieOauthStorage.saveLanguage(lang);
      const a = new SetCultureAction(lang);
      this.store.dispatch(a);
      this.router.navigate(['/externalRedirect',{externalUrl:document.location.href}],{
        skipLocationChange: true,
      });

      // this.lang = lang;
      // this.translate.use(lang.shortCode);

    }
  }
}
