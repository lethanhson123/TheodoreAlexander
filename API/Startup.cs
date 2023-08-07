using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;

namespace TA.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddDbContext<TheodoreAlexander_NewContext>();
            services.AddTransient<ICareRepository, CareRepository>();
            services.AddTransient<ICenturyRepository, CenturyRepository>();
            services.AddTransient<IColourAndFinishRepository, ColourAndFinishRepository>();
            services.AddTransient<IGeographyRepository, GeographyRepository>();
            services.AddTransient<IHistoricalStyleRepository, HistoricalStyleRepository>();
            services.AddTransient<IProcessAndTechniqueRepository, ProcessAndTechniqueRepository>();
            services.AddTransient<IFeature2DRepository, Feature2DRepository>();
            services.AddTransient<IFeature3DRepository, Feature3DRepository>();            
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IContinentRepository, ContinentRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItem_StatusRepository, Item_StatusRepository>();
            services.AddTransient<IItem_PriceRepository, Item_PriceRepository>();
            services.AddTransient<IItem_FabricRepository, Item_FabricRepository>();
            services.AddTransient<IItem_ShapeRepository, Item_ShapeRepository>();
            services.AddTransient<IItem_2DfeatureRepository, Item_2DfeatureRepository>();
            services.AddTransient<IItem_3DfeatureRepository, Item_3DfeatureRepository>();
            services.AddTransient<IItem_CareRepository, Item_CareRepository>();
            services.AddTransient<IItem_CenturyRepository, Item_CenturyRepository>();
            services.AddTransient<IItem_ColourAndFinishRepository, Item_ColourAndFinishRepository>();
            services.AddTransient<IItem_GeographyRepository, Item_GeographyRepository>();
            services.AddTransient<IItem_HistoricalStyleRepository, Item_HistoricalStyleRepository>();
            services.AddTransient<IItem_ProcessAndTechniqueRepository, Item_ProcessAndTechniqueRepository>();
            services.AddTransient<IRelatedItemRepository, RelatedItemRepository>();
            services.AddTransient<IRelatedSkuForSpecialGroupRepository, RelatedSkuForSpecialGroupRepository>();
            services.AddTransient<ISKUListingForSizeAvailabilityRepository, SKUListingForSizeAvailabilityRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<ILifeStyleRepository, LifeStyleRepository>();
            services.AddTransient<IStyleRepository, StyleRepository>();
            services.AddTransient<IShapeRepository, ShapeRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDesignerRepository, DesignerRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IRoomAndUsageRepository, RoomAndUsageRepository>();
            services.AddTransient<IUPHFabricRepository, UPHFabricRepository>();
            services.AddTransient<IUPHColourRepository, UPHColourRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IOptionGroupRepository, OptionGroupRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IShoppingCart_ItemRepository, ShoppingCart_ItemRepository>();

            services.AddDbContext<TheodoreAlexander_ERPContext>();
            services.AddTransient<IHR_BlockRepository, HR_BlockRepository>();
            services.AddTransient<IHR_DepartmentRepository, HR_DepartmentRepository>();
            services.AddTransient<IHR_DistrictRepository, HR_DistrictRepository>();
            services.AddTransient<IHR_DivisionRepository, HR_DivisionRepository>();
            services.AddTransient<IHR_DutyRepository, HR_DutyRepository>();
            services.AddTransient<IHR_Employee_HistoryWorkRepository, HR_Employee_HistoryWorkRepository>();
            services.AddTransient<IHR_EmployeeRepository, HR_EmployeeRepository>();
            services.AddTransient<IHR_GroupRepository, HR_GroupRepository>();
            services.AddTransient<IHR_ProvinceRepository, HR_ProvinceRepository>();
            services.AddTransient<IHR_Recruitment_CareerRepository, HR_Recruitment_CareerRepository>();
            services.AddTransient<IHR_Recruitment_IntroduceRepository, HR_Recruitment_IntroduceRepository>();
            services.AddTransient<IHR_StatusRepository, HR_StatusRepository>();
            services.AddTransient<IHR_TeamRepository, HR_TeamRepository>();
            services.AddTransient<IHR_WardRepository, HR_WardRepository>();
            services.AddTransient<IHR_WorkingStatusRepository, HR_WorkingStatusRepository>();
            services.AddTransient<IHR_CovidLocalRepository, HR_CovidLocalRepository>();
            services.AddTransient<IHR_CovidRepository, HR_CovidRepository>();
            services.AddTransient<IHR_CovidResultRepository, HR_CovidResultRepository>();
            services.AddTransient<IHR_CovidTestRepository, HR_CovidTestRepository>();
            services.AddTransient<IMarketingResourceRepository, MarketingResourceRepository>();
            services.AddTransient<IMarketingResourceCategoryRepository, MarketingResourceCategoryRepository>();
            services.AddTransient<IMarketingResourceDetailRepository, MarketingResourceDetailRepository>();
            services.AddTransient<ISystem_ApplicationRepository, System_ApplicationRepository>();
            services.AddTransient<ISystem_AuthenticationApplicationRepository, System_AuthenticationApplicationRepository>();
            services.AddTransient<ISystem_AuthenticationMenuRepository, System_AuthenticationMenuRepository>();
            services.AddTransient<ISystem_AuthenticationTokenRepository, System_AuthenticationTokenRepository>();
            services.AddTransient<ISystem_MembershipRepository, System_MembershipRepository>();
            services.AddTransient<ISystem_MenuRepository, System_MenuRepository>();
            services.AddTransient<ISystem_MenuRepository, System_MenuRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<IBannerDetailRepository, BannerDetailRepository>();
            services.AddTransient<IGhostBlogRepository, GhostBlogRepository>();
            services.AddTransient<ISEOBlogRepository, SEOBlogRepository>();
            services.AddTransient<ISEOBlogTypeRepository, SEOBlogTypeRepository>();
            services.AddTransient<ISEOBlogItemRepository, SEOBlogItemRepository>();
            services.AddTransient<ISEOBlogStoreRepository, SEOBlogStoreRepository>();
            services.AddTransient<ISEOBlogTemplateRepository, SEOBlogTemplateRepository>();
            services.AddTransient<ISEOKeywordRepository, SEOKeywordRepository>();

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
             options.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
