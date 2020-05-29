import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {
    constructor(private http: HttpClient) {
    }

    uploadFiles(file: File, url: string): Observable<any> {

        const formDate: FormData = new FormData();
        formDate.append('theFile', file, file.name);
        return this.http.post(url, formDate);

    }

}
