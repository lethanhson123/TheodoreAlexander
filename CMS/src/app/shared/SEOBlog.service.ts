import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SEOBlog } from 'src/app/shared/SEOBlog.model';
@Injectable({
    providedIn: 'root'
})
export class SEOBlogService {
    list: SEOBlog[] = [];
    formData!: SEOBlog;
    aPIURL: string = environment.APIURL;
    controller: string = "SEOBlog";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: SEOBlog) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: SEOBlog) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: SEOBlog[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: SEOBlog[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: SEOBlog) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: SEOBlog) {
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
    getByID(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByID?ID=' + ID;
        return this.httpClient.get(url).toPromise();
    }
    getByIDString(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDString?ID=' + ID;
        return this.httpClient.get(url).toPromise();
    }
    getByKeywordIDAndCountryIDAndSearchStringToList(keywordID: number, countryID: string, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByKeywordIDAndCountryIDAndSearchStringToList';
        const params = new HttpParams()
            .set('keywordID', JSON.stringify(keywordID))
            .set('countryID', countryID)
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList(keywordID: number, countryID: string, regionID: string, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList';
        const params = new HttpParams()
            .set('keywordID', JSON.stringify(keywordID))
            .set('countryID', countryID)
            .set('regionID', regionID)
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferSelectCountByCountryIDToList(countryID: string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferSelectCountByCountryIDToList';
        const params = new HttpParams()
            .set('countryID', countryID)

        return this.httpClient.get(url, { params }).toPromise();
    }
    deleteByCountryIDAndKeywordID(keywordID: any, countryID: string) {
        let url = this.aPIURL + this.controller + '/DeleteByCountryIDAndKeywordID';
        const params = new HttpParams()
            .set('countryID', countryID)
            .set('keywordID', JSON.stringify(keywordID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    initializationInUS() {
        let url = this.aPIURL + this.controller + '/InitializationInUS';
        return this.httpClient.get(url).toPromise();
    }
    asyncInitializationInUS() {
        let url = this.aPIURL + this.controller + '/AsyncInitializationInUS';
        return this.httpClient.get(url).toPromise();
    }
    initializationBySEOKeywordIDAndCountryID(sEOKeywordID: any, countryID: string) {
        let url = this.aPIURL + this.controller + '/InitializationBySEOKeywordIDAndCountryID';
        const params = new HttpParams()
            .set('sEOKeywordID', JSON.stringify(sEOKeywordID))
            .set('countryID', countryID)
        return this.httpClient.get(url, { params }).toPromise();
    }
}

