using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using DAL.ViewModels;
using BL.Extensions;
using BL.EntityService;
using System.Configuration;
using System.Transactions;
using System.Text;
using BL.DTO;
using BL.BusinessService;
//using System.Data.Linq.SqlClient;

namespace BL.BUServices
{
    public interface IProductListingItemService : IDisposable
    {
        PageResult<ItemDto> GetListingItemsV2(RequestItemObj requestObj, JWTIdentityViewModel jwtModel);
        SidebarItemCountViewModel CountItemForSidebarFilter(CountItemForSidebarRequestObj requestObj, JWTIdentityViewModel jwtModel);
        Task<DimensionCMAndInch> GetItemRanges(DimensionRequestObj originRequestObj, JWTIdentityViewModel jwtModel);
        Task<IList<ColourAndFinishViewModel>> GetColourAndFinishes();
    }

    public class ProductListingItemService : IProductListingItemService
    {
        private readonly ItemBusinessService _itemBusinessService;
        private bool disposed = false;
        public ProductListingItemService(ItemBusinessService itemService)
        {
            _itemBusinessService = itemService;
        }

        #region Implement interface

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemBusinessService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PageResult<ItemDto> GetListingItemsV2(RequestItemObj requestObj, JWTIdentityViewModel jwtModel)
        {
            _itemBusinessService.ConvertNamesToIdsIfNeeded(requestObj);
            return GetListingItems(requestObj, jwtModel);
        }

        public PageResult<ItemDto> GetListingItems(RequestItemObj requestObj, JWTIdentityViewModel jwtModel)
        {
            var items = _itemBusinessService.FilterForItems(requestObj, jwtModel).OrderByDescending(i => i.IsNew);//true = is at the top
            int count = items.Count();
            int currentPage = requestObj.PageNum;
            int pageSize = requestObj.PageSize;
            int totalCount = count;
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);
            int skip = (currentPage - 1) * pageSize;
            var previousPage = currentPage > 1 ? true : false;
            var nextPage = currentPage < totalPages ? true : false;
            //var x = items.OrderBy(i => i.SKU).then;
            switch (requestObj.OrderBy)
            {
                case "IsBestSeller":
                    if (requestObj.Ascending)
                    {
                        items = items.OrderBy(i => i.IsBestSeller);
                    }
                    else
                    {
                        items = items.OrderByDescending(i => i.IsBestSeller);
                    }
                    break;
                case "ProductName":
                    if (requestObj.Ascending)
                    {
                        items = items.OrderBy(i => i.ProductName);
                    }
                    else
                    {
                        items = items.OrderByDescending(i => i.ProductName);
                    }
                    break;
            }
            var pagingItems = items
                //.OrderByPropertyOrField(requestObj.OrderBy, requestObj.Ascending)
                .ThenBy(i => i.RoomAndUsage.Order)
                .ThenBy(i => i.Type.Order)
                .ThenBy(i => i.SKU)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
            try
            {
                IQueryable<ItemDto> itemViewModels = pagingItems.Select(i => new ItemDto(i)
                {
                    IsInWishList = _itemBusinessService.IsInWishlist(i.SKU, jwtModel)
                }).AsQueryable();

                PageResult<ItemDto> itemPaginationViewModel = new PageResult<ItemDto>()
                {
                    Items = itemViewModels.ToList(),
                    TotalCount = totalCount,
                    TotalPage = totalPages,
                    CurrentPage = currentPage,
                    PreviousPage = previousPage,
                    NextPage = nextPage,
                    PageSize = pageSize,
                    Region = jwtModel.Region,
                    Country = jwtModel.Country,
                    CountryFullName = jwtModel.CountryFullName,
                    RequestIpAddress = jwtModel.RequestIpAddress,
                    ResponseIpAddress = jwtModel.ResponseIpAddress,
                };
                return itemPaginationViewModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<ColourAndFinishViewModel>> GetColourAndFinishes()
        {
            return await _itemBusinessService.GetColourAndFinishes();
        }

        public async Task<DimensionCMAndInch> GetItemRanges(DimensionRequestObj originRequestObj, JWTIdentityViewModel jwtModel)
        {
            try
            {
                RequestItemObj requestObj = new RequestItemObj
                {
                    BrandIds = originRequestObj.BrandIds,
                    CollectionIds = originRequestObj.CollectionIds,
                    RoomIds = originRequestObj.RoomIds,
                    TypeIds = originRequestObj.TypeIds,
                    LifeStyleIds = originRequestObj.LifeStyleIds,
                    StyleIds = originRequestObj.StyleIds,
                    DesignerIds = originRequestObj.DesignerIds,
                    OptionGroupIds = originRequestObj.OptionGroupIds,
                    ShapeIds = originRequestObj.ShapeIds,
                    ColourAndFinishIds = originRequestObj.ColourAndFinishIds,
                    SearchKey = originRequestObj.SearchKey,
                    IsCustomPalette = originRequestObj.IsCustomPalette,
                    NewOnly = originRequestObj.NewOnly,
                    DefaultItemOnly = originRequestObj.DefaultItemOnly,
                    IsStockProgram = originRequestObj.IsStockProgram,
                    IsStocked = originRequestObj.IsStocked,
                    IsBestSeller = originRequestObj.IsBestSeller,
                    Extending = originRequestObj.Extending
                };
                _itemBusinessService.ConvertNamesToIdsIfNeeded(requestObj);
                //Origin query
                var items = _itemBusinessService.GetAvailableItems(jwtModel);
                items = _itemBusinessService.GroupingItems(requestObj, items, jwtModel).Where(o =>
                (!requestObj.DefaultItemOnly || o.DefaultCode == null || o.DefaultCode.Trim() == "" || o.DefaultCode.ToLower().Trim() == o.SKU.ToLower().Trim()));
                var count = await items.CountAsync();
                if (count > 0)
                {
                    DimensionCM dimensionCM = new DimensionCM
                    {
                        WidthMin = await items.MinAsync(o => o.Width ?? 0),
                        WidthMax = await items.MaxAsync(o => o.Width ?? 0),
                        HeightMin = await items.MinAsync(o => o.Height ?? 0),
                        HeightMax = await items.MaxAsync(o => o.Height ?? 0),
                        DepthMin = await items.MinAsync(o => o.Depth ?? 0),
                        DepthMax = await items.MaxAsync(o => o.Depth ?? 0)
                    };
                    DimensionInch dimensionInch = new DimensionInch
                    {
                        WidthMax = Math.Round(Convert.ToDecimal(Convert.ToDouble(dimensionCM.WidthMax) / 2.54), 5),
                        WidthMin = Math.Round(Convert.ToDecimal(Convert.ToDouble(dimensionCM.WidthMin) / 2.54), 5),
                        HeightMin = Math.Round(Convert.ToDecimal(Convert.ToDouble(dimensionCM.HeightMin) / 2.54), 5),
                        HeightMax = Math.Round(Convert.ToDecimal(Convert.ToDouble(dimensionCM.HeightMax) / 2.54), 5),
                        DepthMin = Math.Round(Convert.ToDecimal(Convert.ToDouble(dimensionCM.DepthMin) / 2.54), 5),
                        DepthMax = Math.Round(Convert.ToDecimal(Convert.ToDouble(dimensionCM.DepthMax) / 2.54), 5)
                    };
                    return new DimensionCMAndInch
                    {
                        CM = dimensionCM,
                        Inch = dimensionInch
                    };
                }
                else
                {
                    return new DimensionCMAndInch();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SidebarItemCountViewModel CountItemForSidebarFilter(CountItemForSidebarRequestObj requestObj, JWTIdentityViewModel jwtModel)
        {
            // Count Item for sidebar Ex: Count by Collections. 
            // First, count item for all condition ignore Collection (Type, Style...)
            // Second, get item for all condition ignore Collection, recount item for collection
            _itemBusinessService.ConvertNamesToIdsIfNeeded(requestObj.IgnoreCountby);
            _itemBusinessService.ConvertNamesToIdsIfNeeded(requestObj.IncludeCountby);

            IQueryable<Item> items = _itemBusinessService.GetAvailableItems(jwtModel);
            //Query Item with more included condition
            items = items.Where(o => (!requestObj.IncludeCountby.DefaultItemOnly || o.DefaultCode == null || o.DefaultCode.Trim() == "" || o.DefaultCode.ToLower().Trim() == o.SKU.ToLower().Trim()));
            //Groupping items, count item group by "CountBy"
            items = _itemBusinessService.GroupingItemsCountForSidebarFilter(requestObj.IncludeCountby, items, jwtModel);

            try
            {
                SidebarItemCountViewModel result = new SidebarItemCountViewModel
                {
                    ListCount = new List<CountViewModel>()
                };

                // Items for recount
                IQueryable<Item> reCountItems = _itemBusinessService.GetAvailableItems(jwtModel);
                reCountItems = reCountItems.Where(o => (!requestObj.IgnoreCountby.DefaultItemOnly || o.DefaultCode == null || o.DefaultCode.Trim() == "" || o.DefaultCode.ToLower().Trim() == o.SKU.ToLower().Trim()));
                reCountItems = _itemBusinessService.GroupingItemsCountForSidebarFilter(requestObj.IgnoreCountby, reCountItems, jwtModel);

                if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.Type)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(reCountItems));
                }
                else if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.Collection)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(reCountItems));
                }
                else if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.LifeStyle)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(reCountItems));
                }
                else if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.Style)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(reCountItems));
                }
                else if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.Shape)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(reCountItems));
                }
                else if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.Extending)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(reCountItems));
                }
                else if (requestObj.CountBy == ConstClass.ConstSidebarCountBy.ColourAndFinish)
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarColourAndFinishItemsCount(reCountItems));
                }
                else
                {
                    result.ListCount.AddRange(_itemBusinessService.SidebarTypeItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarCollectionItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarLifeStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarStyleItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarExtendingItemsCount(items));
                    result.ListCount.AddRange(_itemBusinessService.SidebarShapeItemsCount(items));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
