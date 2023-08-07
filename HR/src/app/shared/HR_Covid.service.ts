import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HR_Covid } from 'src/app/shared/HR_Covid.model';
import { HR_CovidDataTransfer } from 'src/app/shared/HR_CovidDataTransfer.model';
@Injectable({
    providedIn: 'root'
})
export class HR_CovidService {
    list: HR_Covid[] | undefined;
    listWithCodeManage: HR_Covid[] | undefined;
    listDataTransfer: HR_CovidDataTransfer[] | undefined;
    formData!: HR_Covid;
    aPIURL: string = environment.APIURL;
    controller: string = "HR_Covid";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
            ID: 0,
            IsolationProvinceID: 0,
            IsolationDistrictID: 0
        }
    }
    add(formData: HR_Covid) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: HR_Covid) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: HR_Covid[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: HR_Covid[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: HR_Covid) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: HR_Covid) {
        let url = this.aPIURL + this.controller + '/AsyncUpdate';
        return this.httpClient.put(url, formData);
    }
    getByID(ID: number) {
        let url = this.aPIURL + this.controller + '/GetByID?ID=' + ID;
        return this.httpClient.get(url).toPromise();
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
    getDataTransferBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)            
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferBySearchStringAndCodeManageToList(searchString: string, codeManage:string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferBySearchStringAndCodeManageToList';
        const params = new HttpParams()
            .set('searchString', searchString)            
            .set('codeManage', codeManage)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByF0ToList() {
        let url = this.aPIURL + this.controller + '/GetByF0ToList';
        return this.httpClient.get(url).toPromise();
    }
    getByF1ToList() {
        let url = this.aPIURL + this.controller + '/GetByF1ToList';
        return this.httpClient.get(url).toPromise();
    }
    getByF2ToList() {
        let url = this.aPIURL + this.controller + '/GetByF2ToList';
        return this.httpClient.get(url).toPromise();
    }
    getDataTransferByEmployeeIDToList(employeeID: number) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByEmployeeIDToList';
        const params = new HttpParams()
            .set('employeeID',  JSON.stringify(employeeID))            
        return this.httpClient.get(url, { params }).toPromise();
    }
   
    getByWithCodeManageToList() {
        let url = this.aPIURL + this.controller + '/GetByWithCodeManageToList';        
        return this.httpClient.get(url).toPromise();
    }
}

