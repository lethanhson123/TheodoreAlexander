import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BannerDetail } from 'src/app/shared/BannerDetail.model';
@Injectable({
    providedIn: 'root'
})
export class BannerDetailService {
    list: BannerDetail[] | undefined;
    formData!: BannerDetail;
    aPIURL: string = environment.APIURL;
    controller: string = "BannerDetail";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: BannerDetail) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: BannerDetail) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: BannerDetail[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: BannerDetail[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: BannerDetail) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: BannerDetail) {
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
    getByParentIDToList(parentID: any) {
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
    getByIDString(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDString?ID=' + ID;
        return this.httpClient.get(url).toPromise();
    }
    saveAndUploadFiles(formData: BannerDetail, fileToUploadImageDesktop: File, fileToUploadImageMobile: File, fileToUploadImageName: File) {
        let url = this.aPIURL + this.controller + '/SaveAndUploadFiles';
        const uploadData = JSON.stringify(formData);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);
        if (fileToUploadImageDesktop == null) {
            fileToUploadImageDesktop = new File(["fileToUploadImageDesktop"], "fileToUploadImageDesktop.txt", {
                type: "text/plain",
            });
        }
        if (fileToUploadImageMobile == null) {
            fileToUploadImageMobile = new File(["fileToUploadImageMobile"], "fileToUploadImageMobile.txt", {
                type: "text/plain",
            });
        }
        if (fileToUploadImageName == null) {
            fileToUploadImageName = new File(["fileToUploadImageName"], "fileToUploadImageName.txt", {
                type: "text/plain",
            });
        }       
        formUpload.append('file', fileToUploadImageDesktop, fileToUploadImageDesktop.name);
        formUpload.append('file', fileToUploadImageMobile, fileToUploadImageMobile.name);
        formUpload.append('file', fileToUploadImageName, fileToUploadImageName.name);
        return this.httpClient.post(url, formUpload);
    }
}

