import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { UserService } from './shared/User.service';
import { StoreService } from './shared/Store.service';
import { ShapeService } from './shared/Shape.service';
import { LifeStyleService } from './shared/LifeStyle.service';
import { StyleService } from './shared/Style.service';
import { CollectionService } from './shared/Collection.service';
import { DesignerService } from './shared/Designer.service';
import { BrandService } from './shared/Brand.service';
import { TypeService } from './shared/Type.service';
import { RoomAndUsageService } from './shared/RoomAndUsage.service';
import { ItemService } from './shared/Item.service';
import { Item_StatusService } from './shared/Item_Status.service';
import { Item_PriceService } from './shared/Item_Price.service';
import { Item_FabricService } from './shared/Item_Fabric.service';
import { Item_ShapeService } from './shared/Item_Shape.service';
import { Item_2DfeatureService } from './shared/Item_2Dfeature.service';
import { Item_3DfeatureService } from './shared/Item_3Dfeature.service';
import { Item_CareService } from './shared/Item_Care.service';
import { Item_CenturyService } from './shared/Item_Century.service';
import { Item_ColourAndFinishService } from './shared/Item_ColourAndFinish.service';
import { Item_GeographyService } from './shared/Item_Geography.service';
import { Item_HistoricalStyleService } from './shared/Item_HistoricalStyle.service';
import { Item_ProcessAndTechniqueService } from './shared/Item_ProcessAndTechnique.service';
import { RelatedItemService } from './shared/RelatedItem.service';
import { SKUListingForSizeAvailabilityService } from './shared/SKUListingForSizeAvailability.service';
import { RelatedSkuForSpecialGroupService } from './shared/RelatedSkuForSpecialGroup.service';
import { UPHFabricService } from './shared/UPHFabric.service';
import { UPHColourService } from './shared/UPHColour.service';
import { CareService } from './shared/Care.service';
import { CenturyService } from './shared/Century.service';
import { ColourAndFinishService } from './shared/ColourAndFinish.service';
import { Feature2DService } from './shared/Feature2D.service';
import { Feature3DService } from './shared/Feature3D.service';
import { GeographyService } from './shared/Geography.service';
import { HistoricalStyleService } from './shared/HistoricalStyle.service';
import { ProcessAndTechniqueService } from './shared/ProcessAndTechnique.service';
import { System_ApplicationService } from './shared/System_Application.service';
import { System_AuthenticationApplicationService } from './shared/System_AuthenticationApplication.service';
import { System_AuthenticationMenuService } from './shared/System_AuthenticationMenu.service';
import { System_AuthenticationTokenService } from './shared/System_AuthenticationToken.service';
import { System_MembershipService } from './shared/System_Membership.service';
import { System_MenuService } from './shared/System_Menu.service';
import { OptionGroupService } from './shared/OptionGroup.service';
import { ShoppingCartService } from './shared/ShoppingCart.service';
import { ShoppingCart_ItemService } from './shared/ShoppingCart_Item.service';
import { EmailService } from './shared/Email.service';
import { MarketingResourceService } from './shared/MarketingResource.service';
import { MarketingResourceCategoryService } from './shared/MarketingResourceCategory.service';
import { MarketingResourceDetailService } from './shared/MarketingResourceDetail.service';
import { BannerService } from './shared/Banner.service';
import { BannerDetailService } from './shared/BannerDetail.service';
import { GhostBlogService } from './shared/GhostBlog.service';
import { SEOBlogService } from './shared/SEOBlog.service';
import { SEOBlogItemService } from './shared/SEOBlogItem.service';
import { SEOBlogStoreService } from './shared/SEOBlogStore.service';
import { SEOBlogTemplateService } from './shared/SEOBlogTemplate.service';
import { SEOKeywordService } from './shared/SEOKeyword.service';
import { CountryService } from './shared/Country.service';
import { RegionService } from './shared/Region.service';
import { MaterialService } from './shared/Material.service';
import { LoadingComponent } from './loading/loading.component';
import { UserComponent } from './user/user.component';
import { UserByStoreComponent } from './user-by-store/user-by-store.component';
import { SystemComponent } from './system/system.component';
import { ShapeComponent } from './system/shape/shape.component';
import { ShapeDetailComponent } from './system/shape/shape-detail/shape-detail.component';
import { LifeStyleComponent } from './system/life-style/life-style.component';
import { LifeStyleDetailComponent } from './system/life-style/life-style-detail/life-style-detail.component';
import { CollectionComponent } from './system/collection/collection.component';
import { CollectionDetailComponent } from './system/collection/collection-detail/collection-detail.component';
import { DesignerComponent } from './system/designer/designer.component';
import { DesignerDetailComponent } from './system/designer/designer-detail/designer-detail.component';
import { BrandComponent } from './system/brand/brand.component';
import { BrandDetailComponent } from './system/brand/brand-detail/brand-detail.component';
import { TypeComponent } from './system/type/type.component';
import { TypeDetailComponent } from './system/type/type-detail/type-detail.component';
import { RoomAndUsageComponent } from './system/room-and-usage/room-and-usage.component';
import { RoomAndUsageDetailComponent } from './system/room-and-usage/room-and-usage-detail/room-and-usage-detail.component';
import { ItemComponent } from './item/item.component';
import { ItemDetailComponent } from './item/item-detail/item-detail.component';
import { ItemInfoComponent } from './item/item-info/item-info.component';
import { SystemApplicationComponent } from './system-application/system-application.component';
import { SystemMembershipComponent } from './system-membership/system-membership.component';
import { SystemMenuComponent } from './system-menu/system-menu.component';
import { SystemAuthenticationApplicationComponent } from './system-authentication-application/system-authentication-application.component';
import { SystemAuthenticationMenuComponent } from './system-authentication-menu/system-authentication-menu.component';
import { MembershipDetailComponent } from './system-membership/membership-detail/membership-detail.component';
import { ApplicationDetailComponent } from './system-application/application-detail/application-detail.component';
import { AuthenticationApplicationDetailComponent } from './system-authentication-application/authentication-application-detail/authentication-application-detail.component';
import { MembershipInfomationComponent } from './system-membership/membership-infomation/membership-infomation.component';
import { UserEmailByDateComponent } from './user-email-by-date/user-email-by-date.component';
import { StyleComponent } from './system/style/style.component';
import { StyleDetailComponent } from './system/style/style-detail/style-detail.component';
import { UPHFabricComponent } from './system/uphfabric/uphfabric.component';
import { ItemActiveByTypeComponent } from './item/item-active-by-type/item-active-by-type.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ShoppingCartInfoComponent } from './shopping-cart/shopping-cart-info/shopping-cart-info.component';
import { BedInfomationComponent } from './item/bed-infomation/bed-infomation.component';
import { ItemActiveByCollectionComponent } from './item/item-active-by-collection/item-active-by-collection.component';
import { ItemActiveByDesignerComponent } from './item/item-active-by-designer/item-active-by-designer.component';
import { ItemActiveByLifeStyleComponent } from './item/item-active-by-life-style/item-active-by-life-style.component';
import { ItemActiveByRoomAndUsageComponent } from './item/item-active-by-room-and-usage/item-active-by-room-and-usage.component';
import { ItemActiveByShapeComponent } from './item/item-active-by-shape/item-active-by-shape.component';
import { ItemActiveByStyleComponent } from './item/item-active-by-style/item-active-by-style.component';
import { ItemActiveByBrandComponent } from './item/item-active-by-brand/item-active-by-brand.component';
import { ItemActiveComponent } from './item/item-active/item-active.component';
import { ItemActiveIsNewComponent } from './item/item-active-is-new/item-active-is-new.component';
import { ItemActiveExtendingComponent } from './item/item-active-extending/item-active-extending.component';
import { ItemActiveIsCFPItemComponent } from './item/item-active-is-cfpitem/item-active-is-cfpitem.component';
import { ItemActiveIsStockedComponent } from './item/item-active-is-stocked/item-active-is-stocked.component';
import { MarketingResourceComponent } from './marketing-resource/marketing-resource.component';
import { MarketingResourceCategoryComponent } from './marketing-resource/marketing-resource-category/marketing-resource-category.component';
import { MarketingResourceCategoryDetailComponent } from './marketing-resource/marketing-resource-category/marketing-resource-category-detail/marketing-resource-category-detail.component';
import { MarketingResourceInfoComponent } from './marketing-resource/marketing-resource-info/marketing-resource-info.component';
import { MarketingResourceDetailDetailComponent } from './marketing-resource/marketing-resource-info/marketing-resource-detail-detail/marketing-resource-detail-detail.component';
import { BannerComponent } from './banner/banner.component';
import { BannerInfoComponent } from './banner/banner-info/banner-info.component';
import { BannerDetailDetailComponent } from './banner/banner-detail-detail/banner-detail-detail.component';
import { SEOKeywordComponent } from './seokeyword/seokeyword.component';
import { SEOKeywordDetailComponent } from './seokeyword/seokeyword-detail/seokeyword-detail.component';
import { SEOBlogTemplateComponent } from './seoblog-template/seoblog-template.component';
import { SEOBlogTemplateInfoComponent } from './seoblog-template/seoblog-template-info/seoblog-template-info.component';
import { SEOBlogComponent } from './seoblog/seoblog.component';
import { SEOBlogInfoComponent } from './seoblog/seoblog-info/seoblog-info.component';
import { SEOBlogTemplateDetailComponent } from './seoblog-template/seoblog-template-detail/seoblog-template-detail.component';
import { UPHColourComponent } from './system/uphcolour/uphcolour.component';
import { IsBestSellerComponent } from './item/is-best-seller/is-best-seller.component';
import { ItemActiveIsBestSellerComponent } from './item/item-active-is-best-seller/item-active-is-best-seller.component';
import { ContinentComponent } from './system/continent/continent.component';
import { CountryComponent } from './system/country/country.component';
import { RegionComponent } from './system/region/region.component';
import { CityComponent } from './system/city/city.component';
import { GhostBlogComponent } from './ghost-blog/ghost-blog.component';
import { AdditionalFeaturesComponent } from './item/additional-features/additional-features.component';
import { ProductNameAndExtendedDescriptionComponent } from './item/product-name-and-extended-description/product-name-and-extended-description.component';
import { SEOBlogInitializationComponent } from './seoblog/seoblog-initialization/seoblog-initialization.component';
import { ItemInitializationComponent } from './item/item-initialization/item-initialization.component';
import { ItemInsertOrUpdateComponent } from './Item/item-insert-or-update/item-insert-or-update.component';

@NgModule({
  declarations: [
    AppComponent,    
    LoadingComponent,     
    UserComponent, 
    UserByStoreComponent, 
    SystemComponent, 
    ShapeComponent,  
    ShapeDetailComponent, 
    LifeStyleComponent,  
    LifeStyleDetailComponent, 
    CollectionComponent, 
    CollectionDetailComponent, 
    DesignerComponent, 
    DesignerDetailComponent, 
    BrandComponent, 
    BrandDetailComponent, 
    TypeComponent, 
    TypeDetailComponent, 
    RoomAndUsageComponent, 
    RoomAndUsageDetailComponent, 
    ItemComponent, 
    ItemDetailComponent, 
    ItemInfoComponent, 
    SystemApplicationComponent, 
    SystemMembershipComponent, 
    SystemMenuComponent, 
    SystemAuthenticationApplicationComponent, 
    SystemAuthenticationMenuComponent, 
    MembershipDetailComponent,
    ApplicationDetailComponent,
    AuthenticationApplicationDetailComponent,
    MembershipInfomationComponent,
    UserEmailByDateComponent,
    StyleComponent,
    StyleDetailComponent,
    UPHFabricComponent,
    ItemActiveByTypeComponent,
    ShoppingCartComponent,
    ShoppingCartInfoComponent,
    BedInfomationComponent,
    ItemActiveByCollectionComponent,
    ItemActiveByDesignerComponent,
    ItemActiveByLifeStyleComponent,
    ItemActiveByRoomAndUsageComponent,
    ItemActiveByShapeComponent,
    ItemActiveByStyleComponent,
    ItemActiveByBrandComponent,
    ItemActiveComponent,
    ItemActiveIsNewComponent,
    ItemActiveExtendingComponent,
    ItemActiveIsCFPItemComponent,
    ItemActiveIsStockedComponent,
    MarketingResourceComponent,
    MarketingResourceCategoryComponent,
    MarketingResourceCategoryDetailComponent,
    MarketingResourceInfoComponent,
    MarketingResourceDetailDetailComponent,
    BannerComponent,
    BannerInfoComponent,
    BannerDetailDetailComponent,
    SEOKeywordComponent,
    SEOKeywordDetailComponent,
    SEOBlogTemplateComponent,
    SEOBlogTemplateInfoComponent,
    SEOBlogComponent,
    SEOBlogInfoComponent,
    SEOBlogTemplateDetailComponent,
    UPHColourComponent,
    IsBestSellerComponent,
    ItemActiveIsBestSellerComponent,
    ContinentComponent,
    CountryComponent,
    RegionComponent,
    CityComponent,
    GhostBlogComponent,
    AdditionalFeaturesComponent,
    ProductNameAndExtendedDescriptionComponent,
    SEOBlogInitializationComponent,
    ItemInitializationComponent,
    ItemInsertOrUpdateComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
  ],
  providers: [
    UserService,    
    StoreService,
    ShapeService,
    LifeStyleService,
    StyleService,
    CollectionService,
    DesignerService,
    BrandService,
    TypeService,
    RoomAndUsageService,
    ItemService,
    Item_StatusService,
    Item_PriceService,
    Item_FabricService,
    Item_ShapeService,
    Item_2DfeatureService,
    Item_3DfeatureService,
    Item_CareService,
    Item_CenturyService,
    Item_ColourAndFinishService,
    Item_GeographyService,
    Item_HistoricalStyleService,
    Item_ProcessAndTechniqueService,
    RelatedItemService,
    RelatedSkuForSpecialGroupService,
    SKUListingForSizeAvailabilityService,
    UPHFabricService,
    UPHColourService,
    CareService,
    CenturyService,
    ColourAndFinishService,
    Feature2DService,
    Feature3DService,
    GeographyService,
    HistoricalStyleService,
    ProcessAndTechniqueService,    
    System_ApplicationService,
    System_AuthenticationApplicationService,
    System_AuthenticationMenuService,
    System_AuthenticationTokenService,
    System_MembershipService,
    System_MenuService,
    OptionGroupService,
    ShoppingCartService,
    ShoppingCart_ItemService,
    EmailService,
    MarketingResourceService,
    MarketingResourceCategoryService,
    MarketingResourceDetailService,
    BannerService,
    BannerDetailService,
    GhostBlogService,
    SEOBlogService,
    SEOBlogItemService,
    SEOBlogStoreService,
    SEOBlogTemplateService,
    SEOKeywordService,
    CountryService,
    RegionService,
    MaterialService,    
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}
  ],
  entryComponents: [
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
