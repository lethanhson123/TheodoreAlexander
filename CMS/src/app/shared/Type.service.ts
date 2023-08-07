import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Type } from 'src/app/shared/Type.model';
import { TypeDataTransfer } from 'src/app/shared/TypeDataTransfer.model';
@Injectable({
    providedIn: 'root'
})
export class TypeService {
    list: Type[] | undefined;
    listDataTransfer: TypeDataTransfer[] | undefined;
    formData!: Type;
    aPIURL: string = environment.APIURL;
    controller: string = "Type";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: Type) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    addAndUploadImage(formData: Type, fileToUpload: File, fileToUploadImageName: File) {
        let url = this.aPIURL + this.controller + '/AddAndUploadImage';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        if (fileToUploadImageName == null) {
            fileToUploadImageName = new File(["fileToUploadImageName"], "fileToUploadImageName.txt", {
                type: "text/plain",
            });
        }
        if (fileToUpload == null) {
            fileToUpload = new File(["fileToUpload"], "fileToUpload.txt", {
                type: "text/plain",
            });
        }       
        formUpload.append('file', fileToUploadImageName, fileToUploadImageName.name);
        formUpload.append('file', fileToUpload, fileToUpload.name);       
        return this.httpClient.post(url, formUpload);
    }
    asyncAdd(formData: Type) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: Type[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: Type[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: Type) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: Type) {
        let url = this.aPIURL + this.controller + '/AsyncUpdate';
        return this.httpClient.put(url, formData);
    }    
    getAllToList() {
        let url = this.aPIURL + this.controller + '/GetAllToList';
        return this.httpClient.get(url).toPromise();
    }
    getByIsActiveToList(isActive: boolean) {
        let url = this.aPIURL + this.controller + '/GetByIsActiveToList';
        const params = new HttpParams()
            .set('isActive', JSON.stringify(isActive))
        return this.httpClient.get(url, { params }).toPromise();
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
    getByID(ID: string) {        
        let url = this.aPIURL + this.controller + '/GetByID';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
}

