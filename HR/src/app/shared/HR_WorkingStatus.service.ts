import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HR_WorkingStatus } from 'src/app/shared/HR_WorkingStatus.model';
@Injectable({
    providedIn: 'root'
})
export class HR_WorkingStatusService {
    list: HR_WorkingStatus[] | undefined;
    formData: HR_WorkingStatus | undefined;
    aPIURL: string = environment.APIURL;
    controller: string = "HR_WorkingStatus";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: HR_WorkingStatus) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: HR_WorkingStatus) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: HR_WorkingStatus[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: HR_WorkingStatus[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: HR_WorkingStatus) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: HR_WorkingStatus) {
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
}

