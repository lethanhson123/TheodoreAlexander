import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Item } from 'src/app/shared/Item.model';
import { ItemDataTransfer } from './ItemDataTransfer.model';
@Injectable({
    providedIn: 'root'
})
export class ItemService {
    list: Item[] | undefined;
    listItemDataTransfer: ItemDataTransfer[] | undefined;
    formData!: Item;
    aPIURL: string = environment.APIURL;
    controller: string = "Item";
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.formData = {
        }
    }
    add(formData: Item) {
        let url = this.aPIURL + this.controller + '/Add';
        return this.httpClient.post(url, formData);
    }
    asyncAdd(formData: Item) {
        let url = this.aPIURL + this.controller + '/AsyncAdd';
        return this.httpClient.post(url, formData);
    }
    addRange(list: Item[]) {
        let url = this.aPIURL + this.controller + '/AddRange';
        return this.httpClient.post(url, list);
    }
    asyncAddRange(list: Item[]) {
        let url = this.aPIURL + this.controller + '/AsyncAddRange';
        return this.httpClient.post(url, list);
    }
    update(formData: Item) {
        let url = this.aPIURL + this.controller + '/Update';
        return this.httpClient.put(url, formData);
    }
    asyncUpdate(formData: Item) {
        let url = this.aPIURL + this.controller + '/AsyncUpdate';
        return this.httpClient.put(url, formData);
    }   
    updateBySQL(formData: Item) {
        let url = this.aPIURL + this.controller + '/UpdateBySQL';
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
    getByID(ID: string) {        
        let url = this.aPIURL + this.controller + '/GetByID';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getByIDListToList(IDList: any) {
        let url = this.aPIURL + this.controller + '/GetByIDListToList';
        const params = new HttpParams()
            .set('IDList', IDList)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getBySKUListToList(SKUList: any) {
        let url = this.aPIURL + this.controller + '/GetBySKUListToList';
        const params = new HttpParams()
            .set('SKUList', SKUList)
        return this.httpClient.get(url, { params }).toPromise();
    }
    postBySKUListToList(item: Item) {               
        let url = this.aPIURL + this.controller + '/PostBySKUListToList';  
        const uploadData = JSON.stringify(item);      
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);            
        return this.httpClient.post(url, formUpload);
    }
    getDataTransferBySearchStringToList(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferBySearchStringToList';
        const params = new HttpParams()
            .set('searchString', searchString)
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferByRowNumberToList(rowNumber: number) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByRowNumberToList';
        const params = new HttpParams()
        .set('rowNumber', JSON.stringify(rowNumber))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(isActiveTAUS: boolean, type_ID: string, inStockProgram: boolean, isStocked: boolean) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList';
        const params = new HttpParams()
        .set('isActiveTAUS', JSON.stringify(isActiveTAUS))
        .set('type_ID', type_ID)
        .set('inStockProgram', JSON.stringify(inStockProgram))
        .set('isStocked', JSON.stringify(isStocked))
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToList(isActiveTAUS: boolean, room_IDList: string, brand_IDList: string, type_IDList: string, shape_IDList: string, style_IDList: string, lifeStyle_IDList: string, collection_IDList: string, designer_IDList: string, searchString:string) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToList';
        const params = new HttpParams()
        .set('isActiveTAUS', JSON.stringify(isActiveTAUS))
        .set('room_IDList', room_IDList)
        .set('brand_IDList', brand_IDList)
        .set('type_IDList', type_IDList)
        .set('shape_IDList', shape_IDList)
        .set('style_IDList', style_IDList)
        .set('lifeStyle_IDList', lifeStyle_IDList)
        .set('collection_IDList', collection_IDList)
        .set('designer_IDList', designer_IDList)        
        .set('searchString', searchString)     
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(user_ID:string, isActiveTAUS: boolean, room_IDList: string, brand_IDList: string, type_IDList: string, shape_IDList: string, style_IDList: string, lifeStyle_IDList: string, collection_IDList: string, designer_IDList: string, searchString:string, extending:boolean, isStocked:boolean, isCFPItem:boolean, isNew:boolean) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList';
        const params = new HttpParams()
        .set('user_ID', user_ID)
        .set('isActiveTAUS', JSON.stringify(isActiveTAUS))
        .set('room_IDList', room_IDList)
        .set('brand_IDList', brand_IDList)
        .set('type_IDList', type_IDList)
        .set('shape_IDList', shape_IDList)
        .set('style_IDList', style_IDList)
        .set('lifeStyle_IDList', lifeStyle_IDList)
        .set('collection_IDList', collection_IDList)
        .set('designer_IDList', designer_IDList)        
        .set('searchString', searchString)     
        .set('extending', JSON.stringify(extending))
        .set('isStocked', JSON.stringify(isStocked))
        .set('isCFPItem', JSON.stringify(isCFPItem))
        .set('isNew', JSON.stringify(isNew))        
        return this.httpClient.get(url, { params }).toPromise();
    }
    getDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToList(user_ID:string, isActiveTAUS: boolean, room_IDList: string, brand_IDList: string, type_IDList: string, shape_IDList: string, style_IDList: string, lifeStyle_IDList: string, collection_IDList: string, designer_IDList: string, searchString:string, extending:boolean, isStocked:boolean, isCFPItem:boolean, isNew:boolean, isBestSeller:boolean) {
        let url = this.aPIURL + this.controller + '/GetDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToList';
        const params = new HttpParams()
        .set('user_ID', user_ID)
        .set('isActiveTAUS', JSON.stringify(isActiveTAUS))
        .set('room_IDList', room_IDList)
        .set('brand_IDList', brand_IDList)
        .set('type_IDList', type_IDList)
        .set('shape_IDList', shape_IDList)
        .set('style_IDList', style_IDList)
        .set('lifeStyle_IDList', lifeStyle_IDList)
        .set('collection_IDList', collection_IDList)
        .set('designer_IDList', designer_IDList)        
        .set('searchString', searchString)     
        .set('extending', JSON.stringify(extending))
        .set('isStocked', JSON.stringify(isStocked))
        .set('isCFPItem', JSON.stringify(isCFPItem))
        .set('isNew', JSON.stringify(isNew))        
        .set('isBestSeller', JSON.stringify(isBestSeller))        
        return this.httpClient.get(url, { params }).toPromise();
    }
    updateItemsURLCode() {
        let url = this.aPIURL + this.controller + '/UpdateItemsURLCode';
        const params = new HttpParams()        
        return this.httpClient.get(url, { params }).toPromise();
    }
    asyncGetByConectionStringAndIsActiveWithImageCountIsNullToList() {
        let url = this.aPIURL + this.controller + '/AsyncGetByConectionStringAndIsActiveWithImageCountIsNullToList';        
        return this.httpClient.get(url).toPromise();
    }
    asyncDownloadAllImages() {    
        let url = this.aPIURL + this.controller + '/AsyncDownloadAllImages';                
        return this.httpClient.get(url).toPromise();
    }
    downloadImagesByURLList(uRLList: string) {    
        let url = this.aPIURL + this.controller + '/DownloadImagesByURLList';
        const uploadData = JSON.stringify(uRLList);
        const formUpload: FormData = new FormData();
        formUpload.append('data', uploadData);     
        return this.httpClient.post(url, formUpload);
    }
}

