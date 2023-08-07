import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_ProcessAndTechnique } from 'src/app/shared/Item_ProcessAndTechnique.model';
@Injectable({
    providedIn: 'root'
})
export class Item_ProcessAndTechniqueService {
    list: Item_ProcessAndTechnique[] | undefined;
    formData!: Item_ProcessAndTechnique;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_ProcessAndTechnique";
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
    insertBySQL(formData: Item_ProcessAndTechnique) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(Item_ID: any, ProcessAndTechnique_ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('Item_ID', Item_ID)                        
            .set('ProcessAndTechnique_ID', ProcessAndTechnique_ID)  
        return this.httpClient.get(url, { params }).toPromise();
    }  
}

