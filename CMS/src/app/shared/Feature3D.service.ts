import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Feature3D } from 'src/app/shared/Feature3D.model';
@Injectable({
    providedIn: 'root'
})
export class Feature3DService {
    list: Feature3D[] | undefined;
    formData!: Feature3D;
    aPIURL: string = environment.APIURL;
    controller: string = "Feature3D";
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

