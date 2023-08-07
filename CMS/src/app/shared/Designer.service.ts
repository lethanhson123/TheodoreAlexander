import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Designer } from 'src/app/shared/Designer.model';
@Injectable({
    providedIn: 'root'
})
export class DesignerService {
    list: Designer[] | undefined;
    formData!: Designer;
    aPIURL: string = environment.APIURL;
    controller: string = "Designer";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: Designer) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: Designer) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: Designer[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: Designer[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: Designer) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: Designer) {
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
    getByIsActiveToList(isActive: boolean) {
        let url = this.aPIURL + this.controller + '/GetByIsActiveToList';
        const params = new HttpParams()
            .set('isActive', JSON.stringify(isActive))
        return this.httpClient.get(url, { params }).toPromise();
    }
    addAndUploadImage(formData: Designer, fileToUploadImageIcon: File, fileToUploadImageMain: File, fileToUploadImageBackground: File) {
        let url = this.aPIURL + this.controller + '/AddAndUploadImage';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);        
        if (fileToUploadImageIcon == null) {
            fileToUploadImageIcon = new File(["fileToUploadImageIcon"], "fileToUploadImageIcon.txt", {
                type: "text/plain",
            });
        }
        if (fileToUploadImageMain == null) {
            fileToUploadImageMain = new File(["fileToUploadImageMain"], "fileToUploadImageMain.txt", {
                type: "text/plain",
            });
        }       
        if (fileToUploadImageBackground == null) {
            fileToUploadImageBackground = new File(["fileToUploadImageBackground"], "fileToUploadImageBackground.txt", {
                type: "text/plain",
            });
        }   
        formUpload.append('file', fileToUploadImageIcon, fileToUploadImageIcon.name);
        formUpload.append('file', fileToUploadImageMain, fileToUploadImageMain.name);       
        formUpload.append('file', fileToUploadImageBackground, fileToUploadImageBackground.name);
        return this.httpClient.post(url, formUpload);
    }
}

