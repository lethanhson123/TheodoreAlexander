import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SEOBlogType } from 'src/app/shared/SEOBlogType.model';
@Injectable({
    providedIn: 'root'
})
export class SEOBlogTypeService {
    list: SEOBlogType[] = [];
    formData!: SEOBlogType;
    aPIURL: string = environment.APIURL;
    controller: string = "SEOBlogType";
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

