import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_3Dfeature } from 'src/app/shared/Item_3Dfeature.model';
@Injectable({
    providedIn: 'root'
})
export class Item_3DfeatureService {
    list: Item_3Dfeature[] | undefined;
    formData!: Item_3Dfeature;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_3Dfeature";
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
    insertBySQL(formData: Item_3Dfeature) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, Feature_ID3D: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)                        
            .set('Feature_ID3D', Feature_ID3D)  
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

