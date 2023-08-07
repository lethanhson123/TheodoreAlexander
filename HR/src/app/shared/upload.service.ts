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
  postProvinceAndDistrictAndWardListByExcelFile(fileToUpload: File) {    
    let url = this.aPIURL + this.controller + '/PostProvinceAndDistrictAndWardListByExcelFile';
    const formUpload: FormData = new FormData();
    formUpload.append('file', fileToUpload, fileToUpload.name);
    return this.httpClient.post(url, formUpload);
  }
}
