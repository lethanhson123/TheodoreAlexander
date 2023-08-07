import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_Century } from 'src/app/shared/Item_Century.model';
@Injectable({
    providedIn: 'root'
})
export class Item_CenturyService {
    list: Item_Century[] | undefined;
    formData!: Item_Century;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_Century";
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
    insertBySQL(formData: Item_Century) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, Century_ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)                        
            .set('Century_ID', Century_ID)  
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

