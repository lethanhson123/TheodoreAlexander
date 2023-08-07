import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { NotificationService } from 'src/app/shared/notification.service';
import { Item } from 'src/app/shared/Item.model';
import { ItemService } from 'src/app/shared/Item.service';
import { Item_Status } from 'src/app/shared/Item_Status.model';
import { Item_StatusService } from 'src/app/shared/Item_Status.service';
import { Item_Price } from 'src/app/shared/Item_Price.model';
import { Item_PriceService } from 'src/app/shared/Item_Price.service';
import { Item_Fabric } from 'src/app/shared/Item_Fabric.model';
import { Item_FabricService } from 'src/app/shared/Item_Fabric.service';
import { Item_Shape } from 'src/app/shared/Item_Shape.model';
import { Item_ShapeService } from 'src/app/shared/Item_Shape.service';
import { Item_2Dfeature } from 'src/app/shared/Item_2Dfeature.model';
import { Item_2DfeatureService } from 'src/app/shared/Item_2Dfeature.service';
import { Item_3Dfeature } from 'src/app/shared/Item_3Dfeature.model';
import { Item_3DfeatureService } from 'src/app/shared/Item_3Dfeature.service';
import { Item_Care } from 'src/app/shared/Item_Care.model';
import { Item_CareService } from 'src/app/shared/Item_Care.service';
import { Item_Century } from 'src/app/shared/Item_Century.model';
import { Item_CenturyService } from 'src/app/shared/Item_Century.service';
import { Item_ColourAndFinish } from 'src/app/shared/Item_ColourAndFinish.model';
import { Item_ColourAndFinishService } from 'src/app/shared/Item_ColourAndFinish.service';
import { Item_Geography } from 'src/app/shared/Item_Geography.model';
import { Item_GeographyService } from 'src/app/shared/Item_Geography.service';
import { Item_HistoricalStyle } from 'src/app/shared/Item_HistoricalStyle.model';
import { Item_HistoricalStyleService } from 'src/app/shared/Item_HistoricalStyle.service';
import { Item_ProcessAndTechnique } from 'src/app/shared/Item_ProcessAndTechnique.model';
import { Item_ProcessAndTechniqueService } from 'src/app/shared/Item_ProcessAndTechnique.service';
import { RelatedItem } from 'src/app/shared/RelatedItem.model';
import { RelatedItemService } from 'src/app/shared/RelatedItem.service';
import { RelatedSkuForSpecialGroup } from 'src/app/shared/RelatedSkuForSpecialGroup.model';
import { RelatedSkuForSpecialGroupService } from 'src/app/shared/RelatedSkuForSpecialGroup.service';
import { SKUListingForSizeAvailability } from 'src/app/shared/SKUListingForSizeAvailability.model';
import { SKUListingForSizeAvailabilityService } from 'src/app/shared/SKUListingForSizeAvailability.service';
import { Type } from 'src/app/shared/Type.model';
import { TypeService } from 'src/app/shared/Type.service';
import { Style } from 'src/app/shared/Style.model';
import { StyleService } from 'src/app/shared/Style.service';
import { Collection } from 'src/app/shared/Collection.model';
import { CollectionService } from 'src/app/shared/Collection.service';
import { RoomAndUsage } from 'src/app/shared/RoomAndUsage.model';
import { RoomAndUsageService } from 'src/app/shared/RoomAndUsage.service';
import { Brand } from 'src/app/shared/Brand.model';
import { BrandService } from 'src/app/shared/Brand.service';
import { LifeStyle } from 'src/app/shared/LifeStyle.model';
import { LifeStyleService } from 'src/app/shared/LifeStyle.service';
import { Material } from 'src/app/shared/Material.model';
import { MaterialService } from 'src/app/shared/Material.service';
import { OptionGroup } from 'src/app/shared/OptionGroup.model';
import { OptionGroupService } from 'src/app/shared/OptionGroup.service';
import { Shape } from 'src/app/shared/Shape.model';
import { ShapeService } from 'src/app/shared/Shape.service';
import { Care } from 'src/app/shared/Care.model';
import { CareService } from 'src/app/shared/Care.service';
import { Century } from 'src/app/shared/Century.model';
import { CenturyService } from 'src/app/shared/Century.service';
import { ColourAndFinish } from 'src/app/shared/ColourAndFinish.model';
import { ColourAndFinishService } from 'src/app/shared/ColourAndFinish.service';
import { Feature2D } from 'src/app/shared/Feature2D.model';
import { Feature2DService } from 'src/app/shared/Feature2D.service';
import { Feature3D } from 'src/app/shared/Feature3D.model';
import { Feature3DService } from 'src/app/shared/Feature3D.service';
import { Geography } from 'src/app/shared/Geography.model';
import { GeographyService } from 'src/app/shared/Geography.service';
import { HistoricalStyle } from 'src/app/shared/HistoricalStyle.model';
import { HistoricalStyleService } from 'src/app/shared/HistoricalStyle.service';
import { ProcessAndTechnique } from 'src/app/shared/ProcessAndTechnique.model';
import { ProcessAndTechniqueService } from 'src/app/shared/ProcessAndTechnique.service';

@Component({
  selector: 'app-item-info',
  templateUrl: './item-info.component.html',
  styleUrls: ['./item-info.component.css']
})
export class ItemInfoComponent implements OnInit {

  website: string = environment.Website;
  productDetail: string = environment.ProductDetail;
  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  relatedItemSKU: string = environment.InitializationString;
  relatedSkuForSpecialGroupSKU: string = environment.InitializationString;
  sKUListingForSizeAvailabilitySKU: string = environment.InitializationString;
  fabricCode: string = environment.InitializationString;
  shape_ID: string = environment.InitializationString;
  feature_ID2D: string = environment.InitializationString;
  feature_ID3D: string = environment.InitializationString;
  care_ID: string = environment.InitializationString;
  century_ID: string = environment.InitializationString;
  colourAndFinish_ID: string = environment.InitializationString;
  geography_ID: string = environment.InitializationString;
  historicalStyle_ID: string = environment.InitializationString;
  processAndTechnique_ID: string = environment.InitializationString;
  searchString: string = environment.InitializationString;
  constructor(
    public router: Router,
    public itemService: ItemService,
    public item_StatusService: Item_StatusService,
    public item_PriceService: Item_PriceService,
    public item_FabricService: Item_FabricService,
    public item_ShapeService: Item_ShapeService,
    public item_2DfeatureService: Item_2DfeatureService,
    public item_3DfeatureService: Item_3DfeatureService,
    public item_CareService: Item_CareService,
    public item_CenturyService: Item_CenturyService,
    public item_ColourAndFinishService: Item_ColourAndFinishService,
    public item_GeographyService: Item_GeographyService,
    public item_HistoricalStyleService: Item_HistoricalStyleService,
    public item_ProcessAndTechniqueService: Item_ProcessAndTechniqueService,
    public relatedItemService: RelatedItemService,    
    public relatedSkuForSpecialGroupService: RelatedSkuForSpecialGroupService,    
    public sKUListingForSizeAvailabilityService: SKUListingForSizeAvailabilityService,    
    public notificationService: NotificationService,
    public typeService: TypeService,
    public styleService: StyleService,
    public collectionService: CollectionService,
    public roomAndUsageService: RoomAndUsageService,
    public brandService: BrandService,
    public lifeStyleService: LifeStyleService,
    public materialService: MaterialService,
    public optionGroupService: OptionGroupService,
    public shapeService: ShapeService,
    public careService: CareService,
    public centuryService: CenturyService,
    public colourAndFinishService: ColourAndFinishService,
    public feature2DService: Feature2DService,
    public feature3DService: Feature3DService,
    public geographyService: GeographyService,
    public historicalStyleService: HistoricalStyleService,
    public processAndTechniqueService: ProcessAndTechniqueService,
  ) {
    this.getByQueryString();
  }

  ngOnInit(): void {
    this.getTypeToList();
    this.getStyleToList();
    this.getCollectionToList();
    this.getRoomAndUsageToList();
    this.getBrandToList();
    this.getLifeStyleToList();
    this.getOptionGroupToList();
    this.getMaterialToList();
    this.getShapeToList();
    this.getCareToList();
    this.getCenturyToList();
    this.getColourAndFinishToList();
    this.getFeature2DToList();
    this.getFeature3DToList();
    this.getGeographyToList();
    this.getHistoricalStyleToList();
    this.getProcessAndTechniqueToList();
  }
  getShapeToList() {    
    this.shapeService.getBySearchStringToList(this.searchString).then(res => {
      this.shapeService.list = res as Shape[];      
    });
  }
  getCareToList() {    
    this.careService.getAllToList().then(res => {
      this.careService.list = res as Care[];      
    });
  }
  getCenturyToList() {    
    this.centuryService.getAllToList().then(res => {
      this.centuryService.list = res as Century[];      
    });
  }
  getColourAndFinishToList() {    
    this.colourAndFinishService.getAllToList().then(res => {
      this.colourAndFinishService.list = res as ColourAndFinish[];      
    });
  }
  getFeature2DToList() {    
    this.feature2DService.getAllToList().then(res => {
      this.feature2DService.list = res as Feature2D[];      
    });
  }
  getFeature3DToList() {    
    this.feature3DService.getAllToList().then(res => {
      this.feature3DService.list = res as Feature3D[];     
      console.log(this.feature3DService.list); 
    });
  }
  getGeographyToList() {    
    this.geographyService.getAllToList().then(res => {
      this.geographyService.list = res as Geography[];      
    });
  }
  getHistoricalStyleToList() {    
    this.historicalStyleService.getAllToList().then(res => {
      this.historicalStyleService.list = res as HistoricalStyle[];      
    });
  }
  getProcessAndTechniqueToList() {    
    this.processAndTechniqueService.getAllToList().then(res => {
      this.processAndTechniqueService.list = res as ProcessAndTechnique[];      
    });
  }
  getOptionGroupToList() {    
    this.optionGroupService.getAllToList().then(res => {
      this.optionGroupService.list = res as OptionGroup[];    
    });
  }
  getMaterialToList() {    
    this.materialService.getAllToList().then(res => {
      this.materialService.list = res as Material[];    
    });
  }
  getLifeStyleToList() {    
    this.lifeStyleService.getAllToList().then(res => {
      this.lifeStyleService.list = res as LifeStyle[];    
    });
  }
  getBrandToList() {    
    this.brandService.getAllToList().then(res => {
      this.brandService.list = res as Brand[];    
    });
  }
  getRoomAndUsageToList() {    
    this.roomAndUsageService.getAllToList().then(res => {
      this.roomAndUsageService.list = res as RoomAndUsage[];    
    });
  }
  getTypeToList() {    
    this.typeService.getAllToList().then(res => {
      this.typeService.list = res as Type[];    
    });
  }
  getStyleToList() {    
    this.styleService.getAllToList().then(res => {
      this.styleService.list = res as Style[];    
    });
  }
  getCollectionToList() {    
    this.collectionService.getAllToList().then(res => {
      this.collectionService.list = res as Collection[];    
    });
  }
  getItem_StatusBySKUToList() {    
    this.item_StatusService.getBySKUToList(this.itemService.formData.SKU).then(res => {
      this.item_StatusService.list = res as Item_Status[];    
    });
  }
  getItem_PriceBySKUToList() {    
    this.item_PriceService.getBySKUToList(this.itemService.formData.SKU).then(res => {
      this.item_PriceService.list = res as Item_Price[];    
    });
  }
  getItem_FabricByItemIDToList() {    
    this.item_FabricService.getByItemIDToList(this.itemService.formData.ID).then(res => {
      this.item_FabricService.list = res as Item_Fabric[];    
    });
  }
  getItem_ShapeByItemIDToList() {    
    this.item_ShapeService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_ShapeService.list = res as Item_Shape[];    
    });
  }
  getItem_2DfeatureByItemIDToList() {    
    this.item_2DfeatureService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_2DfeatureService.list = res as Item_2Dfeature[];    
    });
  }
  getItem_3DfeatureByItemIDToList() {    
    this.item_3DfeatureService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_3DfeatureService.list = res as Item_3Dfeature[];    
    });
  }
  getItem_CareByItemIDToList() {    
    this.item_CareService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_CareService.list = res as Item_Care[];    
    });
  }
  getItem_CenturyByItemIDToList() {    
    this.item_CenturyService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_CenturyService.list = res as Item_Century[];    
    });
  }
  getItem_ColourAndFinishByItemIDToList() {    
    this.item_ColourAndFinishService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_ColourAndFinishService.list = res as Item_ColourAndFinish[];    
    });
  }
  getItem_GeographyByItemIDToList() {    
    this.item_GeographyService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_GeographyService.list = res as Item_Geography[];    
    });
  }
  getItem_HistoricalStyleByItemIDToList() {    
    this.item_HistoricalStyleService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_HistoricalStyleService.list = res as Item_HistoricalStyle[];    
    });
  }
  getItem_ProcessAndTechniqueByItemIDToList() {    
    this.item_ProcessAndTechniqueService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.item_ProcessAndTechniqueService.list = res as Item_ProcessAndTechnique[];    
    });
  }
  getRelatedItemByItemIDToList() {    
    this.relatedItemService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.relatedItemService.list = res as RelatedItem[];    
    });
  }
  getRelatedSkuForSpecialGroupByItemIDToList() {    
    this.relatedSkuForSpecialGroupService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.relatedSkuForSpecialGroupService.list = res as RelatedSkuForSpecialGroup[];    
    });
  }
  getSKUListingForSizeAvailabilityByItemIDToList() {    
    this.sKUListingForSizeAvailabilityService.getByItem_IDToList(this.itemService.formData.ID).then(res => {
      this.sKUListingForSizeAvailabilityService.list = res as SKUListingForSizeAvailability[];    
    });
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.itemService.getByID(this.queryString).then(res => {
          this.itemService.formData = res as Item;    
          this.getItem_StatusBySKUToList();      
          this.getItem_PriceBySKUToList();   
          this.getItem_FabricByItemIDToList();   
          this.getItem_ShapeByItemIDToList();
          this.getItem_2DfeatureByItemIDToList();
          this.getItem_3DfeatureByItemIDToList();
          this.getItem_CareByItemIDToList();
          this.getItem_CenturyByItemIDToList();
          this.getItem_ColourAndFinishByItemIDToList();
          this.getItem_GeographyByItemIDToList();
          this.getItem_HistoricalStyleByItemIDToList();
          this.getItem_ProcessAndTechniqueByItemIDToList();
          this.getRelatedItemByItemIDToList();
          this.getRelatedSkuForSpecialGroupByItemIDToList();
          this.getSKUListingForSizeAvailabilityByItemIDToList();
        });
        this.isShowLoading = false;
      }
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;    
    this.itemService.updateBySQL(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );
  }
  onItem_StatusSave(item: Item_Status){        
    this.item_StatusService.updateBySQL(item).subscribe(
      res => {       
        this.notificationService.warn(environment.SaveSuccess);        
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);        
      }
    );
  }
  onItem_PriceSave(item: Item_Price){        
    this.item_PriceService.updateBySQL(item).subscribe(
      res => {       
        this.notificationService.warn(environment.SaveSuccess);        
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);        
      }
    );
  } 
  onRelatedItemDelete(item: RelatedItem) {    
    this.isShowLoading = true;    
    this.relatedItemService.deleteBySQL(item.Item_ID, item.RelatedItem_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getRelatedItemByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onRelatedItemInsert() {    
    this.isShowLoading = true;    
    this.relatedItemService.formData.Item_ID=this.itemService.formData.ID;
    this.relatedItemService.formData.Item02SKU=this.relatedItemSKU;
    this.relatedItemService.insertBySQL(this.relatedItemService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getRelatedItemByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onRelatedSkuForSpecialGroupDelete(item: RelatedSkuForSpecialGroup) {    
    this.isShowLoading = true;    
    this.relatedSkuForSpecialGroupService.deleteBySQL(item.Item_ID, item.SKU).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getRelatedSkuForSpecialGroupByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onRelatedSkuForSpecialGroupInsert() {    
    this.isShowLoading = true;    
    this.relatedSkuForSpecialGroupService.formData.Item_ID=this.itemService.formData.ID;
    this.relatedSkuForSpecialGroupService.formData.SKU=this.relatedSkuForSpecialGroupSKU;
    this.relatedSkuForSpecialGroupService.insertBySQL(this.relatedSkuForSpecialGroupService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getRelatedSkuForSpecialGroupByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onSKUListingForSizeAvailabilityDelete(item: SKUListingForSizeAvailability) {    
    this.isShowLoading = true;    
    this.sKUListingForSizeAvailabilityService.deleteBySQL(item.ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getSKUListingForSizeAvailabilityByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onSKUListingForSizeAvailabilityInsert() {    
    this.isShowLoading = true;    
    this.sKUListingForSizeAvailabilityService.formData.Item_ID=this.itemService.formData.ID;
    this.sKUListingForSizeAvailabilityService.formData.SKU=this.sKUListingForSizeAvailabilitySKU;
    this.sKUListingForSizeAvailabilityService.insertBySQL(this.sKUListingForSizeAvailabilityService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getSKUListingForSizeAvailabilityByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_FabricDelete(item: Item_Fabric) {    
    this.isShowLoading = true;    
    this.item_FabricService.deleteBySQL(item.ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_FabricByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_FabricInsert() {    
    this.isShowLoading = true;    
    this.item_FabricService.formData.ItemID=this.itemService.formData.ID;
    this.item_FabricService.formData.FabricCode=this.fabricCode;
    this.item_FabricService.insertBySQL(this.item_FabricService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_FabricByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_ShapeDelete(item: Item_Shape) {    
    this.isShowLoading = true;    
    this.item_ShapeService.deleteBySQL(item.Item_ID, item.Shape_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_ShapeByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_ShapeInsert() {    
    this.isShowLoading = true;    
    this.item_ShapeService.formData.Item_ID=this.itemService.formData.ID;
    this.item_ShapeService.formData.Shape_ID=this.shape_ID;
    this.item_ShapeService.insertBySQL(this.item_ShapeService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_ShapeByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_CareDelete(item: Item_Care) {    
    this.isShowLoading = true;    
    this.item_CareService.deleteBySQL(item.Item_ID, item.Care_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_CareByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_CareInsert() {    
    this.isShowLoading = true;    
    this.item_CareService.formData.Item_ID=this.itemService.formData.ID;
    this.item_CareService.formData.Care_ID=this.care_ID;
    this.item_CareService.insertBySQL(this.item_CareService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_CareByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_CenturyDelete(item: Item_Century) {    
    this.isShowLoading = true;    
    this.item_CenturyService.deleteBySQL(item.Item_ID, item.Century_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_CenturyByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_CenturyInsert() {    
    this.isShowLoading = true;    
    this.item_CenturyService.formData.Item_ID=this.itemService.formData.ID;
    this.item_CenturyService.formData.Century_ID=this.century_ID;
    this.item_CenturyService.insertBySQL(this.item_CenturyService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_CenturyByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_GeographyDelete(item: Item_Geography) {    
    this.isShowLoading = true;    
    this.item_GeographyService.deleteBySQL(item.Item_ID, item.Geography_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_GeographyByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_GeographyInsert() {    
    this.isShowLoading = true;    
    this.item_GeographyService.formData.Item_ID=this.itemService.formData.ID;
    this.item_GeographyService.formData.Geography_ID=this.geography_ID;
    this.item_GeographyService.insertBySQL(this.item_GeographyService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_GeographyByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_HistoricalStyleDelete(item: Item_HistoricalStyle) {    
    this.isShowLoading = true;    
    this.item_HistoricalStyleService.deleteBySQL(item.Item_ID, item.HistoricalStyle_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_HistoricalStyleByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_HistoricalStyleInsert() {    
    this.isShowLoading = true;    
    this.item_HistoricalStyleService.formData.Item_ID=this.itemService.formData.ID;
    this.item_HistoricalStyleService.formData.HistoricalStyle_ID=this.historicalStyle_ID;
    this.item_HistoricalStyleService.insertBySQL(this.item_HistoricalStyleService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_HistoricalStyleByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_ProcessAndTechniqueDelete(item: Item_ProcessAndTechnique) {    
    this.isShowLoading = true;    
    this.item_ProcessAndTechniqueService.deleteBySQL(item.Item_ID, item.ProcessAndTechnique_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_ProcessAndTechniqueByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_ProcessAndTechniqueInsert() {    
    this.isShowLoading = true;    
    this.item_ProcessAndTechniqueService.formData.Item_ID=this.itemService.formData.ID;
    this.item_ProcessAndTechniqueService.formData.ProcessAndTechnique_ID=this.processAndTechnique_ID;
    this.item_ProcessAndTechniqueService.insertBySQL(this.item_ProcessAndTechniqueService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_ProcessAndTechniqueByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_2DfeatureDelete(item: Item_2Dfeature) {    
    this.isShowLoading = true;    
    this.item_2DfeatureService.deleteBySQL(item.Item_ID, item.Feature_ID2D).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_2DfeatureByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_2DfeatureInsert() {    
    this.isShowLoading = true;    
    this.item_2DfeatureService.formData.Item_ID=this.itemService.formData.ID;
    this.item_2DfeatureService.formData.Feature_ID2D=this.feature_ID2D;
    this.item_2DfeatureService.insertBySQL(this.item_2DfeatureService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_2DfeatureByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_3DfeatureDelete(item: Item_3Dfeature) {    
    this.isShowLoading = true;    
    this.item_3DfeatureService.deleteBySQL(item.Item_ID, item.Feature_ID3D).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_3DfeatureByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_3DfeatureInsert() {    
    this.isShowLoading = true;    
    this.item_3DfeatureService.formData.Item_ID=this.itemService.formData.ID;
    this.item_3DfeatureService.formData.Feature_ID3D=this.feature_ID3D;
    this.item_3DfeatureService.insertBySQL(this.item_3DfeatureService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_3DfeatureByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
  onItem_ColourAndFinishDelete(item: Item_ColourAndFinish) {    
    this.isShowLoading = true;    
    this.item_ColourAndFinishService.deleteBySQL(item.Item_ID, item.ColourAndFinish_ID).then(
      res => {       
        this.notificationService.warn(environment.DeleteSuccess);      
        this.getItem_ColourAndFinishByItemIDToList();
        this.isShowLoading = false;  
      },
      err => {
        this.notificationService.warn(environment.DeleteNotSuccess); 
        this.isShowLoading = false;       
      }
    );
  }
  onItem_ColourAndFinishInsert() {    
    this.isShowLoading = true;    
    this.item_ColourAndFinishService.formData.Item_ID=this.itemService.formData.ID;
    this.item_ColourAndFinishService.formData.ColourAndFinish_ID=this.colourAndFinish_ID;
    this.item_ColourAndFinishService.insertBySQL(this.item_ColourAndFinishService.formData).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.getItem_ColourAndFinishByItemIDToList();
        this.isShowLoading = false;
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.isShowLoading = false;
      }      
    );    
  }
}
