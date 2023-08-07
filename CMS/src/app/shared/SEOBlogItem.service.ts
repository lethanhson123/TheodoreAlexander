import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SEOBlogItem } from 'src/app/shared/SEOBlogItem.model';
@Injectable({
    providedIn: 'root'
})
export class SEOBlogItemService {
    list: SEOBlogItem[] = [];
    formData!: SEOBlogItem;
    aPIURL: string = environment.APIURL;
    controller: string = "SEOBlogItem";
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

