import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UPHColour } from 'src/app/shared/UPHColour.model';
@Injectable({
    providedIn: 'root'
})
export class UPHColourService {
    list: UPHColour[] | undefined;
    formData: UPHColour | undefined;
    aPIURL: string = environment.APIURL;
    controller: string = "UPHColour";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    update(formData: UPHColour) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    getAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';       
        return this.httpClient.get(url).toPromise();
    }
}

