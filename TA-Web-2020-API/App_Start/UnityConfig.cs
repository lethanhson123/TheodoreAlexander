using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using DAL;
using BL;
using Unity.Lifetime;
using TA_Web_2020_API._2.APIService;
using TA.Data2021.Repositories;

namespace TA_Web_2020_API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            #region Model services
            container.RegisterType<DbContext, TheodoreAlexanderEntities>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.DataContextServices, BL.ModelServices.DataContextServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.CityModelServices, BL.ModelServices.CityModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.SalesAssociate_StoreModelServices, BL.ModelServices.SalesAssociate_StoreModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.UserModelServices, BL.ModelServices.UserModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.DealerModelServices, BL.ModelServices.DealerModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.CountryModelServices, BL.ModelServices.CountryModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.ExclusivityGroupModelServices, BL.ModelServices.ExclusivityGroupModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.DealerGroup_RegionModelServices, BL.ModelServices.DealerGroup_RegionModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.DynamicTableModelServices, BL.ModelServices.DynamicTableModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.UPHFabricModelServices, BL.ModelServices.UPHFabricModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.StoreModelServices, BL.ModelServices.StoreModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.QuotationModelServices, BL.ModelServices.QuotationModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.AddressModelServices, BL.ModelServices.AddressModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.SubcribedEmailModelServices, BL.ModelServices.SubcribedEmailModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.RegionModelServices, BL.ModelServices.RegionModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.ColourAndFinishModelServices, BL.ModelServices.ColourAndFinishModelServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.ModelServices.DesignerModelService, BL.ModelServices.DesignerModelService>(new TransientLifetimeManager());
            #endregion

            #region TA Services
            //container.RegisterType<BL.TAServices.GeneralServices, BL.TAServices.GeneralServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.TAServices.UserServices, BL.TAServices.UserServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.TAServices.FabricServices, BL.TAServices.FabricServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.TAServices.QuotationServices, BL.TAServices.QuotationServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.TAServices.LocatorServices, BL.TAServices.LocatorServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.TAServices.SubcribedEmailServices, BL.TAServices.SubcribedEmailServices>(new TransientLifetimeManager());
            ///container.RegisterType<BL.TAServices.ContactServices, BL.TAServices.ContactServices>(new TransientLifetimeManager());
            //container.RegisterType<BL.TAServices.DesignerService, BL.TAServices.DesignerService>(new TransientLifetimeManager());
            #endregion

            #region BU Servicess
            container.RegisterType<BL.BUServices.IProductDetailItemService, BL.BUServices.ProductDetailItemService>(new TransientLifetimeManager());
            container.RegisterType<BL.BUServices.IProductListingItemService, BL.BUServices.ProductListingItemService>(new TransientLifetimeManager());
            container.RegisterType<BL.BUServices.IContactService, BL.BUServices.ContactService>(new TransientLifetimeManager());
            container.RegisterType<BL.BUServices.IWishlistlItemService, BL.BUServices.WishlistIBusinessService>(new TransientLifetimeManager());
            container.RegisterType<BL.BUServices.IOrderService, BL.BUServices.OrderService>(new TransientLifetimeManager());

            container.RegisterType<IMetadataAPIService, MetadataAPIService>(new TransientLifetimeManager());
            container.RegisterType<IAdminAPIService, AdminAPIService>(new TransientLifetimeManager());

            container.RegisterType<IBrandRepository, BrandRepository>(new TransientLifetimeManager());
            container.RegisterType<IDesignerRepository, DesignerRepository>(new TransientLifetimeManager());
            container.RegisterType<ICollectionRepository, CollectionRepository>(new TransientLifetimeManager());
            container.RegisterType<ILifeStyleRepository, LifeStyleRepository>(new TransientLifetimeManager());
            container.RegisterType<IStyleRepository, StyleRepository>(new TransientLifetimeManager());
            container.RegisterType<IRoomAndUsageRepository, RoomAndUsageRepository>(new TransientLifetimeManager());
            container.RegisterType<IShapeRepository, ShapeRepository>(new TransientLifetimeManager());            
            container.RegisterType<ITypeRepository, TypeRepository>(new TransientLifetimeManager());
            container.RegisterType<IItemRepository, ItemRepository>(new TransientLifetimeManager());
            container.RegisterType<IItem_FabricRepository, Item_FabricRepository>(new TransientLifetimeManager());
            container.RegisterType<IMarketingResourceCategoryRepository, MarketingResourceCategoryRepository>(new TransientLifetimeManager());
            container.RegisterType<IMarketingResourceRepository, MarketingResourceRepository>(new TransientLifetimeManager());
            container.RegisterType<IMarketingResourceDetailRepository, MarketingResourceDetailRepository>(new TransientLifetimeManager());
            container.RegisterType<IBannerRepository, BannerRepository>(new TransientLifetimeManager());
            container.RegisterType<IBannerDetailRepository, BannerDetailRepository>(new TransientLifetimeManager());
            container.RegisterType<IStoreRepository, StoreRepository>(new TransientLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new TransientLifetimeManager());
            container.RegisterType<IDealer_TausRepository, Dealer_TausRepository>(new TransientLifetimeManager());
            #endregion

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}