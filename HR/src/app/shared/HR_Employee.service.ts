import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HR_Employee } from 'src/app/shared/HR_Employee.model';
import { HR_EmployeeDataTransfer } from 'src/app/shared/HR_EmployeeDataTransfer.model';
@Injectable({
    providedIn: 'root'
})
export class HR_EmployeeService {
    list: HR_Employee[] | undefined;
    listHR_EmployeeDataTransfer: HR_EmployeeDataTransfer[] | undefined;
    formData!: HR_Employee;
    aPIURL: string = environment.APIURL;
    controller: string = "HR_Employee";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
            ID: 0
        }
    }
    add(formData: HR_Employee) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: HR_Employee) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: HR_Employee[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: HR_Employee[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: HR_Employee) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: HR_Employee) {
        let url = this.aPIURL + this.controller + '/AsyncUpdate';
        return this.httpClient.put(url, formData);
    }
    getByID(ID: any) {
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
    asyncGetDataTransferBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/AsyncGetDataTransferBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
    asyncGetDataTransferBySearchString001ToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/AsyncGetDataTransferBySearchString001ToList';
        const params = new HttpParams()
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
    asyncGetDataTransfer001BySearchStringAndIDToList(searchString: string, ID: any) {
        let url = this.aPIURL + this.controller + '/AsyncGetDataTransfer001BySearchStringAndIDToList';
        const params = new HttpParams()
            .set('searchString', searchString)
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransfer001BySearchStringAndIDToList(searchString: string, ID: any) {
        let url = this.aPIURL + this.controller + '/GetDataTransfer001BySearchStringAndIDToList';
        const params = new HttpParams()
            .set('searchString', searchString)
            .set('ID', JSON.stringify(ID))
        return this.httpClient.get(url, { params }).toPromise();
    }
}

