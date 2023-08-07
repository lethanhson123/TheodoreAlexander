import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SEOBlog } from 'src/app/shared/SEOBlog.model';
import { SEOBlogService } from 'src/app/shared/SEOBlog.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { SEOKeyword } from 'src/app/shared/SEOKeyword.model';
import { SEOKeywordService } from 'src/app/shared/SEOKeyword.service';
import { Country } from 'src/app/shared/Country.model';
import { CountryService } from 'src/app/shared/Country.service';
import { Region } from 'src/app/shared/Region.model';
import { RegionService } from 'src/app/shared/Region.service';

@Component({
  selector: 'app-seoblog',
  templateUrl: './seoblog.component.html',
  styleUrls: ['./seoblog.component.css']
})
export class SEOBlogComponent implements OnInit {

  website: string = environment.Website;
  article: string = environment.Article;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;  
  countryID: string = "facbb4b8-9f61-46cf-8e98-e63a20145739";
  regionID: string = environment.InitializationString;
  keywordID: number = 1;
  URLSub: string = "SEOBlogInfo";
  constructor(
    public sEOBlogService: SEOBlogService,
    public sEOKeywordService: SEOKeywordService,
    public countryService: CountryService,
    public regionService: RegionService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getSEOKeywordToList();
    this.getCountryToList();
    this.getRegionToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.sEOBlogService.getByKeywordIDAndCountryIDAndRegionIDAndSearchStringToList(this.keywordID, this.countryID, this.regionID, this.searchString).then(res => {
      this.sEOBlogService.list = res as SEOBlog[];
      this.isShowLoading = false;
    });
  }
  getSEOKeywordToList() {
    this.sEOKeywordService.getAllToList().then(res => {
      this.sEOKeywordService.list = res as SEOKeyword[];
    });
  }
  getCountryToList() {
    this.countryService.GetAllToList().then(res => {
      this.countryService.list = res as Country[];
    });
  }
  onChangeCountry() {
    this.getRegionToList();
  }
  getRegionToList() {
    this.regionService.getByCountryIDToList(this.countryID).then(res => {
      this.regionService.list = res as Region[];      
    });
  }
  onSearch() {
    this.getToList();
  }
  onInitializationInUS() {
    this.isShowLoading = true;
    this.sEOBlogService.asyncInitializationInUS().then(res => {
      this.isShowLoading = false;
      this.onSearch();
    });
  }
}
