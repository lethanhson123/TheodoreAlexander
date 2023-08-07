import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Continent } from 'src/app/shared/Continent.model';
@Injectable({
    providedIn: 'root'
})
export class ContinentService {
    list: Continent[] | undefined;
    formData!: Continent;
    aPIURL: string = environment.APIURL;
    controller: string = "Continent";
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

