import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UPHFabric } from 'src/app/shared/UPHFabric.model';
@Injectable({
providedIn: 'root'
})
export class UPHFabricService {
list: UPHFabric[];
formData: UPHFabric;
aPIURL: string = environment.APIURL;
controller: string = "UPHFabric";
constructor(private httpClient: HttpClient) {
this.initializationFormData();
}
initializationFormData() {
this.formData = {
}
}
add(formData: UPHFabric) {
let url = this.aPIURL + this.controller + '/Add';
return this.httpClient.post(url, formData);
}
asyncAdd(formData: UPHFabric) {
let url = this.aPIURL + this.controller + '/AsyncAdd';
return this.httpClient.post(url, formData);
}
addRange(list: UPHFabric[]) {
let url = this.aPIURL + this.controller + '/AddRange';
return this.httpClient.post(url, list);
}
asyncAddRange(list: UPHFabric[]) {
let url = this.aPIURL + this.controller + '/AsyncAddRange';
return this.httpClient.post(url, list);
}
update(formData: UPHFabric) {
let url = this.aPIURL + this.controller + '/Update';
return this.httpClient.put(url, formData);
}
asyncUpdate(formData: UPHFabric) {
let url = this.aPIURL + this.controller + '/AsyncUpdate';
return this.httpClient.put(url, formData);
}
removeRange(list: UPHFabric[]) {
let url = this.aPIURL + this.controller + '/RemoveRange';
return this.httpClient.delete(url, list).toPromise();
}
asyncRemoveRange(list: UPHFabric[]) {
let url = this.aPIURL + this.controller + '/AsyncRemoveRange';
return this.httpClient.delete(url, list).toPromise();
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

