import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_HistoricalStyle } from 'src/app/shared/Item_HistoricalStyle.model';
@Injectable({
    providedIn: 'root'
})
export class Item_HistoricalStyleService {
    list: Item_HistoricalStyle[] | undefined;
    formData!: Item_HistoricalStyle;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_HistoricalStyle";
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
    insertBySQL(formData: Item_HistoricalStyle) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, HistoricalStyle_ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)                        
            .set('HistoricalStyle_ID', HistoricalStyle_ID)  
        return this.httpClient.get(url, { params }).toPromise();
    }  
}

