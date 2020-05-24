
import $ from "jquery";
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";


@Injectable({
    providedIn:'root'
})
export class FilePickerService  {
  constructor() { 
  }

  Select():Observable<string> {

    const obs = Observable.create(observer=>{

      const opener = window.open("./FileManager/index.html", 'targetWindow',
        'toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=800, height=800');
      // var $that = this;
      function handlePostMessage(e:any) {
          const data = e.originalEvent.data;
          // console.log('js-data', data);
          // $that.model.posterUrl = data.preview_url;
          observer.next(data.preview_url);
          if (data.source === 'richfilemanager') {
              $('#js-window-input').val(data.preview_url);
              opener.close();
          }
          // remove an event handler
          $(window).off('message', handlePostMessage);
      }
      $(window).on('message', handlePostMessage);

    });

    return obs;
  }



}