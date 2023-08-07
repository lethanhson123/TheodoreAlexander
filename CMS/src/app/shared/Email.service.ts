import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class EmailService {
    aPIURL: string = environment.APIURL;
    controller: string = "Email";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
       
    }   
    
    asyncSendNotUserNameAndPasswordByShoppingCart(ID: string) {
        let url = this.aPIURL + this.controller + '/AsyncSendNotUserNameAndPasswordByShoppingCart';
        const params = new HttpParams()
            .set('ID', ID)            
        return this.httpClient.get(url, { params }).toPromise();
    }
    asyncSendNotUserNameAndPasswordByShoppingCartForward(ID: string) {
        let url = this.aPIURL + this.controller + '/AsyncSendNotUserNameAndPasswordByShoppingCartForward';
        const params = new HttpParams()
            .set('ID', ID)            
        return this.httpClient.get(url, { params }).toPromise();
    }
}

