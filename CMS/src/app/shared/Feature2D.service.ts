import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Feature2D } from 'src/app/shared/Feature2D.model';
@Injectable({
    providedIn: 'root'
})
export class Feature2DService {
    list: Feature2D[] | undefined;
    formData!: Feature2D;
    aPIURL: string = environment.APIURL;
    controller: string = "Feature2D";
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

