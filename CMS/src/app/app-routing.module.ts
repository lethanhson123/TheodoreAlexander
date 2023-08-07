import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BannerInfoComponent } from './banner/banner-info/banner-info.component';
import { BannerComponent } from './banner/banner.component';
import { GhostBlogComponent } from './ghost-blog/ghost-blog.component';
import { AdditionalFeaturesComponent } from './item/additional-features/additional-features.component';
import { BedInfomationComponent } from './item/bed-infomation/bed-infomation.component';
import { IsBestSellerComponent } from './item/is-best-seller/is-best-seller.component';
import { ItemActiveByBrandComponent } from './item/item-active-by-brand/item-active-by-brand.component';
import { ItemActiveByCollectionComponent } from './item/item-active-by-collection/item-active-by-collection.component';
import { ItemActiveByDesignerComponent } from './item/item-active-by-designer/item-active-by-designer.component';
import { ItemActiveByLifeStyleComponent } from './item/item-active-by-life-style/item-active-by-life-style.component';
import { ItemActiveByRoomAndUsageComponent } from './item/item-active-by-room-and-usage/item-active-by-room-and-usage.component';
import { ItemActiveByShapeComponent } from './item/item-active-by-shape/item-active-by-shape.component';
import { ItemActiveByStyleComponent } from './item/item-active-by-style/item-active-by-style.component';
import { ItemActiveByTypeComponent } from './item/item-active-by-type/item-active-by-type.component';
import { ItemActiveExtendingComponent } from './item/item-active-extending/item-active-extending.component';
import { ItemActiveIsBestSellerComponent } from './item/item-active-is-best-seller/item-active-is-best-seller.component';
import { ItemActiveIsCFPItemComponent } from './item/item-active-is-cfpitem/item-active-is-cfpitem.component';
import { ItemActiveIsNewComponent } from './item/item-active-is-new/item-active-is-new.component';
import { ItemActiveIsStockedComponent } from './item/item-active-is-stocked/item-active-is-stocked.component';
import { ItemActiveComponent } from './item/item-active/item-active.component';
import { ItemInfoComponent } from './item/item-info/item-info.component';
import { ItemInitializationComponent } from './item/item-initialization/item-initialization.component';
import { ItemInsertOrUpdateComponent } from './Item/item-insert-or-update/item-insert-or-update.component';
import { ItemComponent } from './item/item.component';
import { ProductNameAndExtendedDescriptionComponent } from './item/product-name-and-extended-description/product-name-and-extended-description.component';
import { MarketingResourceCategoryComponent } from './marketing-resource/marketing-resource-category/marketing-resource-category.component';
import { MarketingResourceInfoComponent } from './marketing-resource/marketing-resource-info/marketing-resource-info.component';
import { MarketingResourceComponent } from './marketing-resource/marketing-resource.component';
import { SEOBlogTemplateInfoComponent } from './seoblog-template/seoblog-template-info/seoblog-template-info.component';
import { SEOBlogTemplateComponent } from './seoblog-template/seoblog-template.component';
import { SEOBlogInfoComponent } from './seoblog/seoblog-info/seoblog-info.component';
import { SEOBlogInitializationComponent } from './seoblog/seoblog-initialization/seoblog-initialization.component';
import { SEOBlogComponent } from './seoblog/seoblog.component';
import { SEOKeywordComponent } from './seokeyword/seokeyword.component';
import { ShoppingCartInfoComponent } from './shopping-cart/shopping-cart-info/shopping-cart-info.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { SystemApplicationComponent } from './system-application/system-application.component';
import { SystemAuthenticationApplicationComponent } from './system-authentication-application/system-authentication-application.component';
import { SystemAuthenticationMenuComponent } from './system-authentication-menu/system-authentication-menu.component';
import { MembershipInfomationComponent } from './system-membership/membership-infomation/membership-infomation.component';
import { SystemMembershipComponent } from './system-membership/system-membership.component';
import { SystemMenuComponent } from './system-menu/system-menu.component';
import { BrandComponent } from './system/brand/brand.component';
import { CityComponent } from './system/city/city.component';
import { CollectionComponent } from './system/collection/collection.component';
import { ContinentComponent } from './system/continent/continent.component';
import { CountryComponent } from './system/country/country.component';
import { DesignerComponent } from './system/designer/designer.component';
import { LifeStyleComponent } from './system/life-style/life-style.component';
import { RegionComponent } from './system/region/region.component';
import { RoomAndUsageComponent } from './system/room-and-usage/room-and-usage.component';
import { ShapeComponent } from './system/shape/shape.component';
import { StyleComponent } from './system/style/style.component';
import { SystemComponent } from './system/system.component';
import { TypeComponent } from './system/type/type.component';
import { UPHColourComponent } from './system/uphcolour/uphcolour.component';
import { UPHFabricComponent } from './system/uphfabric/uphfabric.component';
import { UserByStoreComponent } from './user-by-store/user-by-store.component';
import { UserEmailByDateComponent } from './user-email-by-date/user-email-by-date.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  //{ path: '', redirectTo: '/Item', pathMatch: 'full' },  
  {
    path: 'GhostBlog', component: GhostBlogComponent,
  },
  {
    path: 'SEOKeyword', component: SEOKeywordComponent,
  },
  {
    path: 'SEOBlogTemplate', component: SEOBlogTemplateComponent,
  },
  {
    path: 'SEOBlogTemplateInfo/:ID', component: SEOBlogTemplateInfoComponent,
  }, 
  {
    path: 'SEOBlog', component: SEOBlogComponent,
  },
  {
    path: 'SEOBlogInitialization', component: SEOBlogInitializationComponent,
  },
  {
    path: 'SEOBlogInfo/:ID', component: SEOBlogInfoComponent,
  }, 
  {
    path: 'Banner', component: BannerComponent,
  },
  {
    path: 'BannerInfo/:ID', component: BannerInfoComponent,
  }, 
  {
    path: 'MarketingResource', component: MarketingResourceComponent,
  },
  {
    path: 'MarketingResourceInfo/:ID', component: MarketingResourceInfoComponent,
  },  
  {
    path: 'MarketingResourceCategory', component: MarketingResourceCategoryComponent,
  },
  {
    path: 'SystemMembership', component: SystemMembershipComponent,
  },
  {
    path: 'SystemMembershipInfomation', component: MembershipInfomationComponent,
  },
  {
    path: 'SystemApplication', component: SystemApplicationComponent,
  },
  {
    path: 'SystemMenu', component: SystemMenuComponent,
  },  
  {
    path: 'SystemAuthenticationApplication', component: SystemAuthenticationApplicationComponent,
  },
  {
    path: 'SystemAuthenticationMenu', component: SystemAuthenticationMenuComponent,
  },
  {
    path: 'Sitemap', component: SystemComponent,
  },
  {
    path: 'User', component: UserComponent,
  },
  {
    path: 'UserByStore', component: UserByStoreComponent,
  },
  {
    path: 'UserByDate', component: UserEmailByDateComponent,
  },
  {
    path: 'System', component: SystemComponent,
  },
  {
    path: 'Shape', component: ShapeComponent,
  },
  {
    path: 'LifeStyle', component: LifeStyleComponent,
  },
  {
    path: 'Style', component: StyleComponent,
  },
  {
    path: 'Collection', component: CollectionComponent,
  },
  {
    path: 'Designer', component: DesignerComponent,
  },
  {
    path: 'Brand', component: BrandComponent,
  },
  {
    path: 'Type', component: TypeComponent,
  },
  {
    path: 'RoomAndUsage', component: RoomAndUsageComponent,
  },
  {
    path: 'UPHFabric', component: UPHFabricComponent,
  },
  {
    path: 'UPHColour', component: UPHColourComponent,
  },
  {
    path: 'Continent', component: ContinentComponent,
  },
  {
    path: 'Country', component: CountryComponent,
  },
  {
    path: 'Region', component: RegionComponent,
  },
  {
    path: 'City', component: CityComponent,
  },  
  {
    path: 'Item', component: ItemComponent,
  },
  {
    path: 'ItemInitialization', component: ItemInitializationComponent,
  },
  {
    path: 'ItemActive', component: ItemActiveComponent,
  },
  {
    path: 'ItemActiveExtending', component: ItemActiveExtendingComponent,
  },
  {
    path: 'ItemActiveIsCFPItem', component: ItemActiveIsCFPItemComponent,
  },
  {
    path: 'ItemActiveIsNew', component: ItemActiveIsNewComponent,
  },
  {
    path: 'ItemActiveIsStocked', component: ItemActiveIsStockedComponent,
  },
  {
    path: 'ItemActiveIsBestSeller', component: ItemActiveIsBestSellerComponent,
  },
  {
    path: 'ItemActiveByRoomAndUsage', component: ItemActiveByRoomAndUsageComponent,
  },
  {
    path: 'ItemActiveByType', component: ItemActiveByTypeComponent,
  },
  {
    path: 'ItemActiveByBrand', component: ItemActiveByBrandComponent,
  },
  {
    path: 'ItemActiveByCollection', component: ItemActiveByCollectionComponent,
  },
  {
    path: 'ItemActiveByLifeStyle', component: ItemActiveByLifeStyleComponent,
  },
  {
    path: 'ItemActiveByStyle', component: ItemActiveByStyleComponent,
  },
  {
    path: 'ItemActiveByShape', component: ItemActiveByShapeComponent,
  },
  {
    path: 'ItemActiveByDesigner', component: ItemActiveByDesignerComponent,
  },
  {
    path: 'ItemBedInfomation', component: BedInfomationComponent,
  },
  {
    path: 'IsBestSeller', component: IsBestSellerComponent,
  },
  {
    path: 'AdditionalFeatures', component: AdditionalFeaturesComponent,
  },
  {
    path: 'ProductNameAndExtendedDescription', component: ProductNameAndExtendedDescriptionComponent,
  },
  {
    path: 'ItemInsertOrUpdate', component: ItemInsertOrUpdateComponent,
  },
  {
    path: 'Item/:AuthenticationToken', component: ItemComponent,
  },
  {
    path: 'item-info/:ID', component: ItemInfoComponent,
  },  
  {
    path: 'cart', component: ShoppingCartComponent,
  },
  {
    path: 'cart-info/:ID', component: ShoppingCartInfoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
