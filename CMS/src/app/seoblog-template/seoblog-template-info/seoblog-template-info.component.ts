import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { SEOBlogTemplate } from 'src/app/shared/SEOBlogTemplate.model';
import { SEOBlogTemplateService } from 'src/app/shared/SEOBlogTemplate.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-seoblog-template-info',
  templateUrl: './seoblog-template-info.component.html',
  styleUrls: ['./seoblog-template-info.component.css']
})
export class SEOBlogTemplateInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = "SEOBlogTemplateInfo";
  fileToUpload: any;
  constructor(
    public router: Router,
    public notificationService: NotificationService,
    public sEOBlogTemplateService: SEOBlogTemplateService,
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
    this.sEOBlogTemplateService.getByIDString(this.queryString).then(res => {
      this.sEOBlogTemplateService.formData = res as SEOBlogTemplate;        
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.sEOBlogTemplateService.saveAndUploadFiles(form.value, this.fileToUpload).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.isShowLoading = false;
        this.sEOBlogTemplateService.formData = res as SEOBlogTemplate;
        window.location.href = environment.DomainDestination + this.URLSub + "/" + this.sEOBlogTemplateService.formData.ID;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
  changeImage(e: Event) {
    if (e) {
      this.fileToUpload = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUpload !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUpload);
      }
    }
  }
}
