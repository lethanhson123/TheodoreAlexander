import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { RelatedSkuForSpecialGroup } from 'src/app/shared/RelatedSkuForSpecialGroup.model';
@Injectable({
    providedIn: 'root'
})
export class RelatedSkuForSpecialGroupService {
    list: RelatedSkuForSpecialGroup[] | undefined;
    formData!: RelatedSkuForSpecialGroup;
    aPIURL: string = environment.APIURL;
    controller: string = "RelatedSkuForSpecialGroup";
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
    insertBySQL(formData: RelatedSkuForSpecialGroup) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, SKU: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)            
            .set('SKU', SKU)  
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

