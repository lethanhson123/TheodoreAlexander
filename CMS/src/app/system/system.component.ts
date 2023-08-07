import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DownloadService } from '../shared/download.service';
import { Country } from 'src/app/shared/Country.model';
import { CountryService } from 'src/app/shared/Country.service';
import { SEOKeyword } from 'src/app/shared/SEOKeyword.model';
import { SEOKeywordService } from 'src/app/shared/SEOKeyword.service';
import { SEOBlog } from 'src/app/shared/SEOBlog.model';
import { SEOBlogService } from 'src/app/shared/SEOBlog.service';
import { ItemService } from 'src/app/shared/Item.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.css']
})
export class SystemComponent implements OnInit {

  isShowLoading: boolean = false;
  sEOKeywordID: number = 1;
  countryID: string = environment.USID;
  rowBegin: number = 0;
  rowEnd: number = 0;
  uRLCodeList: string = environment.InitializationString;
  constructor(
    public downloadService: DownloadService,
    public countryService: CountryService,
    public sEOKeywordService: SEOKeywordService,
    public sEOBlogService: SEOBlogService,
    public itemService: ItemService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getSEOKeywordToList();
    this.getCountryToList();    
  }
  getSEOKeywordToList() {   
    this.isShowLoading = true; 
    this.sEOKeywordService.getAllToList().then(res => {
      this.sEOKeywordService.list = res as SEOKeyword[];   
      this.isShowLoading = false;       
    });
  }
  getCountryToList() {    
    this.isShowLoading = true;
    this.countryService.GetAllToList().then(res => {
      this.countryService.list = res as Country[];      
      this.isShowLoading = false;       
    });
  }
  
  onDownloadBlogSitemap() {
    this.isShowLoading = true;  
    this.downloadService.getSiteMapBlogToXML().then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
  onDownloadListSitemap() {
    this.isShowLoading = true;  
    this.downloadService.getSiteMapListToXML().then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
  onDownloadItemSitemap() {
    this.isShowLoading = true;  
    this.downloadService.getSiteMapItemToXML().then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
  onInitializationSiteMapSEOBlogBySEOKeywordIDCountryIDToXML() {
    this.isShowLoading = true;  
    this.downloadService.initializationSiteMapSEOBlogBySEOKeywordIDCountryIDToXML(this.sEOKeywordID, this.countryID).then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;      
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);  
        this.isShowLoading = false;      
      }
    );
  }
  onInitializationHTMLKeywordPageByKeywordIDAndCountryIDAndRowBeginAndRowEndInLIVE() {
    this.isShowLoading = true;  
    this.downloadService.initializationHTMLKeywordPageByKeywordIDAndCountryIDAndRowBeginAndRowEndInLIVE(this.sEOKeywordID, this.countryID, this.rowBegin, this.rowEnd).then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;      
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);    
        this.isShowLoading = false;    
      }
    );
  }
  onInitializationBySEOKeywordIDAndCountryID() {
    this.isShowLoading = true;  
    this.sEOBlogService.initializationBySEOKeywordIDAndCountryID(this.sEOKeywordID, this.countryID).then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;      
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);    
        this.isShowLoading = false;    
      }
    );
  }
  onAsyncGetByConectionStringAndIsActiveWithImageCountIsNullToList() {
    this.isShowLoading = true;  
    this.itemService.asyncGetByConectionStringAndIsActiveWithImageCountIsNullToList().then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;      
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);    
        this.isShowLoading = false;    
      }
    );
  }
  onInitializationHTMLKeywordPageInLIVEByURLCodeList() {
    this.isShowLoading = true;  
    this.downloadService.initializationHTMLKeywordPageInLIVEByURLCodeList(this.uRLCodeList).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;           
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);        
      }
    );
  }
}
