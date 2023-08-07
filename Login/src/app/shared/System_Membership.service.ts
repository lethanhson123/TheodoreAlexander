import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { System_Membership } from './System_Membership.model';

@Injectable({
    providedIn: 'root'
})
export class System_MembershipService {
    formData!: System_Membership;
    aPIURL: string = environment.APIURL;
    controller: string = "System_Membership";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    authenticationByEmailAndPasswordAndURL(email: string, password: string, urlDestination: any) {
        
        let url = this.aPIURL + this.controller + '/AuthenticationByEmailAndPasswordAndURL';
        const params = new HttpParams()
            .set('email', email)
            .set('password', password)
            .set('urlDestination', urlDestination)
        return this.httpClient.get(url, { params }).toPromise();
    }
}

