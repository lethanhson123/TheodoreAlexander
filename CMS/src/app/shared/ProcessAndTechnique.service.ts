import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ProcessAndTechnique } from 'src/app/shared/ProcessAndTechnique.model';
@Injectable({
    providedIn: 'root'
})
export class ProcessAndTechniqueService {
    list: ProcessAndTechnique[] | undefined;
    formData!: ProcessAndTechnique;
    aPIURL: string = environment.APIURL;
    controller: string = "ProcessAndTechnique";
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

