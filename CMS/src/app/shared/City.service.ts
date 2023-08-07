import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { City } from 'src/app/shared/City.model';
@Injectable({
    providedIn: 'root'
})
export class CityService {
    list: City[] | undefined;
    formData!: City;
    aPIURL: string = environment.APIURL;
    controller: string = "City";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    getByRegionIDOrSearchStringToList(regionID: string, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByRegionIDOrSearchStringToList';
        const params = new HttpParams()
            .set('regionID', regionID)        
            .set('searchString', searchString)        
        return this.httpClient.get(url, {params}).toPromise();
    }    
}

