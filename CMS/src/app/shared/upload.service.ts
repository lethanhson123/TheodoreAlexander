import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  aPIURL: string = environment.APIURL;
  controller: string = "Upload";
  constructor(private httpClient: HttpClient) {
  }
  postEmployeeListByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostEmployeeListByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  postItemBedInfomationByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostItemBedInfomationByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  postItemIsBestSellerByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostItemIsBestSellerByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  postItemAdditionalFeaturesByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostItemAdditionalFeaturesByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  postItemProductNameAndExtendedDescriptionByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostItemProductNameAndExtendedDescriptionByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  postItemByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostItemByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);    
    return this.httpClient.post(url, formUpload);
  }
  postProvinceAndDistrictAndWardListByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostProvinceAndDistrictAndWardListByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
  
}
