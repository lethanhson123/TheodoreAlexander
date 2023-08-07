import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SEOBlogStore } from 'src/app/shared/SEOBlogStore.model';
@Injectable({
    providedIn: 'root'
})
export class SEOBlogStoreService {
    list: SEOBlogStore[] = [];
    formData!: SEOBlogStore;
    aPIURL: string = environment.APIURL;
    controller: string = "SEOBlogStore";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    getByParentIDToList(parentID: any) {
        let url = this.aPIURL + this.controller + '/GetByParentIDToList?parentID=' + parentID;
        return this.httpClient.get(url).toPromise();
    }   
}

