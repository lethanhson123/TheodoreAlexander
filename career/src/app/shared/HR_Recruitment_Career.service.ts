import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { HR_Recruitment_Career } from 'src/app/shared/HR_Recruitment_Career.model';

@Injectable({
  providedIn: 'root'
})
export class HR_Recruitment_CareerService {  
  list: HR_Recruitment_Career[];
  formData: HR_Recruitment_Career;  
  aPIURL: string = environment.APIURL;
  controller: string = "HR_Recruitment_Career";
  constructor(private httpClient: HttpClient) {
    this.initializationFormData();
  }
  initializationFormData() {
    this.formData = {
      ID: 0    
    }
  }
  getBySearchStringToList(searchString: string) {
    let url = this.aPIURL + this.controller + '/GetBySearchStringToList?searchString=' + searchString;
    return this.httpClient.get(url).toPromise();
  }
  getByRecommendPhoneAndSearchStringToList(recommendPhone: string,searchString:string) {
    let url = this.aPIURL + this.controller + '/GetByRecommendPhoneAndSearchStringToList';
    const params = new HttpParams()
    .set('recommendPhone', recommendPhone)
    .set('searchString', searchString)    
    return this.httpClient.get(url, { params }).toPromise();
  }
  getByRecommendPhoneToList(recommendPhone: string) {
    let url = this.aPIURL + this.controller + '/GetByRecommendPhoneToList?recommendPhone=' + recommendPhone;
    return this.httpClient.get(url).toPromise();
  }
  getByID(ID: number) {
    let url = this.aPIURL + this.controller + '/GetByID?ID=' + ID;
    return this.httpClient.get(url).toPromise();
  }
  add(formData: HR_Recruitment_Career) {
    let url = this.aPIURL + this.controller + '/Add';
    return this.httpClient.post(url, formData);
  }
  asyncAdd(formData: HR_Recruitment_Career) {
    let url = this.aPIURL + this.controller + '/AsyncAdd';
    return this.httpClient.post(url, formData);
  }
  addRange(list: HR_Recruitment_Career[]) {
    let url = this.aPIURL + this.controller + '/AddRange';
    return this.httpClient.post(url, list);
  }
  asyncAddRange(list: HR_Recruitment_Career[]) {
    let url = this.aPIURL + this.controller + '/AsyncAddRange';
    return this.httpClient.post(url, list);
  }
  update(formData: HR_Recruitment_Career) {
    let url = this.aPIURL + this.controller + '/Update';
    return this.httpClient.put(url, formData);
  }
  asyncUpdate(formData: HR_Recruitment_Career) {
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

