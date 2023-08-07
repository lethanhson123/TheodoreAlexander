import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/User.model';
import { UserDataTransfer } from './UserDataTransfer.model';
import { UserEmailDataTransfer } from './UserEmailDataTransfer.model';
@Injectable({
    providedIn: 'root'
})
export class UserService {
    list: User[] | undefined;
    listUserDataTransfer: UserDataTransfer[] | undefined;
    listUserEmailDataTransfer: UserEmailDataTransfer[] | undefined;
    formData!: User;
    aPIURL: string = environment.APIURL;
    controller: string = "User";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: User) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: User) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: User[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: User[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: User) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: User) {
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
    getDataTransferByStoreIDToList(storeID: string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByStoreIDToList';
        const params = new HttpParams()
            .set('storeID', storeID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferByRowNumberToList(rowNumber: number) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByRowNumberToList';
        const params = new HttpParams()
            .set('rowNumber', JSON.stringify(rowNumber))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getUserEmailDataTransferByDateBeginAndDateEndToList(dateBeginYear: number, dateBeginMonth: number, dateBeginDay: number, dateEndYear: number, dateEndMonth: number, dateEndDay: number, isSubcribed: boolean, isRegister: boolean, isQuotation: boolean) {
        let url = this.aPIURL + this.controller + '/GetUserEmailDataTransferByDateBeginAndDateEndToList';
        const params = new HttpParams()
            .set('dateBeginYear', JSON.stringify(dateBeginYear))
            .set('dateBeginMonth', JSON.stringify(dateBeginMonth))
            .set('dateBeginDay', JSON.stringify(dateBeginDay))
            .set('dateEndYear', JSON.stringify(dateEndYear))
            .set('dateEndMonth', JSON.stringify(dateEndMonth))
            .set('dateEndDay', JSON.stringify(dateEndDay))
            .set('isSubcribed', JSON.stringify(isSubcribed))
            .set('isRegister', JSON.stringify(isRegister))
            .set('isQuotation', JSON.stringify(isQuotation))
        return this.httpClient.get(url, { params }).toPromise();
    }   
    syncEMMA(dateBeginYear: number, dateBeginMonth: number, dateBeginDay: number, dateEndYear: number, dateEndMonth: number, dateEndDay: number, isSubcribed: boolean, isRegister: boolean, isQuotation: boolean, isSubscriberUS: boolean, isUserUS: boolean, isQuoteUS: boolean) {
        let url = this.aPIURL + this.controller + '/SyncEMMA';
        const params = new HttpParams()
            .set('dateBeginYear', JSON.stringify(dateBeginYear))
            .set('dateBeginMonth', JSON.stringify(dateBeginMonth))
            .set('dateBeginDay', JSON.stringify(dateBeginDay))
            .set('dateEndYear', JSON.stringify(dateEndYear))
            .set('dateEndMonth', JSON.stringify(dateEndMonth))
            .set('dateEndDay', JSON.stringify(dateEndDay))
            .set('isSubcribed', JSON.stringify(isSubcribed))
            .set('isRegister', JSON.stringify(isRegister))
            .set('isQuotation', JSON.stringify(isQuotation))
            .set('isSubscriberUS', JSON.stringify(isSubscriberUS))
            .set('isUserUS', JSON.stringify(isUserUS))
            .set('isQuoteUS', JSON.stringify(isQuoteUS))
        return this.httpClient.get(url, { params }).toPromise();
    }   
}

