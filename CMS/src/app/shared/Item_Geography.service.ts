import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_Geography } from 'src/app/shared/Item_Geography.model';
@Injectable({
    providedIn: 'root'
})
export class Item_GeographyService {
    list: Item_Geography[] | undefined;
    formData!: Item_Geography;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_Geography";
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
    insertBySQL(formData: Item_Geography) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, Geography_ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)                        
            .set('Geography_ID', Geography_ID)  
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

