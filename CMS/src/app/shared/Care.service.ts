import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Care } from 'src/app/shared/Care.model';
@Injectable({
    providedIn: 'root'
})
export class CareService {
    list: Care[] | undefined;
    formData!: Care;
    aPIURL: string = environment.APIURL;
    controller: string = "Care";
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

