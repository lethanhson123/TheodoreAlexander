import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Item } from 'src/app/shared/Item.model';
import { ItemDataTransfer } from 'src/app/shared/ItemDataTransfer.model';
import { ItemService } from 'src/app/shared/Item.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DownloadService } from 'src/app/shared/download.service';
import { RoomAndUsage } from 'src/app/shared/RoomAndUsage.model';
import { RoomAndUsageService } from 'src/app/shared/RoomAndUsage.service';
import { Type } from 'src/app/shared/Type.model';
import { TypeService } from 'src/app/shared/Type.service';
import { Brand } from 'src/app/shared/Brand.model';
import { BrandService } from 'src/app/shared/Brand.service';
import { Collection } from 'src/app/shared/Collection.model';
import { CollectionService } from 'src/app/shared/Collection.service';
import { Designer } from 'src/app/shared/Designer.model';
import { DesignerService } from 'src/app/shared/Designer.service';
import { Shape } from 'src/app/shared/Shape.model';
import { ShapeService } from 'src/app/shared/Shape.service';
import { LifeStyle } from 'src/app/shared/LifeStyle.model';
import { LifeStyleService } from 'src/app/shared/LifeStyle.service';
import { Style } from 'src/app/shared/Style.model';
import { StyleService } from 'src/app/shared/Style.service';

@Component({
  selector: 'app-item-active',
  templateUrl: './item-active.component.html',
  styleUrls: ['./item-active.component.css']
})
export class ItemActiveComponent implements OnInit {

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
  isCFPItem: boolean = false;
  isNew: boolean = false;
  isBestSeller: boolean = false;
  constructor(
    public itemService: ItemService,
    public downloadService: DownloadService,
    public notificationService: NotificationService,
    public roomAndUsageService: RoomAndUsageService,
    public typeService: TypeService,
    public brandService: BrandService,
    public collectionService: CollectionService,
    public designerService: DesignerService,
    public shapeService: ShapeService,
    public lifeStyleService: LifeStyleService,
    public styleService: StyleService,
  ) { 
    this.itemService.listItemDataTransfer=[];
  }

  ngOnInit(): void {  
    this.getRoomAndUsageToList();  
    this.getTypeToList();  
    this.getBrandToList();  
    this.getCollectionToList();  
    this.getDesignerToList(); 
    this.getShapeToList();
    this.getLifeStyleToList();
    this.getStyleToList();
  } 
  getStyleToList() {
    this.isShowLoading = true;
    this.styleService.getByIsActiveToList(true).then(res => {
      this.styleService.list = res as Style[];
      this.isShowLoading = false;            
    });
  }
  getLifeStyleToList() {
    this.isShowLoading = true;
    this.lifeStyleService.getByIsActiveToList(true).then(res => {
      this.lifeStyleService.list = res as LifeStyle[];
      this.isShowLoading = false;
    });
  }
  getRoomAndUsageToList() {
    this.isShowLoading = true;
    this.roomAndUsageService.getByIsActiveToList(true).then(res => {
      this.roomAndUsageService.list = res as RoomAndUsage[];
      this.isShowLoading = false;
    });
  }
  getTypeToList() {
    this.isShowLoading = true;
    this.typeService.getByIsActiveToList(true).then(res => {
      this.typeService.list = res as Type[];
      this.isShowLoading = false;
    });
  }
  getBrandToList() {
    this.isShowLoading = true;
    this.brandService.getByIsActiveToList(true).then(res => {
      this.brandService.list = res as Brand[];
      this.isShowLoading = false;
    });
  }
  getCollectionToList() {
    this.isShowLoading = true;
    this.collectionService.getByIsActiveToList(true).then(res => {
      this.collectionService.list = res as Collection[];
      this.isShowLoading = false;
    });
  }
  getDesignerToList() {
    this.isShowLoading = true;
    this.designerService.getByIsActiveToList(true).then(res => {
      this.designerService.list = res as Designer[];
      this.isShowLoading = false;
    });
  }
  getShapeToList() {
    this.isShowLoading = true;
    this.shapeService.getByIsActiveToList(true).then(res => {
      this.shapeService.list = res as Shape[];
      this.isShowLoading = false;
    });
  }
  getToList() {
    this.isShowLoading = true;
    this.itemService.getDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToList(this.user_ID, this.isActiveTAUS, this.room_IDList, this.brand_IDList, this.type_IDList, this.shape_IDList, this.style_IDList, this.lifeStyle_IDList, this.collection_IDList, this.designer_IDList, this.searchString, this.extending, this.isStocked, this.isCFPItem, this.isNew, this.isBestSeller).then(res => {
      this.itemService.listItemDataTransfer = res as ItemDataTransfer[];      
      this.isShowLoading = false;
    });
  }
  onSearch() {
    this.getToList();
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;
    this.downloadService.getDataTransferByUser_IDAndIsActiveTAUSAndFilters002ToExcel(this.isActiveTAUS, this.room_IDList, this.brand_IDList, this.type_IDList, this.shape_IDList, this.style_IDList, this.lifeStyle_IDList, this.collection_IDList, this.designer_IDList, this.searchString, this.extending, this.isStocked, this.isCFPItem, this.isNew, this.isBestSeller).then(
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