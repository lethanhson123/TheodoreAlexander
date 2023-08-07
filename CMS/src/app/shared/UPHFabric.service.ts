import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UPHFabric } from 'src/app/shared/UPHFabric.model';
@Injectable({
    providedIn: 'root'
})
export class UPHFabricService {
    list: UPHFabric[] | undefined;
    formData: UPHFabric | undefined;
    aPIURL: string = environment.APIURL;
    controller: string = "UPHFabric";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    getByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList(isFabric: boolean, isLeather: boolean, isTrims: boolean, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList';
        const params = new HttpParams()
            .set('isFabric', JSON.stringify(isFabric))
            .set('isLeather', JSON.stringify(isLeather))
            .set('isTrims', JSON.stringify(isTrims))
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
}

