import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Geography } from 'src/app/shared/Geography.model';
@Injectable({
    providedIn: 'root'
})
export class GeographyService {
    list: Geography[] | undefined;
    formData!: Geography;
    aPIURL: string = environment.APIURL;
    controller: string = "Geography";
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

