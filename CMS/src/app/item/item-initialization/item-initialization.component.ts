import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DownloadService } from 'src/app/shared/download.service';
import { ItemService } from 'src/app/shared/Item.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-item-initialization',
  templateUrl: './item-initialization.component.html',
  styleUrls: ['./item-initialization.component.css']
})
export class ItemInitializationComponent implements OnInit {

  isShowLoading: boolean = false;
  uRLList: string = environment.InitializationString;
  isRoom: boolean = true;
  isType: boolean = true;
  isBrand: boolean = true;
  isCollection: boolean = true;
  isLifeStyle: boolean = true;
  isStyle: boolean = true;
  isShape: boolean = true;
  isDesigner: boolean = true;
  isSpecial: boolean = true;
  isProduct: boolean = true;
  constructor(
    public downloadService: DownloadService,
    public itemService: ItemService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }
  onDownloadImagesByURLList() {
    this.isShowLoading = true;
    this.itemService.downloadImagesByURLList(this.uRLList).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onAsyncDownloadAllImages() {
    this.isShowLoading = true;
    this.itemService.asyncDownloadAllImages().then(res => {
      this.isShowLoading = false;
    });
  }
  onUpdateItemsURLCode() {
    this.isShowLoading = true;
    this.itemService.updateItemsURLCode().then(res => {
      this.isShowLoading = false;
    });
  }
  onInitializationHTMLCategoryPageInLIVE() {
    this.isShowLoading = true;
    this.downloadService.initializationHTMLCategoryPageInLIVE(this.isRoom, this.isType, this.isBrand, this.isCollection, this.isLifeStyle, this.isStyle, this.isShape, this.isDesigner, this.isSpecial, this.isProduct).then(res => {
      this.isShowLoading = false;
    });
  }
  onInitializationHTMLCategoryPageInPRELIVE() {
    this.isShowLoading = true;
    this.downloadService.initializationHTMLCategoryPageInPRELIVE(this.isRoom, this.isType, this.isBrand, this.isCollection, this.isLifeStyle, this.isStyle, this.isShape, this.isDesigner, this.isSpecial, this.isProduct).then(res => {
      this.isShowLoading = false;
    });
  }
  onInitializationHTMLCategoryPageInTEST() {
    this.isShowLoading = true;
    this.downloadService.initializationHTMLCategoryPageInTEST(this.isRoom, this.isType, this.isBrand, this.isCollection, this.isLifeStyle, this.isStyle, this.isShape, this.isDesigner, this.isSpecial, this.isProduct).then(res => {
      this.isShowLoading = false;
    });
  }
}
