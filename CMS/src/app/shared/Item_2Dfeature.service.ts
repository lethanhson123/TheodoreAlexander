import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_2Dfeature } from 'src/app/shared/Item_2Dfeature.model';
@Injectable({
    providedIn: 'root'
})
export class Item_2DfeatureService {
    list: Item_2Dfeature[] | undefined;
    formData!: Item_2Dfeature;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_2Dfeature";
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
    insertBySQL(formData: Item_2Dfeature) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, Feature_ID2D: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)                        
            .set('Feature_ID2D', Feature_ID2D)  
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

