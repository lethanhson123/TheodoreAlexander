import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HistoricalStyle } from 'src/app/shared/HistoricalStyle.model';
@Injectable({
    providedIn: 'root'
})
export class HistoricalStyleService {
    list: HistoricalStyle[] | undefined;
    formData!: HistoricalStyle;
    aPIURL: string = environment.APIURL;
    controller: string = "HistoricalStyle";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    getAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';
        return this.httpClient.get(url).toPromise();
    }    
}

