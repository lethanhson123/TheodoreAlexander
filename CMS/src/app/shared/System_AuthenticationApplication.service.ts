import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { System_AuthenticationApplication } from 'src/app/shared/System_AuthenticationApplication.model';
import { System_AuthenticationApplicationDataTransfer } from 'src/app/shared/System_AuthenticationApplicationDataTransfer.model';
@Injectable({
    providedIn: 'root'
})
export class System_AuthenticationApplicationService {
    list: System_AuthenticationApplication[] | undefined;
    listDataTransfer: System_AuthenticationApplicationDataTransfer[] | undefined;
    formData!: System_AuthenticationApplication;
    aPIURL: string = environment.APIURL;
    controller: string = "System_AuthenticationApplication";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {           
        }
    }
    add(formData: System_AuthenticationApplication) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: System_AuthenticationApplication) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: System_AuthenticationApplication[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: System_AuthenticationApplication[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: System_AuthenticationApplication) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: System_AuthenticationApplication) {
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
        let url = this.aPIURL + this.controller + '/GetByID';
        const params = new HttpParams()
            .set('ID', JSON.stringify(ID))            
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)            
        return this.httpClient.get(url, { params }).toPromise();
    }
}

