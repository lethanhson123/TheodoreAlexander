import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { GhostBlog } from 'src/app/shared/GhostBlog.model';
@Injectable({
    providedIn: 'root'
})
export class GhostBlogService {
    list: GhostBlog[] = [];
    formData!: GhostBlog;
    aPIURL: string = environment.APIURL;
    controller: string = "GhostBlog";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    getBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetBySearchStringToList';   
        const params = new HttpParams()        
        .set('searchString', searchString)        
        return this.httpClient.get(url, {params}).toPromise();
    }
    initializationGhostToGhostBlog() {
        let url = this.aPIURL + this.controller + '/InitializationGhostToGhostBlog';           
        return this.httpClient.get(url).toPromise();
    }
}

