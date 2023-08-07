import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Item } from 'src/app/shared/Item.model';
import { ItemDataTransfer } from 'src/app/shared/ItemDataTransfer.model';
import { ItemService } from 'src/app/shared/Item.service';
import { Type } from 'src/app/shared/Type.model';
import { TypeService } from 'src/app/shared/Type.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DownloadService } from 'src/app/shared/download.service';

@Component({
  selector: 'app-item-active-by-type',
  templateUrl: './item-active-by-type.component.html',
  styleUrls: ['./item-active-by-type.component.css']
})
export class ItemActiveByTypeComponent implements OnInit {

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
    public typeService: TypeService,
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
    this.typeService.getAllToList().then(res => {
      this.typeService.list = res as Type[];
      this.isShowLoading = false;
    });
  }
  onChangeType() {
    this.onSearch();
  }
  getToList() {
    if (this.type_IDList) {
      if (this.type_IDList.length > 0) {
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
    if (this.type_IDList) {
      if (this.type_IDList.length > 0) {
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