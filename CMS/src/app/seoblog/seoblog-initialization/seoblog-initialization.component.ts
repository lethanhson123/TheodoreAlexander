import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Country } from 'src/app/shared/Country.model';
import { CountryService } from 'src/app/shared/Country.service';
import { SEOKeyword } from 'src/app/shared/SEOKeyword.model';
import { SEOKeywordService } from 'src/app/shared/SEOKeyword.service';
import { SEOBlog } from 'src/app/shared/SEOBlog.model';
import { SEOBlogService } from 'src/app/shared/SEOBlog.service';
import { ItemService } from 'src/app/shared/Item.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DownloadService } from 'src/app/shared/download.service';

@Component({
  selector: 'app-seoblog-initialization',
  templateUrl: './seoblog-initialization.component.html',
  styleUrls: ['./seoblog-initialization.component.css']
})
export class SEOBlogInitializationComponent implements OnInit {

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
    this.getCountryToList();
    this.onSearch();
  }
  getCountryToList() {
    this.isShowLoading = true;
    this.countryService.GetAllToList().then(res => {
      this.countryService.list = res as Country[];
      this.isShowLoading = false;
    });
  }
  getSEOBlogToList() {
    this.isShowLoading = true;
    this.sEOBlogService.getDataTransferSelectCountByCountryIDToList(this.countryID).then(res => {
      this.sEOBlogService.list = res as SEOBlog[];
      this.isShowLoading = false;
    });
  }
  onSearch() {
    this.getSEOBlogToList();
  }
  onSitemap(item: SEOBlog) {
    this.isShowLoading = true;
    this.downloadService.initializationSiteMapSEOBlogBySEOKeywordIDCountryIDToXML(item.KeywordID, this.countryID).then(
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
  onHTMLPage(item: SEOBlog) {
    console.log(item);
    console.log(this.countryID);
    this.isShowLoading = true;  
    this.downloadService.initializationHTMLKeywordPageByKeywordIDAndCountryIDAndRowBeginAndRowEndInLIVE(item.KeywordID, this.countryID, item.RowBegin, item.RowEnd).then(
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
  onCreate(item: SEOBlog) {
    this.isShowLoading = true;  
    this.sEOBlogService.initializationBySEOKeywordIDAndCountryID(item.KeywordID, this.countryID).then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;    
        this.onSearch();  
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);    
        this.isShowLoading = false;    
      }
    );
  }
  onDelete(item: SEOBlog) {
    this.isShowLoading = true;  
    this.sEOBlogService.deleteByCountryIDAndKeywordID(item.KeywordID, this.countryID).then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;    
        this.onSearch();  
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