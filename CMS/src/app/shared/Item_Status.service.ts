import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_Status } from 'src/app/shared/Item_Status.model';
@Injectable({
    providedIn: 'root'
})
export class Item_StatusService {
    list: Item_Status[] | undefined;
    formData!: Item_Status;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_Status";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    updateBySQL(formData: Item_Status) {
        let url = this.aPIURL + this.controller + '/UpdateBySQL';
        return this.httpClient.put(url, formData);
    }   
    getBySKUToList(SKU: any) {
        let url = this.aPIURL + this.controller + '/GetBySKUToList';
        const params = new HttpParams()
            .set('SKU', SKU)            
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

