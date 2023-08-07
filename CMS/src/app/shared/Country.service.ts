import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Country } from 'src/app/shared/Country.model';
@Injectable({
    providedIn: 'root'
})
export class CountryService {
    list: Country[]=[];
    formData!: Country;
    aPIURL: string = environment.APIURL;
    controller: string = "Country";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    GetAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';                             
        return this.httpClient.get(url).toPromise();
    }    
    getBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)                                
        return this.httpClient.get(url, { params }).toPromise();
    }    
}

