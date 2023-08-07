import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { SEOBlog } from 'src/app/shared/SEOBlog.model';
import { SEOBlogService } from 'src/app/shared/SEOBlog.service';
import { SEOBlogItem } from 'src/app/shared/SEOBlogItem.model';
import { SEOBlogItemService } from 'src/app/shared/SEOBlogItem.service';
import { SEOBlogStore } from 'src/app/shared/SEOBlogStore.model';
import { SEOBlogStoreService } from 'src/app/shared/SEOBlogStore.service';
import { SEOBlogType } from 'src/app/shared/SEOBlogType.model';
import { SEOBlogTypeService } from 'src/app/shared/SEOBlogType.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-seoblog-info',
  templateUrl: './seoblog-info.component.html',
  styleUrls: ['./seoblog-info.component.css']
})
export class SEOBlogInfoComponent implements OnInit {

  website: string = environment.Website;
  article: string = environment.Article;
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = "SEOBlogTemplateInfo";
  fileToUpload: any;
  constructor(
    public router: Router,
    public notificationService: NotificationService,
    public sEOBlogService: SEOBlogService,
    public sEOBlogItemService: SEOBlogItemService,
    public sEOBlogStoreService: SEOBlogStoreService,
    public sEOBlogTypeService: SEOBlogTypeService,
  ) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.getByQueryString();
      }
    });
   }

  ngOnInit(): void {
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.sEOBlogService.getByIDString(this.queryString).then(res => {
      this.sEOBlogService.formData = res as SEOBlog;   
      this.getSEOBlogStoreToList();
      this.getSEOBlogTypeToList();
      this.getSEOBlogItemToList();
      this.isShowLoading = false;
    });
  }
  getSEOBlogItemToList() {
    this.isShowLoading = true;
    this.sEOBlogItemService.getByParentIDToList(this.sEOBlogService.formData.ID).then(res => {
      this.sEOBlogItemService.list = res as SEOBlogItem[];
      this.isShowLoading = false;
    });
  }
  getSEOBlogStoreToList() {
    this.isShowLoading = true;
    this.sEOBlogStoreService.getByParentIDToList(this.sEOBlogService.formData.ID).then(res => {
      this.sEOBlogStoreService.list = res as SEOBlogStore[];
      this.isShowLoading = false;
    });
  }
  getSEOBlogTypeToList() {
    this.isShowLoading = true;
    this.sEOBlogTypeService.getByParentIDToList(this.sEOBlogService.formData.ID).then(res => {
      this.sEOBlogTypeService.list = res as SEOBlogType[];
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {   
  }  
}