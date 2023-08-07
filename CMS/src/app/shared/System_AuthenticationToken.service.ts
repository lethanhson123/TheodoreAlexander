import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { System_AuthenticationToken } from 'src/app/shared/System_AuthenticationToken.model';
@Injectable({
    providedIn: 'root'
})
export class System_AuthenticationTokenService {
    list: System_AuthenticationToken[] | undefined;
    formData!: System_AuthenticationToken;
    aPIURL: string = environment.APIURL;
    controller: string = "System_AuthenticationToken";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    getByAuthenticationToken(authenticationToken: string) {
        let url = this.aPIURL + this.controller + '/GetByAuthenticationToken';
        const params = new HttpParams()
            .set('authenticationToken', authenticationToken)            
        return this.httpClient.get(url, { params }).toPromise();
    }
}

