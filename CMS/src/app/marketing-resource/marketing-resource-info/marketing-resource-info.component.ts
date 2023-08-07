import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MarketingResourceCategory } from 'src/app/shared/MarketingResourceCategory.model';
import { MarketingResourceCategoryService } from 'src/app/shared/MarketingResourceCategory.service';
import { MarketingResource } from 'src/app/shared/MarketingResource.model';
import { MarketingResourceService } from 'src/app/shared/MarketingResource.service';
import { MarketingResourceDetail } from 'src/app/shared/MarketingResourceDetail.model';
import { MarketingResourceDetailService } from 'src/app/shared/MarketingResourceDetail.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { MarketingResourceDetailDetailComponent } from './marketing-resource-detail-detail/marketing-resource-detail-detail.component';

@Component({
  selector: 'app-marketing-resource-info',
  templateUrl: './marketing-resource-info.component.html',
  styleUrls: ['./marketing-resource-info.component.css']
})
export class MarketingResourceInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  constructor(
    private dialog: MatDialog,
    public router: Router,
    public notificationService: NotificationService,
    public marketingResourceCategoryService: MarketingResourceCategoryService,
    public marketingResourceService: MarketingResourceService,
    public marketingResourceDetailService: MarketingResourceDetailService,
  ) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.getByQueryString();
      }
    });
  }

  ngOnInit(): void {
    this.getMarketingResourceCategoryToList();
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.marketingResourceService.getByIDString(this.queryString).then(res => {
      this.marketingResourceService.formData = res as MarketingResource;
      this.getMarketingResourceDetailToList();
      this.isShowLoading = false;
    });
  }
  getMarketingResourceCategoryToList() {
    this.isShowLoading = true;
    this.marketingResourceCategoryService.getAllToList().then(res => {
      this.marketingResourceCategoryService.list = res as MarketingResourceCategory[];
      this.isShowLoading = false;
    });
  }
  getMarketingResourceDetailToList() {
    this.isShowLoading = true;
    this.marketingResourceDetailService.getByParentIDToList(this.marketingResourceService.formData.ID).then(res => {
      this.marketingResourceDetailService.list = res as MarketingResourceDetail[];
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.marketingResourceService.add(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.isShowLoading = false;
        this.marketingResourceService.formData = res as MarketingResource;
        window.location.href = environment.DomainDestination + "MarketingResourceInfo/" + this.marketingResourceService.formData.ID;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
  onAdd(ID: any) {
    this.marketingResourceDetailService.getByID(ID).then(res => {
      this.marketingResourceDetailService.formData = res as MarketingResourceDetail;
      this.marketingResourceDetailService.formData.ParentID = this.marketingResourceService.formData.ID;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(MarketingResourceDetailDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getByQueryString();
    });
  }
}
