import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Item } from 'src/app/shared/Item.model';
import { ItemDataTransfer } from 'src/app/shared/ItemDataTransfer.model';
import { ItemService } from 'src/app/shared/Item.service';
import { Designer } from 'src/app/shared/Designer.model';
import { DesignerService } from 'src/app/shared/Designer.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DownloadService } from 'src/app/shared/download.service';

@Component({
  selector: 'app-item-active-by-designer',
  templateUrl: './item-active-by-designer.component.html',
  styleUrls: ['./item-active-by-designer.component.css']
})
export class ItemActiveByDesignerComponent implements OnInit {

  website: string = environment.Website;
  productDetail: string = environment.ProductDetail;
  isShowLoading: boolean = false;
  room_IDList: string = environment.InitializationString;
  brand_IDList: string = environment.InitializationString;
  type_IDList: string = environment.InitializationString;
  shape_IDList: string = environment.InitializationString;
  style_IDList: string = environment.InitializationString;
  lifeStyle_IDList: string = environment.InitializationString;
  collection_IDList: string = environment.InitializationString;
  designer_IDList: string = environment.InitializationString;
  searchString: string = environment.InitializationString;
  isActiveTAUS: boolean = true;
  isActiveTAIN: boolean = false;
  constructor(
    public itemService: ItemService,
    public designerService: DesignerService,
    public downloadService: DownloadService,
    public notificationService: NotificationService,
  ) { 
    this.itemService.listItemDataTransfer=[];
  }

  ngOnInit(): void {
    this.getTypeToList()
    this.onSearch();
  }
  getTypeToList() {
    this.isShowLoading = true;
    this.designerService.getAllToList().then(res => {
      this.designerService.list = res as Designer[];
      this.isShowLoading = false;
    });
  }
  onChangeType() {
    this.onSearch();
  }
  getToList() {
    if (this.designer_IDList) {
      if (this.designer_IDList.length > 0) {
        this.isShowLoading = true;
        this.itemService.getDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToList(this.isActiveTAUS, this.room_IDList, this.brand_IDList, this.type_IDList, this.shape_IDList, this.style_IDList, this.lifeStyle_IDList, this.collection_IDList, this.designer_IDList, this.searchString).then(res => {
          this.itemService.listItemDataTransfer = res as ItemDataTransfer[];
          this.isShowLoading = false;
        });
      }
    }
  }
  onSearch() {
    this.getToList();
  }
  onDownloadExcelFile() {
    if (this.designer_IDList) {
      if (this.designer_IDList.length > 0) {
        this.isShowLoading = true;
        this.downloadService.getDataTransferByUser_IDAndIsActiveTAUSAndFilters001ToExcel(this.isActiveTAUS, this.room_IDList, this.brand_IDList, this.type_IDList, this.shape_IDList, this.style_IDList, this.lifeStyle_IDList, this.collection_IDList, this.designer_IDList, this.searchString).then(
          res => {
            window.location.href = res.toString();
            this.isShowLoading = false;
          }
        );
      }
    }
  }
  onChangeIsActiveTAUS(){
    this.isActiveTAIN=!this.isActiveTAUS;
  }
  onChangeIsActiveTAIN(){
    this.isActiveTAUS=!this.isActiveTAIN;
  }
}