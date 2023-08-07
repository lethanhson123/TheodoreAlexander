import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item_Fabric } from 'src/app/shared/Item_Fabric.model';
@Injectable({
    providedIn: 'root'
})
export class Item_FabricService {
    list: Item_Fabric[] | undefined;
    formData!: Item_Fabric;
    aPIURL: string = environment.APIURL;
    controller: string = "Item_Fabric";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }    
    updateBySQL(formData: Item_Fabric) {
        let url = this.aPIURL + this.controller + '/UpdateBySQL';
        return this.httpClient.put(url, formData);
    }   
    getByItemIDToList(ItemID: any) {
        let url = this.aPIURL + this.controller + '/GetByItemIDToList';
        const params = new HttpParams()
            .set('ItemID', ItemID)            
        return this.httpClient.get(url, { params }).toPromise();
    }  
    insertBySQL(formData: Item_Fabric) {
        let url = this.aPIURL + this.controller + '/InsertBySQL';
        return this.httpClient.post(url, formData);
    }
    deleteBySQL(ID: any) {
        let url = this.aPIURL + this.controller + '/DeleteBySQL';
        const params = new HttpParams()
            .set('ID', ID)                        
        return this.httpClient.get(url, { params }).toPromise();
    }    
}

