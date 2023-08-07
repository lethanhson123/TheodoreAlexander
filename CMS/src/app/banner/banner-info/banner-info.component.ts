import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Banner } from 'src/app/shared/Banner.model';
import { BannerService } from 'src/app/shared/Banner.service';
import { BannerDetail } from 'src/app/shared/BannerDetail.model';
import { BannerDetailService } from 'src/app/shared/BannerDetail.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { BannerDetailDetailComponent } from '../banner-detail-detail/banner-detail-detail.component';

@Component({
  selector: 'app-banner-info',
  templateUrl: './banner-info.component.html',
  styleUrls: ['./banner-info.component.css']
})
export class BannerInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = "BannerInfo";
  constructor(
    private dialog: MatDialog,
    public router: Router,
    public notificationService: NotificationService,
    public bannerService: BannerService,
    public bannerDetailService: BannerDetailService,
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
    this.bannerService.getByIDString(this.queryString).then(res => {
      this.bannerService.formData = res as Banner;  
      this.getDetailToList();    
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.bannerService.add(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.isShowLoading = false;
        this.bannerService.formData = res as Banner;
        window.location.href = environment.DomainDestination + this.URLSub + "/" + this.bannerService.formData.ID;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
  getDetailToList() {
    this.isShowLoading = true;
    this.bannerDetailService.getByParentIDToList(this.bannerService.formData.ID).then(res => {
      this.bannerDetailService.list = res as BannerDetail[];
      this.isShowLoading = false;
    });
  }
  onAdd(ID: any) {  
    this.bannerDetailService.getByID(ID).then(res => {
      this.bannerDetailService.formData = res as BannerDetail;
      this.bannerDetailService.formData.ParentID = this.bannerService.formData.ID;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(BannerDetailDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getByQueryString();
    });  
  }
}
