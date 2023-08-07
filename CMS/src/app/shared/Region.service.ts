import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Region } from 'src/app/shared/Region.model';
@Injectable({
    providedIn: 'root'
})
export class RegionService {
    list: Region[] = [];
    formData!: Region;
    aPIURL: string = environment.APIURL;
    controller: string = "Region";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {       
    }   
    getByCountryIDToList(countryID: string) {
        let url = this.aPIURL + this.controller + '/GetByCountryIDToList?countryID=' + countryID;
        return this.httpClient.get(url).toPromise();
    }
    getByCountryIDOrSearchStringToList(countryID: string, searchString: string) {        
        let url = this.aPIURL + this.controller + '/GetByCountryIDOrSearchStringToList';
        const params = new HttpParams()
            .set('countryID', countryID)       
            .set('searchString', searchString)              
        return this.httpClient.get(url, {params}).toPromise();
    }
}

