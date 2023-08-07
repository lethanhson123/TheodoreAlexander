import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ColourAndFinish } from 'src/app/shared/ColourAndFinish.model';
@Injectable({
    providedIn: 'root'
})
export class ColourAndFinishService {
    list: ColourAndFinish[] | undefined;
    formData!: ColourAndFinish;
    aPIURL: string = environment.APIURL;
    controller: string = "ColourAndFinish";
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

