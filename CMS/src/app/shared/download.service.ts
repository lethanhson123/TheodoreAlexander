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
  getSiteMapBlogToXML() {
    let url = this.aPIURL + this.controller + '/GetSiteMapBlogToXML';
    const params = new HttpParams()
    return this.httpClient.get(url, { params }).toPromise();
  }
  getSiteMapListToXML() {
    let url = this.aPIURL + this.controller + '/GetSiteMapListToXML';
    const params = new HttpParams()
    return this.httpClient.get(url, { params }).toPromise();
  }
  getSiteMapItemToXML() {
    let url = this.aPIURL + this.controller + '/GetSiteMapItemToXML';
    const params = new HttpParams()
    return this.httpClient.get(url, { params }).toPromise();
  }
  getLocalStorageMembershipID() {
    let membershipIDString = localStorage.getItem(environment.MembershipID);
    let membershipID = 0;
    if ((membershipIDString != null) && (membershipIDString.length > 0)) {
      membershipID = parseInt(membershipIDString);
    }
    return membershipID;
  }
  getUserEmailDataTransferByDateBeginAndDateEndToExcel(dateBeginYear: number, dateBeginMonth: number, dateBeginDay: number, dateEndYear: number, dateEndMonth: number, dateEndDay: number, isSubcribed: boolean, isRegister: boolean, isQuotation: boolean) {
    let url = this.aPIURL + this.controller + '/GetUserEmailDataTransferByDateBeginAndDateEndToExcel';
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
  getUPHFabricByIsFabricAndIsLeatherAndIsTrimsAndSearchStringExcel(isFabric: boolean, isLeather: boolean, isTrims: boolean, searchString: string) {
    let url = this.aPIURL + this.controller + '/GetUPHFabricByIsFabricAndIsLeatherAndIsTrimsAndSearchStringExcel';
    const params = new HttpParams()
    .set('isFabric', JSON.stringify(isFabric))
    .set('isLeather', JSON.stringify(isLeather))
    .set('isTrims', JSON.stringify(isTrims))
    .set('searchString', searchString)
    return this.httpClient.get(url, { params }).toPromise();
  }  
  getItemDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToExcel(isActiveTAUS: boolean, type_ID: string, inStockProgram: boolean, isStocked: boolean) {
    let url = this.aPIURL + this.controller + '/GetItemDataTransferByIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToExcel';
    const params = new HttpParams()
    .set('isActiveTAUS', JSON.stringify(isActiveTAUS))
    .set('type_ID', type_ID)
    .set('inStockProgram', JSON.stringify(inStockProgram))
    .set('isStocked', JSON.stringify(isStocked))   
    return this.httpClient.get(url, { params }).toPromise();
  }
  getDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToExcel(isActiveTAUS: boolean, room_IDList: string, brand_IDList: string, type_IDList: string, shape_IDList: string, style_IDList: string, lifeStyle_IDList: string, collection_IDList: string, designer_IDList: string, searchString:string) {
    let url = this.aPIURL + this.controller + '/GetDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToExcel';
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
  getDataTransferByUser_IDAndIsActiveTAUSAndFiltersToExcel(isActiveTAUS: boolean, room_IDList: string, brand_IDList: string, type_IDList: string, shape_IDList: string, style_IDList: string, lifeStyle_IDList: string, collection_IDList: string, designer_IDList: string, searchString:string, extending:boolean, isStocked:boolean, isCFPItem:boolean, isNew:boolean) {
    let url = this.aPIURL + this.controller + '/GetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToExcel';
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
        .set('extending', JSON.stringify(extending))
        .set('isStocked', JSON.stringify(isStocked))
        .set('isCFPItem', JSON.stringify(isCFPItem))
        .set('isNew', JSON.stringify(isNew))        
        return this.httpClient.get(url, { params }).toPromise();
  }
  getDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToExcel(isActiveTAUS: boolean, room_IDList: string, brand_IDList: string, type_IDList: string, shape_IDList: string, style_IDList: string, lifeStyle_IDList: string, collection_IDList: string, designer_IDList: string, searchString:string, extending:boolean, isStocked:boolean, isCFPItem:boolean, isNew:boolean, isBestSeller:boolean) {
    let url = this.aPIURL + this.controller + '/GetDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToExcel';
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
        .set('extending', JSON.stringify(extending))
        .set('isStocked', JSON.stringify(isStocked))
        .set('isCFPItem', JSON.stringify(isCFPItem))
        .set('isNew', JSON.stringify(isNew))        
        .set('isBestSeller', JSON.stringify(isBestSeller))    
        return this.httpClient.get(url, { params }).toPromise();
  }
  initializationSiteMapSEOBlogBySEOKeywordIDCountryIDToXML(sEOKeywordID: any, countryID: string) {
    let url = this.aPIURL + this.controller + '/InitializationSiteMapSEOBlogBySEOKeywordIDCountryIDToXML';
    const params = new HttpParams()
        .set('sEOKeywordID', JSON.stringify(sEOKeywordID))
        .set('countryID', countryID)        
    return this.httpClient.get(url, { params }).toPromise();
  }
  initializationHTMLKeywordPageByKeywordIDAndCountryIDAndRowBeginAndRowEndInLIVE(sEOKeywordID: any, countryID: string, rowBegin: any, rowEnd: any) {    
    let url = this.aPIURL + this.controller + '/InitializationHTMLKeywordPageByKeywordIDAndCountryIDAndRowBeginAndRowEndInLIVE';
    const params = new HttpParams()
        .set('sEOKeywordID', JSON.stringify(sEOKeywordID))
        .set('countryID', countryID)        
        .set('rowBegin', JSON.stringify(rowBegin))
        .set('rowEnd', JSON.stringify(rowEnd))
    return this.httpClient.get(url, { params }).toPromise();
  }
  initializationHTMLKeywordPageInLIVEByURLCodeList(uRLCodeList: string) {    
    let url = this.aPIURL + this.controller + '/InitializationHTMLKeywordPageInLIVEByURLCodeList';
    const uploadData = JSON.stringify(uRLCodeList);
    const formUpload: FormData = new FormData();
    formUpload.append('data', uploadData);     
    return this.httpClient.post(url, formUpload);
  }
  initializationHTMLCategoryPageInLIVE(isRoom: boolean, isType: boolean, isBrand: boolean, isCollection: boolean, isLifeStyle: boolean, isStyle:boolean, isShape:boolean, isDesigner:boolean, isSpecial:boolean, isProduct:boolean) {    
    let url = this.aPIURL + this.controller + '/InitializationHTMLCategoryPageInLIVE';
    const params = new HttpParams()
        .set('isRoom', JSON.stringify(isRoom))     
        .set('isType', JSON.stringify(isType))     
        .set('isBrand', JSON.stringify(isBrand))     
        .set('isCollection', JSON.stringify(isCollection))     
        .set('isLifeStyle', JSON.stringify(isLifeStyle))     
        .set('isStyle', JSON.stringify(isStyle))     
        .set('isShape', JSON.stringify(isShape))     
        .set('isDesigner', JSON.stringify(isDesigner))     
        .set('isSpecial', JSON.stringify(isSpecial))     
        .set('isProduct', JSON.stringify(isProduct))   
    return this.httpClient.get(url, { params }).toPromise();
  }
  initializationHTMLCategoryPageInPRELIVE(isRoom: boolean, isType: boolean, isBrand: boolean, isCollection: boolean, isLifeStyle: boolean, isStyle:boolean, isShape:boolean, isDesigner:boolean, isSpecial:boolean, isProduct:boolean) {    
    let url = this.aPIURL + this.controller + '/InitializationHTMLCategoryPageInPRELIVE';
    const params = new HttpParams()
        .set('isRoom', JSON.stringify(isRoom))     
        .set('isType', JSON.stringify(isType))     
        .set('isBrand', JSON.stringify(isBrand))     
        .set('isCollection', JSON.stringify(isCollection))     
        .set('isLifeStyle', JSON.stringify(isLifeStyle))     
        .set('isStyle', JSON.stringify(isStyle))     
        .set('isShape', JSON.stringify(isShape))     
        .set('isDesigner', JSON.stringify(isDesigner))     
        .set('isSpecial', JSON.stringify(isSpecial))     
        .set('isProduct', JSON.stringify(isProduct))   
    return this.httpClient.get(url, { params }).toPromise();
  }
  initializationHTMLCategoryPageInTEST(isRoom: boolean, isType: boolean, isBrand: boolean, isCollection: boolean, isLifeStyle: boolean, isStyle:boolean, isShape:boolean, isDesigner:boolean, isSpecial:boolean, isProduct:boolean) {    
    let url = this.aPIURL + this.controller + '/InitializationHTMLCategoryPageInTEST';
    const params = new HttpParams()
        .set('isRoom', JSON.stringify(isRoom))     
        .set('isType', JSON.stringify(isType))     
        .set('isBrand', JSON.stringify(isBrand))     
        .set('isCollection', JSON.stringify(isCollection))     
        .set('isLifeStyle', JSON.stringify(isLifeStyle))     
        .set('isStyle', JSON.stringify(isStyle))     
        .set('isShape', JSON.stringify(isShape))     
        .set('isDesigner', JSON.stringify(isDesigner))     
        .set('isSpecial', JSON.stringify(isSpecial))     
        .set('isProduct', JSON.stringify(isProduct))   
    return this.httpClient.get(url, { params }).toPromise();
  }
}
