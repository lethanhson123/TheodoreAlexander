import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SKUListingForSizeAvailability } from 'src/app/shared/SKUListingForSizeAvailability.model';
@Injectable({
    providedIn: 'root'
})
export class SKUListingForSizeAvailabilityService {
    list: SKUListingForSizeAvailability[] | undefined;
    formData!: SKUListingForSizeAvailability;
    aPIURL: string = environment.APIURL;
    controller: string = "SKUListingForSizeAvailability";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }        
    getByItem_IDToList(Item_ID: any) {
        let url = this.aPIURL + this.controller + '/GetByItem_IDToList';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)            
        return this.httpClient.get(url, { params }).toPromise();
    }   
    insertBySQL(formData: SKUListingForSizeAvailability) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('ID', ID)                        
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

