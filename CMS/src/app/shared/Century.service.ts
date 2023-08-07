import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Century } from 'src/app/shared/Century.model';
@Injectable({
    providedIn: 'root'
})
export class CenturyService {
    list: Century[] | undefined;
    formData!: Century;
    aPIURL: string = environment.APIURL;
    controller: string = "Century";
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

