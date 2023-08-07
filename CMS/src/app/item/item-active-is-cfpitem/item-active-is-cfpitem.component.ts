import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Item } from 'src/app/shared/Item.model';
import { ItemDataTransfer } from 'src/app/shared/ItemDataTransfer.model';
import { ItemService } from 'src/app/shared/Item.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DownloadService } from 'src/app/shared/download.service';

@Component({
  selector: 'app-item-active-is-cfpitem',
  templateUrl: './item-active-is-cfpitem.component.html',
  styleUrls: ['./item-active-is-cfpitem.component.css']
})
export class ItemActiveIsCFPItemComponent implements OnInit {

  website: string = environment.Website;
  productDetail: string = environment.ProductDetail;
  isShowLoading: boolean = false;
  user_ID: string = environment.InitializationString;
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
  extending: boolean = false;
  isStocked: boolean = false;
  isCFPItem: boolean = true;
  isNew: boolean = false;
  constructor(
    public itemService: ItemService,
    public downloadService: DownloadService,
    public notificationService: NotificationService,
  ) { 
    this.itemService.listItemDataTransfer=[];
  }

  ngOnInit(): void {    
  } 
  getToList() {
    this.isShowLoading = true;
    this.itemService.getDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(this.user_ID, this.isActiveTAUS, this.room_IDList, this.brand_IDList, this.type_IDList, this.shape_IDList, this.style_IDList, this.lifeStyle_IDList, this.collection_IDList, this.designer_IDList, this.searchString, this.extending, this.isStocked, this.isCFPItem, this.isNew).then(res => {
      this.itemService.listItemDataTransfer = res as ItemDataTransfer[];
      this.isShowLoading = false;
    });
  }
  onSearch() {
    this.getToList();
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;
    this.downloadService.getDataTransferByUser_IDAndIsActiveTAUSAndFiltersToExcel(this.isActiveTAUS, this.room_IDList, this.brand_IDList, this.type_IDList, this.shape_IDList, this.style_IDList, this.lifeStyle_IDList, this.collection_IDList, this.designer_IDList, this.searchString, this.extending, this.isStocked, this.isCFPItem, this.isNew).then(
      res => {
        window.location.href = res.toString();
        this.isShowLoading = false;
      }
    );
  }
  onChangeIsActiveTAUS(){
    this.isActiveTAIN=!this.isActiveTAUS;
  }
  onChangeIsActiveTAIN(){
    this.isActiveTAUS=!this.isActiveTAIN;
  }
}