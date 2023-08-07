import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DownloadService {

  aPIURL: string = environment.APIURL;
  controller: string = "Download";
  constructor(private httpClient: HttpClient) {
  }
  getHR_Recruitment_IntroduceBySearchStringToExcel(searchString: string) {
    let url = this.aPIURL + this.controller + '/GetHR_Recruitment_IntroduceBySearchStringToExcel';
    const params = new HttpParams()
      .set('searchString', searchString)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getHR_Recruitment_IntroduceBySearchStringToHTML(searchString: string) {
    let url = this.aPIURL + this.controller + '/GetHR_Recruitment_IntroduceBySearchStringToHTML';
    const params = new HttpParams()
      .set('searchString', searchString)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getHR_Recruitment_CareerByRecommendPhoneAndSearchStringToExcel(recommendPhone: string, searchString: string) {
    let url = this.aPIURL + this.controller + '/GetHR_Recruitment_CareerByRecommendPhoneAndSearchStringToExcel';
    const params = new HttpParams()
      .set('recommendPhone', recommendPhone)     
      .set('searchString', searchString)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getHR_Recruitment_CareerByRecommendPhoneAndSearchStringToHTML(recommendPhone: string, searchString: string) {
    let url = this.aPIURL + this.controller + '/GetHR_Recruitment_CareerByRecommendPhoneAndSearchStringToHTML';
    const params = new HttpParams()
      .set('recommendPhone', recommendPhone)     
      .set('searchString', searchString)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getHR_Recruitment_CareerBySearchStringToExcel(searchString: string) {
    let url = this.aPIURL + this.controller + '/GetHR_Recruitment_CareerBySearchStringToExcel';
    const params = new HttpParams()      
      .set('searchString', searchString)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getHR_Recruitment_CareerBySearchStringToHTML(searchString: string) {
    let url = this.aPIURL + this.controller + '/GetHR_Recruitment_CareerBySearchStringToHTML';
    const params = new HttpParams()           
      .set('searchString', searchString)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getUserDataTransferByStoreIDToExcel(storeID: string) {
    let url = this.aPIURL + this.controller + '/GetUserDataTransferByStoreIDToExcel';
    const params = new HttpParams()           
      .set('storeID', storeID)     
    return this.httpClient.get(url, { params }).toPromise();
  }
  getUserDataTransferToExcel() {
    let url = this.aPIURL + this.controller + '/GetUserDataTransferToExcel';
    const params = new HttpParams()                    
    return this.httpClient.get(url, { params }).toPromise();
  }
}
