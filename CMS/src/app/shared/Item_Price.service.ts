import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_Price } from 'src/app/shared/Item_Price.model';
@Injectable({
    providedIn: 'root'
})
export class Item_PriceService {
    list: Item_Price[] | undefined;
    formData!: Item_Price;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_Price";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    updateBySQL(formData: Item_Price) {
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

