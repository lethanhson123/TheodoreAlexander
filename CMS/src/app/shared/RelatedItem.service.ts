import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { RelatedItem } from 'src/app/shared/RelatedItem.model';
@Injectable({
    providedIn: 'root'
})
export class RelatedItemService {
    list: RelatedItem[] | undefined;
    formData!: RelatedItem;
    aPIURL: string = environment.APIURL;
    controller: string = "RelatedItem";
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
    insertBySQL(formData: RelatedItem) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, RelatedItem_ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)            
            .set('RelatedItem_ID', RelatedItem_ID)  
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

