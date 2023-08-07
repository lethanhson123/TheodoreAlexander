import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MarketingResourceCategory } from 'src/app/shared/MarketingResourceCategory.model';
@Injectable({
    providedIn: 'root'
})
export class MarketingResourceCategoryService {
    list: MarketingResourceCategory[] | undefined;
    formData!: MarketingResourceCategory;
    aPIURL: string = environment.APIURL;
    controller: string = "MarketingResourceCategory";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {            
        }
    }
    add(formData: MarketingResourceCategory) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: MarketingResourceCategory) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: MarketingResourceCategory[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: MarketingResourceCategory[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: MarketingResourceCategory) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: MarketingResourceCategory) {
        let url = this.aPIURL + this.controller + '/AsyncUpdate';
        return this.httpClient.put(url, formData);
    }
    getAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';
        return this.httpClient.get(url).toPromise();
    }
    asyncGetAllToList() {
        let url = this.aPIURL + this.controller + '/AsyncGetAllToList';
        return this.httpClient.get(url).toPromise();
    }
    getByPageAndPageSizeToList(page: number, pageSize: number) {
        let url = this.aPIURL + this.controller + '/GetByPageAndPageSizeToList';
        const params = new HttpParams()
            .set('page', JSON.stringify(page))
            .set('pageSize', JSON.stringify(pageSize))
        return this.httpClient.get(url, { params }).toPromise();
    }
    asyncGetByPageAndPageSizeToList(page: number, pageSize: number) {
        let url = this.aPIURL + this.controller + '/AsyncGetByPageAndPageSizeToList';
        const params = new HttpParams()
            .set('page', JSON.stringify(page))
            .set('pageSize', JSON.stringify(pageSize))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByParentIDToList(parentID: number) {
        let url = this.aPIURL + this.controller + '/GetByParentIDToList';
        const params = new HttpParams()
            .set('parentID', JSON.stringify(parentID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByActiveToList(active: boolean) {
        let url = this.aPIURL + this.controller + '/GetByActiveToList';
        const params = new HttpParams()
            .set('active', JSON.stringify(active))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByID(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByID?ID=' + ID;
        return this.httpClient.get(url).toPromise();
    }
}

