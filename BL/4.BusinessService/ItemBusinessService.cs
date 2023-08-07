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
using System.Linq.Expressions;
using Castle.DynamicLinqQueryBuilder;
using DAL.EntityService;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Data.Entity.SqlServer;
//using System.Data.Linq.SqlClient;

namespace BL.BusinessService
{
    public class ItemBusinessService : IDisposable
    {
        protected readonly TheodoreAlexanderEntities _ctx;
        protected readonly udf_FreeTextSearchEntityService _udf_FreeTextSearchEntityService;
        protected readonly SKUListingForSizeAvailabilityEntityService _skuListingForSizeAvailabilityEntityService;
        protected readonly RelatedSkuForSpecialGroupEntityService _relatedSkuForSpecialGroupEntityService;
        protected readonly OptionEntityService _optionEntityService;
        protected readonly ColourAndFinishEntityService _colourAndFinishEntityService;
        protected readonly ItemStatusEntityService _itemStatusEntityService;
        protected readonly ItemPriceEntityService _itemPriceEntityService;
        protected readonly Profile_ItemPriceEntityService _profile_ItemPriceEntityService;
        protected readonly ItemEntityService _itemModelServices;
        protected readonly DealerEntityService _dealerServices;
        protected readonly StoreEntityService _storeServices;
        protected readonly UserModelServices _userService;
        protected readonly WishListModelServices _wishListModelServices;
        protected readonly ItemResourceFileEntityService _itemResourceFileModelService;

        protected readonly BrandEntityService _brandModelService;
        protected readonly CollectionEntityService _collectionModelService;
        protected readonly RoomEntityService _roomModelService;
        protected readonly TypeEntityService _typeModelService;
        protected readonly LifeStyleEntityService _lifeStyleModelService;
        protected readonly StyleEntityService _styleModelService;
        protected readonly DesignerEntityService _designerModelService;
        protected readonly ShapeEntityService _shapeModelService;
        protected readonly OptionGroupEntityService _optionGroupModelService;

        private bool disposed = false;

        public ItemBusinessService(TheodoreAlexanderEntities ctx)
        {
            _ctx = ctx;
            _udf_FreeTextSearchEntityService = new udf_FreeTextSearchEntityService(_ctx);
            _skuListingForSizeAvailabilityEntityService = new SKUListingForSizeAvailabilityEntityService(_ctx);
            _relatedSkuForSpecialGroupEntityService = new RelatedSkuForSpecialGroupEntityService(_ctx);
            _optionEntityService = new OptionEntityService(_ctx);
            _colourAndFinishEntityService = new ColourAndFinishEntityService(_ctx);
            _itemStatusEntityService = new ItemStatusEntityService(_ctx);
            _itemPriceEntityService = new ItemPriceEntityService(_ctx);
            _profile_ItemPriceEntityService = new Profile_ItemPriceEntityService(_ctx);
            _itemResourceFileModelService = new ItemResourceFileEntityService(_ctx);
            _itemModelServices = new ItemEntityService(_ctx);
            _dealerServices = new DealerEntityService(_ctx);
            _storeServices = new StoreEntityService(_ctx);
            _userService = new UserModelServices(_ctx);
            _wishListModelServices = new WishListModelServices(_ctx);
            _collectionModelService = new CollectionEntityService(_ctx);
            _brandModelService = new BrandEntityService(_ctx);
            _roomModelService = new RoomEntityService(_ctx);
            _typeModelService = new TypeEntityService(_ctx);
            _lifeStyleModelService = new LifeStyleEntityService(_ctx);
            _styleModelService = new StyleEntityService(_ctx);
            _designerModelService = new DesignerEntityService(_ctx);
            _shapeModelService = new ShapeEntityService(_ctx);
            _optionGroupModelService = new OptionGroupEntityService(_ctx);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _udf_FreeTextSearchEntityService.Dispose();
                _skuListingForSizeAvailabilityEntityService.Dispose();
                _relatedSkuForSpecialGroupEntityService.Dispose();
                _optionEntityService.Dispose();
                _colourAndFinishEntityService.Dispose();
                _itemStatusEntityService.Dispose();
                _itemPriceEntityService.Dispose();
                _profile_ItemPriceEntityService.Dispose();
                _itemModelServices.Dispose();
                _dealerServices.Dispose();
                _storeServices.Dispose();
                _userService.Dispose();
                _wishListModelServices.Dispose();
                _collectionModelService.Dispose();
                _brandModelService.Dispose();
                _roomModelService.Dispose();
                _typeModelService.Dispose();
                _lifeStyleModelService.Dispose();
                _styleModelService.Dispose();
                _designerModelService.Dispose();
                _shapeModelService.Dispose();
                _optionGroupModelService.Dispose();
                _itemResourceFileModelService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Implement interface
        //public virtual async Task<ItemDetailsViewModel2> GetItem(JWTIdentityViewModel jwtModel, string sku, Guid? Id) {
        //    if (Id.HasValue) {
        //        return await this.GetItemData(jwtModel, String.Empty, Id);
        //    }
        //    if (!String.IsNullOrEmpty(sku)) {
        //        return await this.GetItemData(jwtModel, sku, null);
        //    }
        //    return null;
        //}
        #endregion

        #region Private method
        private async Task<IList<ItemOptionGroupViewModel>> GetItemOptions(JWTIdentityViewModel jwtModel, Item item, string typeOption)
        {
            IList<ItemOptionsQueryableModel> options = new List<ItemOptionsQueryableModel>();
            var items = GetAvailableItems(jwtModel);
            //item can have many kinds of option
            switch (typeOption)
            {
                case ConstClass.ConstTypeItemOption.BedSize:
                    options = await GetItemBedSize(item, jwtModel).ToListAsync();
                    var x = options.ToList();
                    break;
                case ConstClass.ConstTypeItemOption.AvailableSizes:
                    options = await GetItemAvailableSizes(item, jwtModel);
                    break;
                case ConstClass.ConstTypeItemOption.SpecialOption:
                    //other option
                    options = await GetItemSpecialOptions(item, jwtModel).ToListAsync();
                    break;
                default: //All products have origin options
                    //finish option
                    options = await GetItemOptions(item, jwtModel).ToListAsync();
                    //var x = options.ToList();
                    break;
            }
            var optionGroups = new List<ItemOptionGroupViewModel>();
            try
            {
                optionGroups = options.GroupBy(o => o.OptionGroup).Select(o => new ItemOptionGroupViewModel
                {
                    OptionGroup = o.Key,
                    Options = o.GroupBy(p => new { p.Name, p.Filename, p.DimensionCm, p.Code }).Select(p => new ItemOptionsViewModel
                    {
                        Name = p.Key.Name,
                        SecondaryName = p.Key.DimensionCm,
                        ID = string.Join(",", p.OrderBy(x => x.SKU.Length).Select(q => q.ID.ToString()).ToArray()),
                        SKU = string.Join(",", p.OrderBy(x => x.SKU.Length).Select(q => q.SKU).ToArray()),
                        Selected = p.Any(q => q.Selected),
                        Filename = p.Key.Filename,
                        Code = p.Key.Code
                    }).OrderBy(e => e.Name)
                }).OrderBy(o => o.OptionGroup).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return optionGroups;
        }
        private ItemDto SetupPricesForDealer(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            Profile_ItemPrice wholesalePriceRecord = this.GetRecordDefaultWholesalePriceOfItem(jwtModel.Region, itemViewModel.SKU);
            Profile_ItemPrice defaultRetailPriceRecord = this.GetDefaultRetailPriceOfItem(itemViewModel.SKU);
            decimal wholesalePrice = wholesalePriceRecord.Price ?? 0;
            itemViewModel.WholesalePriceList.DealerPrice.Price = wholesalePrice > 0 ? wholesalePrice : 0;
            itemViewModel.WholesalePriceList.DealerPrice.Title = "Wholesale";

            if (wholesalePrice > 0)
            {
                decimal retailPrice = 0;
                var priceMultiplier = GetDealerPriceMultiplier((Guid)jwtModel.UserId);
                if (priceMultiplier > 0)
                {
                    retailPrice = wholesalePrice * (decimal)priceMultiplier;
                }
                else
                {
                    retailPrice = defaultRetailPriceRecord.Price ?? 0;
                    priceMultiplier = (double)retailPrice / (double)(wholesalePrice > 0 ? wholesalePrice : retailPrice);
                }

                itemViewModel.RetailPriceList.DealerPrice.Price = retailPrice > 0 ? retailPrice : 0;
                itemViewModel.RetailPriceList.DealerPrice.Title = "Store Price";


                if (itemViewModel.IsAXHCFPItem && jwtModel.Region == ConstClass.TARegions.TAUS)//Custom program only for US region
                {
                    itemViewModel.RetailPriceList.DealerPrice.Title = "Store Price";
                    itemViewModel.WholesalePriceList.DealerPrice.Title = "Wholesale Price";

                    itemViewModel.WholesalePriceList.AXHCustomFinishPrice.Price = wholesalePriceRecord.TotalCPPrice ?? 0;
                    itemViewModel.WholesalePriceList.AXHCustomFinishPrice.Title = "Total Wholesale Price With AXH Custom Finish";
                    itemViewModel.RetailPriceList.AXHCustomFinishPrice.Price = (wholesalePriceRecord.TotalCPPrice ?? 0) * (decimal)priceMultiplier;
                    itemViewModel.RetailPriceList.AXHCustomFinishPrice.Title = "Total Store Price With AXH Custom Finish";
                }
                else
                {
                    if (itemViewModel.IsCFPItem && jwtModel.Region == ConstClass.TARegions.TAUS)//Custom program only for US region
                    {
                        itemViewModel.RetailPriceList.DealerPrice.Title = "Store Price";
                        itemViewModel.WholesalePriceList.DealerPrice.Title = "Wholesale Price";

                        itemViewModel.WholesalePriceList.CustomPaletteFinishServicePrice.Price = wholesalePriceRecord.CPPrice ?? 0; ;
                        itemViewModel.WholesalePriceList.CustomPaletteFinishServicePrice.Title = "Wholesale Price Custom Palette Finishing Service Fee";
                        itemViewModel.RetailPriceList.CustomPaletteFinishServicePrice.Price = (wholesalePriceRecord.CPPrice ?? 0) * (decimal)priceMultiplier;
                        itemViewModel.RetailPriceList.CustomPaletteFinishServicePrice.Title = "Store Price Custom Palette Finishing Service Fee";
                    }
                }
            }
            return itemViewModel;
        }

        private ItemDto SetupPriceForSA(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            Profile_ItemPrice wholesalePriceRecord = this.GetRecordDefaultWholesalePriceOfItem(jwtModel.Region, itemViewModel.SKU);
            Profile_ItemPrice defaultRetailPriceRecord = this.GetDefaultRetailPriceOfItem(itemViewModel.SKU);
            decimal wholesalePrice = wholesalePriceRecord.Price ?? 0;

            if (wholesalePrice > 0)
            {
                decimal retailPrice = 0;
                var priceMultiplier = GetDealerPriceMultiplier((Guid)jwtModel.UserId);
                if (priceMultiplier > 0)
                {
                    retailPrice = wholesalePrice * (decimal)priceMultiplier;
                }
                else
                {
                    retailPrice = defaultRetailPriceRecord.Price ?? 0;
                    priceMultiplier = (double)retailPrice / (double)(wholesalePrice > 0 ? wholesalePrice : retailPrice);
                }

                itemViewModel.RetailPriceList.DealerPrice.Price = retailPrice > 0 ? retailPrice : 0;
                itemViewModel.RetailPriceList.DealerPrice.Title = "Store Price";

                if (itemViewModel.IsAXHCFPItem && jwtModel.Region == ConstClass.TARegions.TAUS)//Custom program only for US region
                {
                    itemViewModel.RetailPriceList.DealerPrice.Title = "Store Price";
                    itemViewModel.RetailPriceList.AXHCustomFinishPrice.Price = (wholesalePriceRecord.TotalCPPrice ?? 0) * (decimal)priceMultiplier;
                    itemViewModel.RetailPriceList.AXHCustomFinishPrice.Title = "Total Store Price With AXH Custom Finish";
                }
                else
                {
                    if (itemViewModel.IsCFPItem && jwtModel.Region == ConstClass.TARegions.TAUS)//Custom program only for US region
                    {
                        itemViewModel.RetailPriceList.DealerPrice.Title = "Store Price";
                        itemViewModel.RetailPriceList.CustomPaletteFinishServicePrice.Price = (wholesalePriceRecord.CPPrice ?? 0) * (decimal)priceMultiplier;
                        itemViewModel.RetailPriceList.CustomPaletteFinishServicePrice.Title = "Store Price Custom Palette Finishing Service Fee";
                    }
                }
            }
            return itemViewModel;
        }

        private ItemDto SetupPricesForDesigner(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            //try to get wholesale price for designer
            Profile_ItemPrice defaultWholesalePriceRecord = this.GetRecordDefaultWholesalePriceOfItem(jwtModel.Region, itemViewModel.SKU);
            decimal defaultWholesalePrice = defaultWholesalePriceRecord.Price ?? 0;
            Profile_ItemPrice designerWholesalePriceRecord = this.GetRecordWholesalePriceOfItemForDesigner(jwtModel.UserId.Value, itemViewModel.SKU);
            decimal designerWholesalePrice = designerWholesalePrice = designerWholesalePriceRecord.Price ?? 0;

            //set wholesale price for designer
            itemViewModel.WholesalePriceList.DesignerPrice.Price = designerWholesalePrice > 0 ? designerWholesalePrice : 0;
            itemViewModel.WholesalePriceList.DesignerPrice.Title = "Designer Price";

            //try to set retail price
            if (designerWholesalePrice > 0 && defaultWholesalePrice > 0)
            {
                //try to get retail multiplier
                var designerUS = _userService.GetDesignerUS().Where(o => o.UserID == jwtModel.UserId).FirstOrDefault();
                decimal retailPrice = 0;
                var priceMultiplier = designerUS.RetailMultiplier;
                if (priceMultiplier > 0)
                {
                    retailPrice = defaultWholesalePrice * (decimal)priceMultiplier;
                }
                else
                {
                    Profile_ItemPrice defaultRetailPriceRecord = this.GetDefaultRetailPriceOfItem(itemViewModel.SKU);
                    retailPrice = defaultRetailPriceRecord.Price ?? 0;
                    priceMultiplier = (double)retailPrice / (double)(defaultWholesalePrice);
                }
                //set retail price for designer
                itemViewModel.RetailPriceList.DesignerPrice.Price = retailPrice > 0 ? retailPrice : 0;
                itemViewModel.RetailPriceList.DesignerPrice.Title = "Store Price";

                if (itemViewModel.IsAXHCFPItem && jwtModel.Region == ConstClass.TARegions.TAUS)//Custom program only for US region
                {
                    itemViewModel.RetailPriceList.DesignerPrice.Title = "Store Price";
                    itemViewModel.WholesalePriceList.DesignerPrice.Title = "Designer Price";

                    itemViewModel.WholesalePriceList.AXHCustomFinishPrice.Price = designerWholesalePriceRecord.TotalCPPrice ?? 0;
                    itemViewModel.WholesalePriceList.AXHCustomFinishPrice.Title = "Total Designer Price With AXH Custom Finish";
                    itemViewModel.RetailPriceList.AXHCustomFinishPrice.Price = (defaultWholesalePriceRecord.TotalCPPrice ?? 0) * (decimal)priceMultiplier;
                    itemViewModel.RetailPriceList.AXHCustomFinishPrice.Title = "Total Retail Price With AXH Custom Finish";
                }
                else
                {
                    if (itemViewModel.IsCFPItem && jwtModel.Region == ConstClass.TARegions.TAUS)//Custom program only for US region
                    {
                        itemViewModel.RetailPriceList.DesignerPrice.Title = "Store Price";
                        itemViewModel.WholesalePriceList.DesignerPrice.Title = "Designer Price";

                        itemViewModel.WholesalePriceList.CustomPaletteFinishServicePrice.Price = designerWholesalePriceRecord.CPPrice ?? 0;
                        itemViewModel.WholesalePriceList.CustomPaletteFinishServicePrice.Title = "Wholesale Designer Custom Pallete Service Fee";
                        itemViewModel.RetailPriceList.CustomPaletteFinishServicePrice.Price = (defaultWholesalePriceRecord.CPPrice ?? 0) * (decimal)priceMultiplier;
                        itemViewModel.RetailPriceList.CustomPaletteFinishServicePrice.Title = "Store Custom Pallete Service Fee";
                    }
                }
            }
            return itemViewModel;

        }

        private double GetDealerPriceMultiplier(Guid UserId)
        {
            double multiplier = 3;//3 is default
            var storeIds = _dealerServices.GetUserStoreID(UserId).ToList();
            if (storeIds.Count > 0)
            {
                Guid firstStoreId = storeIds.First().ID;
                var store = _storeServices.GetStorebyId(firstStoreId).SingleOrDefault();
                if (store != null)
                {
                    multiplier = store.PriceMultiplier > 0 ? store.PriceMultiplier : multiplier;
                }
            }
            return multiplier;
        }

        public async Task<IList<ColourAndFinishViewModel>> GetColourAndFinishes()
        {
            try
            {
                var result = await _colourAndFinishEntityService.Get().Select(o => new ColourAndFinishViewModel
                {
                    ID = o.ID,
                    Name = o.Name
                }).OrderBy(o => o.Name).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Profile_ItemPrice GetRecordWholesalePriceOfItemForDesigner(Guid userId, string itemSKU)
        {
            var designerUS = _userService.GetDesignerUS().Where(o => o.UserID == userId).FirstOrDefault();
            Profile_ItemPrice wholesaleDesignerPriceRecord = new Profile_ItemPrice();
            if (designerUS != null)
            {
                wholesaleDesignerPriceRecord = _profile_ItemPriceEntityService.Get().Where(o => o.ProfileType == designerUS.DesignerType && o.SKU == itemSKU).FirstOrDefault();
            }
            wholesaleDesignerPriceRecord = wholesaleDesignerPriceRecord ?? new Profile_ItemPrice();
            return wholesaleDesignerPriceRecord;
        }

        private Profile_ItemPrice GetRecordDefaultWholesalePriceOfItem(string userRegion, string itemSKU)
        {
            Profile_ItemPrice wholesalePrice = new Profile_ItemPrice();
            if (userRegion == ConstClass.TARegions.INTL)
            {
                wholesalePrice = _profile_ItemPriceEntityService.Get().Where(o => o.ProfileType == "INTL/WHS" && o.SKU == itemSKU).FirstOrDefault();
            }
            if (userRegion == ConstClass.TARegions.TAUS)
            {
                wholesalePrice = _profile_ItemPriceEntityService.Get().Where(o => o.ProfileType == "TAUS/WHS" && o.SKU == itemSKU).FirstOrDefault();
            }
            wholesalePrice = wholesalePrice ?? new Profile_ItemPrice();
            return wholesalePrice;
        }

        private Profile_ItemPrice GetDefaultRetailPriceOfItem(string itemSKU)
        {
            Profile_ItemPrice retailPrice = new Profile_ItemPrice();
            retailPrice = _profile_ItemPriceEntityService.Get().Where(o => o.ProfileType == "TAUS/RT" && o.SKU == itemSKU).FirstOrDefault();
            return retailPrice;
        }

        public async Task<ItemDto> GetItemData(JWTIdentityViewModel jwtModel, string itemSku, Guid? itemId, string URLCode)
        {
            try
            {
                IQueryable<Item> items = _itemModelServices.Get();
                var item = await items.FirstOrDefaultAsync(o => (itemId.HasValue && o.ID == itemId) || (!String.IsNullOrEmpty(itemSku) && o.SKU == itemSku) || (!String.IsNullOrEmpty(URLCode) && o.URLCode == URLCode));
                if (item != null)
                {
                    //check if the item is available
                    ItemDto itemViewModel = new ItemDto(item);
                    if (jwtModel != null)
                    {
                        itemViewModel.IsInWishList = IsInWishlist(item.SKU, jwtModel);
                        itemViewModel.IsAvailable = IsAvailableItem(jwtModel, itemViewModel.ID);
                    }
                    return itemViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemDto> GetItemDataByID(JWTIdentityViewModel jwtModel, Guid? itemId)
        {
            try
            {
                IQueryable<Item> items = _itemModelServices.Get();
                var item = await items.FirstOrDefaultAsync(o => (itemId.HasValue && o.ID == itemId));
                if (item != null)
                {
                    //check if the item is available
                    ItemDto itemViewModel = new ItemDto(item);
                    if (jwtModel != null)
                    {
                        itemViewModel.IsInWishList = IsInWishlist(item.SKU, jwtModel);
                        itemViewModel.IsAvailable = IsAvailableItem(jwtModel, itemViewModel.ID);
                    }
                    return itemViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemDto> GetItemDataBySKU(JWTIdentityViewModel jwtModel, string itemSku)
        {
            try
            {
                IQueryable<Item> items = _itemModelServices.Get();
                var item = await items.FirstOrDefaultAsync(o => (!String.IsNullOrEmpty(itemSku) && o.SKU == itemSku));
                if (item != null)
                {
                    //check if the item is available
                    ItemDto itemViewModel = new ItemDto(item);
                    if (jwtModel != null)
                    {
                        itemViewModel.IsInWishList = IsInWishlist(item.SKU, jwtModel);
                        itemViewModel.IsAvailable = IsAvailableItem(jwtModel, itemViewModel.ID);
                    }
                    return itemViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemDto> GetItemDataByURLCode(JWTIdentityViewModel jwtModel, string URLCode)
        {
            try
            {
                IQueryable<Item> items = _itemModelServices.Get();
                var item = await items.FirstOrDefaultAsync(o => (!String.IsNullOrEmpty(URLCode) && o.URLCode == URLCode));
                if (item != null)
                {
                    //check if the item is available
                    ItemDto itemViewModel = new ItemDto(item);
                    if (jwtModel != null)
                    {
                        itemViewModel.IsInWishList = IsInWishlist(item.SKU, jwtModel);
                        itemViewModel.IsAvailable = IsAvailableItem(jwtModel, itemViewModel.ID);
                    }
                    return itemViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Public method
        public bool IsInWishlist(string productSku, JWTIdentityViewModel jwtModel)
        {
            return _wishListModelServices.IsItemInWishlist(productSku, jwtModel);
        }

        public bool IsInStockProgram(Item item)
        {
            return IsInStockProgram(item);
        }

        public void SetupRelatedItems(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            IQueryable<Item> availableItems = this.GetAvailableItems(jwtModel);

            //Does not count related by default SKU
            //IQueryable<RelatedItemViewModel> relatedItemsBySKU = availableItems.Where(i =>
            //((itemViewModel.SKU != itemViewModel.DefaultCode) && i.SKU == itemViewModel.DefaultCode)
            //||
            //((itemViewModel.SKU == itemViewModel.DefaultCode) && i.SKU == itemViewModel.SKU)).Select(o => new RelatedItemViewModel
            //{
            //    ID = o.ID,
            //    ProductName = o.ProductName,
            //    SKU = o.SKU,
            //    DefaultCode = o.DefaultCode,
            //    Order = 1
            //});
            //var x = relatedItemsBySKU.ToList();

            var relatedItemsQuery = itemViewModel.entity.Item1.Select(o => new RelatedItemViewModel
            {
                ID = o.ID,
                ProductName = o.ProductName,
                SKU = o.SKU,
                DefaultCode = o.DefaultCode,
                Order = 1
            }).Distinct()
            //exclude the in active item
            .Where(o => availableItems.Any(s => s.SKU == o.SKU));
            //var f = relatedItemsQuery.ToList();

            IQueryable<Item> matchingArmOrSideItems = availableItems.Where(i => itemViewModel.entity.MatchingArmOrSide.HasValue && i.ID == itemViewModel.entity.MatchingArmOrSide);
            var y = matchingArmOrSideItems.ToList();
            var MatchingArmOrSideQuery = matchingArmOrSideItems.Select(o => new RelatedItemViewModel
            {
                ID = o.ID,
                ProductName = o.ProductName,
                SKU = o.SKU,
                DefaultCode = o.DefaultCode,
                Order = 0
            });
            //var t = MatchingArmOrSideQuery.ToList();

            List<RelatedItemViewModel> items = new List<RelatedItemViewModel>();
            //items.AddRange(relatedItemsBySKU);
            items.AddRange(relatedItemsQuery);
            items.AddRange(MatchingArmOrSideQuery);
            //var z = items.ToList();

            foreach (var item in items)
            {
                item.IsInWishList = IsInWishlist(item.SKU, jwtModel);
            }

            itemViewModel.RelatedItems = items;
        }

        public async Task<ItemDto> SetupDownloadInfoAndFlagAsync(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            List<ItemDownloadInfo> CatalogsDownload = new List<ItemDownloadInfo>();

            //check DPF tagging
            List<ItemDto> tempList = new List<ItemDto> { itemViewModel };
            List<ItemResourceFile> files = this._itemResourceFileModelService.Get().Where(fr => fr.IsEnabled == true).ToList();
            foreach (var f in files)
            {

                List<ItemResourceFile_Rule> rules = f.ItemResourceFile_Rule.Where(r => r.IsEnabled == true).ToList();
                foreach (var rule in rules)
                {
                    if (String.IsNullOrEmpty(rule.Region) || rule.Region == jwtModel.Region)
                    {
                        QueryBuilderFilterRule ruleQuery = TAQueryBuilderFilterRule.ConvertToQueryBuilderFilterRuleFromJsonRule(rule.Rule);
                        if (tempList.BuildQuery(ruleQuery).ToList().Count > 0)
                        {
                            //PDF
                            if (!String.IsNullOrEmpty(f.URL))
                            {
                                string title = !String.IsNullOrEmpty(rule.Title) ? rule.Title : !String.IsNullOrEmpty(f.Title) ? f.Title : f.Name;
                                CatalogsDownload.Add(Helper.CreateDownloadFile(f.URL, title));
                            }
                            //Tagging
                            if (!String.IsNullOrEmpty(f.Property))
                            {
                                try
                                {
                                    itemViewModel.Tags.Add(f.Property, true);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                    }
                }
            }

            //Tearsheet -- https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Tearsheet/U3025-25.pdf
            string tearSheetUrl = String.Format("{0}/website/Frontend/Live/assests/pdf/Tearsheet/{1}.pdf", ConfigurationManager.AppSettings["SirvTAUrl"], itemViewModel.SKU);

            var tearsheetExist = Helper.CheckFilesExistsAsync(tearSheetUrl);

            if (await tearsheetExist)
            {
                CatalogsDownload.Add(Helper.CreateDownloadFile(tearSheetUrl, "Tear Sheet"));
            }


            if (CatalogsDownload.Count() > 0)
            {
                Downloads downloads = new Downloads
                {
                    Name = "Catalogs",
                    ItemDownloadInfos = CatalogsDownload.OrderBy(e => e.FileName).ToList()
                };
                itemViewModel.Downloads.Add(downloads);
            }
            return itemViewModel;
        }

        public async Task<ItemDto> SetupItemOption(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            //=== Origin option
            itemViewModel.ListOption = await GetItemOptions(jwtModel, itemViewModel.entity, ConstClass.ConstTypeItemOption.Origin);//Finish Option
            itemViewModel.ListBedSizeOption = await GetItemOptions(jwtModel, itemViewModel.entity, ConstClass.ConstTypeItemOption.BedSize);//=== Bed option
            itemViewModel.ListAvailableSizesOption = await GetItemOptions(jwtModel, itemViewModel.entity, ConstClass.ConstTypeItemOption.AvailableSizes);//=== Has Available size?
            //=== Get Special Option (This is items in same special group)
            itemViewModel.ListSpecialOption = await GetItemOptions(jwtModel, itemViewModel.entity, ConstClass.ConstTypeItemOption.SpecialOption);//Other Option

            //if (itemViewModel.Type_ID.ToString().ToUpper() == ConstClass.ConstType.BEDTYPE)
            //{
            //    itemViewModel.ListBedSizeOption = await GetItemOptions(jwtModel, item, ConstClass.ConstTypeItemOption.BedSize);
            //}
            //else //=== Has Available size?
            //{
            //    itemViewModel.ListAvailableSizesOption = await GetItemOptions(jwtModel, item, ConstClass.ConstTypeItemOption.AvailableSizes);
            //}
            return itemViewModel;
        }

        public ItemDto SetupPrices(ItemDto itemViewModel, JWTIdentityViewModel jwtModel)
        {
            if (IsAllowedToShowPrice(itemViewModel.entity, jwtModel.Region))
            {
                switch (jwtModel.UserType)
                {
                    case LocalUserType.Dealer:
                        if (itemViewModel.IsAvailable)
                        {
                            itemViewModel = SetupPricesForDealer(itemViewModel, jwtModel);
                        }
                        break;
                    case LocalUserType.SalesAssociate:
                        if (itemViewModel.IsAvailable)
                        {
                            itemViewModel = SetupPriceForSA(itemViewModel, jwtModel);
                        }
                        break;
                    case LocalUserType.Designer:
                        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EnableDesignerPrice"]))
                        {
                            if (ConfigurationManager.AppSettings["EnableDesignerPrice"] == "1")
                            {
                                //itemViewModel.CanBuy = true;//not enable yet
                                itemViewModel = SetupPricesForDesigner(itemViewModel, jwtModel);
                            }
                        }
                        break;
                    default:
                        //ShowMSRP(itemViewModel, jwtModel);
                        break;
                }
            }
            return itemViewModel;
        }

        #endregion

        public void ConvertNamesToIdsIfNeeded(OriginRequestObj requestObj)
        {
            string brandIds = String.Join(",", _brandModelService.GetIdsFromNames(requestObj.BrandIds));
            requestObj.BrandIds = String.IsNullOrEmpty(brandIds) ? requestObj.BrandIds : brandIds;

            string collectionIds = String.Join(",", _collectionModelService.GetIdsFromNames(requestObj.CollectionIds));
            requestObj.CollectionIds = String.IsNullOrEmpty(collectionIds) ? requestObj.CollectionIds : collectionIds;

            string roomIds = String.Join(",", _roomModelService.GetIdsFromNames(requestObj.RoomIds));
            requestObj.RoomIds = String.IsNullOrEmpty(roomIds) ? requestObj.RoomIds : roomIds;

            string typeIds = String.Join(",", _typeModelService.GetIdsFromNames(requestObj.TypeIds));
            requestObj.TypeIds = String.IsNullOrEmpty(typeIds) ? requestObj.TypeIds : typeIds;

            string lifeStyleIds = String.Join(",", _lifeStyleModelService.GetIdsFromNames(requestObj.LifeStyleIds));
            requestObj.LifeStyleIds = String.IsNullOrEmpty(lifeStyleIds) ? requestObj.LifeStyleIds : lifeStyleIds;

            string styleIds = String.Join(",", _styleModelService.GetIdsFromNames(requestObj.StyleIds));
            requestObj.StyleIds = String.IsNullOrEmpty(styleIds) ? requestObj.StyleIds : styleIds;

            string designerIds = String.Join(",", _designerModelService.GetIdsFromNames(requestObj.DesignerIds));
            requestObj.DesignerIds = String.IsNullOrEmpty(designerIds) ? requestObj.DesignerIds : designerIds;

            string shapeIds = String.Join(",", _shapeModelService.GetIdsFromNames(requestObj.ShapeIds));
            requestObj.ShapeIds = String.IsNullOrEmpty(shapeIds) ? requestObj.ShapeIds : shapeIds;

            string colourAndFinishIds = String.Join(",", _colourAndFinishEntityService.GetIdsFromNames(requestObj.ColourAndFinishIds));
            requestObj.ColourAndFinishIds = String.IsNullOrEmpty(colourAndFinishIds) ? requestObj.ColourAndFinishIds : colourAndFinishIds;

            string optionGroupIds = String.Join(",", _optionGroupModelService.GetIdsFromNames(requestObj.OptionGroupIds));
            requestObj.OptionGroupIds = String.IsNullOrEmpty(optionGroupIds) ? requestObj.OptionGroupIds : optionGroupIds;
        }
        public IQueryable<Item> FilterForItems(RequestItemObj requestObj, JWTIdentityViewModel jwtModel)
        {
            try
            {
                IQueryable<Item> items = GetAvailableItems(jwtModel);
                //var x = items.Count();
                //Query Item with more included condition
                items = items.Where(o => (!requestObj.DefaultItemOnly || o.DefaultCode == null || o.DefaultCode.Trim() == "" || o.DefaultCode.ToLower().Trim() == o.SKU.ToLower().Trim()));
                //items = items.Where(o => (!requestObj.DefaultItemOnly));
                //var y = items.Count();
                //Groupping items
                items = GroupingItems(requestObj, items, jwtModel);
                //var z = items.Count();
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Item> GroupingItems(RequestItemObj requestObj, IQueryable<Item> items, JWTIdentityViewModel jwtModel)
        {
            List<Guid?> lstGuid;
            List<string> lstStr;
            if (!String.IsNullOrEmpty(requestObj.SearchKey) && !String.IsNullOrEmpty(requestObj.SearchKey.Trim()))
            {
                items = ItemFullTextSearch(items, requestObj.SearchKey.Trim());
            }
            if (!String.IsNullOrEmpty(requestObj.BrandIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.BrandIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByCollections(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.CollectionIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.CollectionIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByCollections(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.RoomIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.RoomIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByRooms(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.TypeIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.TypeIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByTypes(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.LifeStyleIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.LifeStyleIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByLifeStyles(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.StyleIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.StyleIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByStyles(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.DesignerIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.DesignerIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByDesigners(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.ShapeIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.ShapeIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByShapes(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.ColourAndFinishIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.ColourAndFinishIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByColourAndFinish(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.OptionGroupIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.OptionGroupIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByOptionGroups(items, lstGuid);
            }
            if (requestObj.IsCustomPalette)
            {
                items = items.Where(item => item.IsCFPItem ?? false);
            }
            if (requestObj.IsStockProgram && jwtModel.Region == ConstClass.TARegions.INTL)//only apply for INTL user
            {
                items = items.Where(item => item.InStockProgram.HasValue && item.InStockProgram.Value == true);
            }
            if (requestObj.IsStocked && jwtModel.Region == ConstClass.TARegions.TAUS)
            {////only apply for US user
                items = items.Where(i => i.IsStocked.HasValue && i.IsStocked.Value == true);
            }
            items = items.Where(o => !requestObj.Extending || o.Extending == true);
            items = items.Where(o => !requestObj.IsBestSeller || o.IsBestSeller == true);

            if (requestObj.DimensionRange != null)
            {
                if (requestObj.DimensionRange.WidthMax != 0 || requestObj.DimensionRange.WidthMin != 0)
                {
                    if (requestObj.DimensionRange.IsInch)
                    {
                        requestObj.DimensionRange.WidthMax = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.WidthMax) * 2.54);
                        requestObj.DimensionRange.WidthMin = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.WidthMin) * 2.54);
                    }
                    items = GetItemBetweenWidth(items, requestObj.DimensionRange.WidthMax, requestObj.DimensionRange.WidthMin);
                }
                if (requestObj.DimensionRange.HeightMax != 0 || requestObj.DimensionRange.HeightMin != 0)
                {
                    if (requestObj.DimensionRange.IsInch)
                    {
                        requestObj.DimensionRange.HeightMax = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.HeightMax) * 2.54);
                        requestObj.DimensionRange.HeightMin = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.HeightMin) * 2.54);
                    }
                    items = GetItemBetweenHeight(items, requestObj.DimensionRange.HeightMax, requestObj.DimensionRange.HeightMin);
                }
                if (requestObj.DimensionRange.DepthMax != 0 || requestObj.DimensionRange.DepthMax != 0)
                {
                    if (requestObj.DimensionRange.IsInch)
                    {
                        requestObj.DimensionRange.DepthMax = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.DepthMax) * 2.54);
                        requestObj.DimensionRange.DepthMin = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.DepthMin) * 2.54);
                    }
                    items = GetItemBetweenDepth(items, requestObj.DimensionRange.DepthMax, requestObj.DimensionRange.DepthMin);
                }
            }
            return items;
        }

        public List<CountViewModel> SidebarBrandItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.Brand_ID != null).GroupBy(g => g.Brand_ID).Select(c => new CountViewModel
                {
                    ID = c.Key.ToString(),
                    Name = "Brand",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarCollectionItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.Collection_ID != null).GroupBy(g => g.Collection_ID).Select(c => new CountViewModel
                {
                    ID = c.Key.ToString(),
                    Name = "Collection",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarRoomItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.RoomAndUsage_ID != null).GroupBy(g => g.RoomAndUsage_ID).Select(c => new CountViewModel
                {
                    ID = c.Key.ToString(),
                    Name = "Room",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarTypeItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.Type_ID != null).GroupBy(g => g.Type_ID).Select(c => new CountViewModel
                {
                    ID = c.Key.ToString(),
                    Name = "Type",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarLifeStyleItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.LifeStyle_ID != null).GroupBy(g => g.LifeStyle_ID).Select(c => new CountViewModel
                {
                    ID = c.Key.ToString(),
                    Name = "LifeStyle",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarStyleItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.Style_ID != null).GroupBy(g => g.Style_ID).Select(c => new CountViewModel
                {
                    ID = c.Key.ToString(),
                    Name = "Style",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarShapeItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = _shapeModelService.Get().Select(g => new CountViewModel { ID = g.ID.ToString(), Name = "Shape", Count = g.Items.Where(s => items.Any(i => i.ID == s.ID)).Count() }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarColourAndFinishItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = _colourAndFinishEntityService.Get().Select(g => new CountViewModel { ID = g.ID.ToString(), Name = "ColourAndFinish", Count = g.Items.Where(s => items.Any(i => i.ID == s.ID)).Count() }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CountViewModel> SidebarExtendingItemsCount(IQueryable<Item> items)
        {
            try
            {
                var result = items.Where(o => o.Extending == true).GroupBy(g => g.Extending).Select(c => new CountViewModel
                {
                    ID = "TaExtending",
                    Name = "Extending",
                    Count = c.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IQueryable<Item> GroupingItemsCountForSidebarFilter(CountItemObj requestObj, IQueryable<Item> items, JWTIdentityViewModel jwtModel)
        {
            List<Guid?> lstGuid;
            List<string> lstStr;
            if (requestObj.IsCustomPalette)
            {
                items = items.Where(i => i.IsCFPItem ?? false);
            }
            if (requestObj.IsStockProgram && jwtModel.Region == ConstClass.TARegions.INTL)//only apply for INTL user
            {
                items = items.Where(o => o.InStockProgram.HasValue && o.InStockProgram.Value == true);
            }
            if (requestObj.IsStocked && jwtModel.Region == ConstClass.TARegions.TAUS)
            {//only apply for US user
                items = items.Where(i => i.IsStocked.HasValue && i.IsStocked.Value == true);
            }
            if (!String.IsNullOrEmpty(requestObj.SearchKey))
            {
                items = ItemFullTextSearch(items, requestObj.SearchKey);
            }
            if (!String.IsNullOrEmpty(requestObj.BrandIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.BrandIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByCollections(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.CollectionIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.CollectionIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByCollections(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.ColourAndFinishIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.ColourAndFinishIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByColourAndFinish(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.RoomIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.RoomIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByRooms(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.TypeIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.TypeIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByTypes(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.LifeStyleIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.LifeStyleIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByLifeStyles(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.StyleIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.StyleIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByStyles(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.DesignerIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.DesignerIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByDesigners(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.ShapeIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.ShapeIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByShapes(items, lstGuid);
            }
            if (!String.IsNullOrEmpty(requestObj.OptionGroupIds))
            {
                lstStr = BL.Helper.ConvertStringToList(requestObj.OptionGroupIds);
                lstGuid = BL.Helper.ConvertListStringToListGuid(lstStr);
                items = GetItemsByOptionGroups(items, lstGuid);
            }
            if (requestObj.Extending)
            {
                items = items.Where(o => o.Extending == requestObj.Extending);
            }

            if (requestObj.DimensionRange != null)
            {
                if (requestObj.DimensionRange.WidthMax != 0 || requestObj.DimensionRange.WidthMin != 0)
                {
                    if (requestObj.DimensionRange.IsInch)
                    {
                        requestObj.DimensionRange.WidthMax = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.WidthMax) * 2.54);
                        requestObj.DimensionRange.WidthMin = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.WidthMin) * 2.54);
                    }
                    items = GetItemBetweenWidth(items, requestObj.DimensionRange.WidthMax, requestObj.DimensionRange.WidthMin);
                }
                if (requestObj.DimensionRange.HeightMax != 0 || requestObj.DimensionRange.HeightMin != 0)
                {
                    if (requestObj.DimensionRange.IsInch)
                    {
                        requestObj.DimensionRange.HeightMax = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.HeightMax) * 2.54);
                        requestObj.DimensionRange.HeightMin = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.HeightMin) * 2.54);
                    }
                    items = GetItemBetweenHeight(items, requestObj.DimensionRange.HeightMax, requestObj.DimensionRange.HeightMin);
                }
                if (requestObj.DimensionRange.DepthMax != 0 || requestObj.DimensionRange.DepthMax != 0)
                {
                    if (requestObj.DimensionRange.IsInch)
                    {
                        requestObj.DimensionRange.DepthMax = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.DepthMax) * 2.54);
                        requestObj.DimensionRange.DepthMin = Convert.ToDecimal(Convert.ToDouble(requestObj.DimensionRange.DepthMin) * 2.54);
                    }
                    items = GetItemBetweenDepth(items, requestObj.DimensionRange.DepthMax, requestObj.DimensionRange.DepthMin);
                }
            }
            return items;
        }

        public List<ItemDto> FilterItemByRule(QueryBuilderFilterRule rule)
        {
            try
            {
                var items = GetActiveItems();
                var itemsDTO = items.Select(ItemDto.FromEntityConverterForQueryBuilder);
                var ret = itemsDTO.BuildQuery(rule).ToList();
                ret = ret.Select(i => ItemDto.BuildNonEntityFields(i)).ToList();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAvailableItem(JWTIdentityViewModel jwtModel, string sku)
        {
            IQueryable<Item> availableItems = GetAvailableItems(jwtModel);
            bool isAvailable = availableItems.Any(i => !String.IsNullOrEmpty(sku) && sku.ToUpper() == i.SKU.ToUpper());
            return isAvailable;
        }
        public bool IsAvailableItem(JWTIdentityViewModel jwtModel, Guid Id)
        {
            IQueryable<Item> availableItems = GetAvailableItems(jwtModel);
            bool isAvailable = availableItems.Any(i => Id == i.ID);
            return isAvailable;
        }

        public IQueryable<Item> GetItemsByCollections(IQueryable<Item> items, List<Guid?> lstCollection)
        {
            return items.Where(o => lstCollection.Any(c => c == o.Collection_ID));
        }

        public IQueryable<Item> GetItemsByRooms(IQueryable<Item> items, List<Guid?> lstRooms)
        {
            return items.Where(o => lstRooms.Any(c => c == o.RoomAndUsage_ID));
        }

        public IQueryable<Item> GetItemsByTypes(IQueryable<Item> items, List<Guid?> lstType)
        {
            return items.Where(o => lstType.Any(c => c == o.Type_ID));
        }

        public IQueryable<Item> GetItemsByLifeStyles(IQueryable<Item> items, List<Guid?> lstLifeStyle)
        {
            return items.Where(o => lstLifeStyle.Any(c => c == o.LifeStyle_ID));
        }

        public IQueryable<Item> GetItemsByStyles(IQueryable<Item> items, List<Guid?> lstStyle)
        {
            return items.Where(o => lstStyle.Any(c => c == o.Style_ID));
        }

        public IQueryable<Item> GetItemsByShapes(IQueryable<Item> items, List<Guid?> lstShape)
        {
            return items.Where(o => o.Shapes.Any(s => lstShape.Any(c => c == s.ID)));
        }

        public IQueryable<Item> GetItemsByDesigners(IQueryable<Item> items, List<Guid?> lstDesigner)
        {
            return items.Where(o => lstDesigner.Any(c => c == o.Designer_ID));
        }
        public IQueryable<Item> GetItemsByOptionGroups(IQueryable<Item> items, List<Guid?> lstOptionGroup)
        {
            return items.Where(o => lstOptionGroup.Any(c => c == o.OptionGroup_ID || c == o.OptionGroup2_ID || c == o.OptionGroup3_ID));
        }

        public bool IsAllowedToShowPrice(Item item, string region)
        {
            bool isShowPrice = true;
            Item_Price itemPrice = _itemPriceEntityService.Get().Where(p => p.SKU == item.SKU && region == p.Region && p.Price == -999).FirstOrDefault();
            if (itemPrice != null)
            {
                isShowPrice = false;
            }
            return isShowPrice;
        }

        public IQueryable<Item> GetAvailableItems(JWTIdentityViewModel jwtModel = null)
        {
            IQueryable<Item> items = _itemModelServices.Get();
            if (jwtModel != null)
            {
                if (!String.IsNullOrEmpty(jwtModel.Region))
                {
                    //exclude items is prohibited for region
                    var activeItems = _itemStatusEntityService.Get().Where(st => st.Region == jwtModel.Region && st.IsActive == true);
                    items = items.Where(i => activeItems.Any(st => st.SKU == i.SKU));
                }

                //if (jwtModel.CountryId.HasValue)
                //{
                //    //exclude items is prohibited for country
                //    var countryBlockedItems = GetItemBlackOut(jwtModel.CountryId);
                //    items = items.Where(i => !countryBlockedItems.Any(b => b.ID == i.ID));
                //}

                //exclude items is prohibited for group of dealer/SA
                //only apply for INTL Dealer/SA
                if ((jwtModel.UserType == LocalUserType.Dealer || jwtModel.UserType == LocalUserType.SalesAssociate) && jwtModel.ExclusivityGroupId.HasValue && jwtModel.Region == ConstClass.TARegions.INTL)
                {
                    var prohibitedItemsByDealer = GetLimitedItem(jwtModel.ExclusivityGroupId);
                    items = items.Where(i => !(prohibitedItemsByDealer.Any(e => e.ID == i.ID)));
                }
            }
            return items;
        }

        public bool SetItemActiveStatus(string sku, bool? isActiveTAUS, bool? isActiveINTL)
        {
            bool ret = true;
            //check if it is valid sku
            Item item = _itemModelServices.Get(sku).FirstOrDefault();
            if (item != null)
            {

                List<Item_Status> statuses = _itemStatusEntityService.Get(sku).ToList();

                //TAUS status
                if (isActiveTAUS.HasValue)
                {
                    Item_Status tausStatus = statuses.Where(s => s.Region == "taus").FirstOrDefault();
                    if (tausStatus != null)
                    {
                        tausStatus.IsActive = isActiveTAUS.Value;
                        ret = ret && _itemStatusEntityService.Update(tausStatus);
                    }
                    else
                    {
                        tausStatus = new Item_Status();
                        tausStatus.SKU = sku; tausStatus.IsActive = isActiveTAUS.Value; tausStatus.Region = "taus";
                        ret = ret && _itemStatusEntityService.Add(tausStatus);
                    }
                }

                //INTL status
                if (isActiveINTL.HasValue)
                {
                    Item_Status intlStatus = statuses.Where(s => s.Region == "international").FirstOrDefault();
                    if (intlStatus != null)
                    {
                        intlStatus.IsActive = isActiveINTL.Value;
                        ret = ret && _itemStatusEntityService.Update(intlStatus);
                    }
                    else
                    {
                        intlStatus = new Item_Status();
                        intlStatus.SKU = sku; intlStatus.IsActive = isActiveINTL.Value; intlStatus.Region = "international";
                        ret = ret && _itemStatusEntityService.Add(intlStatus);
                    }
                }
            }
            return ret;
        }
        public IQueryable<Item> GetActiveItems()
        {
            IQueryable<Item> items = _itemModelServices.Get();
            {
                var activeItems = _itemStatusEntityService.Get().Where(st => st.IsActive == true);
                items = items.Where(i => activeItems.Any(st => st.SKU == i.SKU));
            }
            return items;
        }

        public IQueryable<Item> ItemFullTextSearch(IQueryable<Item> items, string keywords)
        {
            if (!String.IsNullOrEmpty(keywords) && !String.IsNullOrEmpty(keywords.Trim()))
            {
                var fullTextSearch = _udf_FreeTextSearchEntityService.Search(keywords.Trim());

                //Join regular
                items = from item in items
                        join search in fullTextSearch on item.ID equals search.ID
                        select item;
            }
            return items;
        }

        public IQueryable<Item> GetLimitedItem(Guid? exclusivityGroupId)
        {
            return _itemModelServices.Get().Where(o => o.ExclusivityGroups.Any(c => c.ID == exclusivityGroupId));
        }

        public IQueryable<Item> GetItemBetweenWidth(IQueryable<Item> items, decimal? maxWidth, decimal? minWidth)
        {
            return items = items.Where(o => (maxWidth == null || o.Width <= maxWidth) && (minWidth == null || o.Width >= minWidth));
        }

        public IQueryable<Item> GetItemBetweenHeight(IQueryable<Item> items, decimal? maxHeight, decimal? minHeight)
        {
            return items = items.Where(o => (maxHeight == null || o.Height <= maxHeight) && (minHeight == null || o.Height >= minHeight));
        }

        public IQueryable<Item> GetItemBetweenDepth(IQueryable<Item> items, decimal? maxDepth, decimal? minDepth)
        {
            return items = items.Where(o => (maxDepth == null || o.Depth <= maxDepth) && (minDepth == null || o.Depth >= minDepth));
        }

        public IQueryable<Item> GetItemsByColourAndFinish(IQueryable<Item> items, List<Guid?> lstColourAndFinish)
        {
            return items.Where(o => o.ColourAndFinishes.Any(s => lstColourAndFinish.Any(c => c == s.ID)));
        }

        public IQueryable<ItemOptionsQueryableModel> GetItemSpecialOptions(Item item, JWTIdentityViewModel jwtModel)
        {
            IQueryable<Item> items = GetAvailableItems(jwtModel);
            IQueryable<RelatedSkuForSpecialGroup> RelatedSkuForSpecialGroups = _relatedSkuForSpecialGroupEntityService.Get().Where(o => o.Item_ID == item.ID);
            var SpecialOptions = items.Where(i => RelatedSkuForSpecialGroups.Select(o => o.SKU).Contains(i.SKU) || i.ID == item.ID)
                .Select(o => new ItemOptionsQueryableModel
                {
                    ID = o.ID,
                    SKU = o.SKU,
                    Name = o.VariationDescription,
                    Selected = o.ID == item.ID
                }).OrderBy(o => o.Name);
            return SpecialOptions;
        }
        public async Task<IList<ItemOptionsQueryableModel>> GetItemAvailableSizes(Item item, JWTIdentityViewModel jwtModel)
        {
            IQueryable<Item> items = GetAvailableItems(jwtModel);
            IQueryable<SKUListingForSizeAvailability> AvailableSizesQuery = _skuListingForSizeAvailabilityEntityService.Get().Where(o => o.SKU == item.SKU);
            try
            {
                var lstAvailableSizes = await items.Where(i => AvailableSizesQuery.Select(o => new SKUListingForSizeAvailabilityViewModel { Item_ID = o.Item_ID }).Any(a => a.Item_ID == i.ID) || i.ID == item.ID).ToListAsync();
                var AvailableSizes = lstAvailableSizes
                .Select(o => new ItemOptionsQueryableModel
                {
                    ID = o.ID,
                    SKU = o.SKU,
                    Selected = o.ID == item.ID,
                    Name = "W " + Helper.CmToInch(Convert.ToDouble(o.Width)) + " x D " + Helper.CmToInch(Convert.ToDouble(o.Depth)) + " x H " + Helper.CmToInch(Convert.ToDouble(o.Height)),
                    DimensionCm = "W " + Helper.FormatInteger(o.Width) + " x D " + Helper.FormatInteger(o.Depth) + " x H " + Helper.FormatInteger(o.Height)
                }).OrderBy(o => o.DimensionCm).ToList();
                return AvailableSizes;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IQueryable<ItemOptionsQueryableModel> GetItemBedSize(Item item, JWTIdentityViewModel jwtModel)
        {
            string defaultCode = item.DefaultCode.Trim();
            //Example: ID: DEFAD71C-E332-49A0-8D57-A4199606F394, SKU: AM82001SL, ParentCode: AM83001, DefaultCode: AM83001ST
            //The bed size option is always the first 2 digits in SKU, e.g., AL82004 -> 82, 83005 -> 83, BAL84 -> 84
            //Regex exp = new Regex(@"([^\d]*)([\d]{2})(.*)");
            //Match match = exp.Match(defaultCode);
            //string pattern = match.Groups[1] + "__" + match.Groups[3]; //AM__001
            //string prefix = match.Groups[1].ToString(); //AM
            //string postfix = match.Groups[3].ToString(); //001

            //get items by the same default, include selected item
            IQueryable<Item> items = GetAvailableItems(jwtModel).Where(o => o.DefaultCode.Trim() == defaultCode || o.ID == item.ID);
            //var a = items.ToList();

            //only get items by the same postfix of selected item
            Regex exp = new Regex(@"([^\d]*)([\d]{2})(.*)");
            Match match = exp.Match(item.SKU);//TAS82006.1AXI
            string selectedItemPrefix = match.Groups[1].ToString(); //TAS
            string selectedItemCode = match.Groups[2].ToString(); //82
            string selectedPostfix = match.Groups[3].ToString(); //006.XXX
            items = items.Where(i => i.SKU.EndsWith(selectedPostfix));
            //var x = items.ToList();

            //get Code name for each item
            var bedOptions = items.Select(p => new ItemOptionsQueryableModel
            {
                ID = p.ID,
                SKU = p.SKU,
                Name = _ctx.Options.FirstOrDefault(o => p.SKU.Substring(selectedItemPrefix.Length, selectedItemCode.Length) == o.Code).Name,
                Filename = _ctx.Options.FirstOrDefault(o => p.SKU.Substring(selectedItemPrefix.Length, selectedItemCode.Length) == o.Code).Filename,
                Code = _ctx.Options.FirstOrDefault(o => p.SKU.Substring(selectedItemPrefix.Length, selectedItemCode.Length) == o.Code).Code,
                Selected = p.ID == item.ID,
            });
            //var y = bedOptions.ToList();
            return bedOptions;
        }

        public IQueryable<ItemOptionsQueryableModel> GetItemOptions(Item item, JWTIdentityViewModel jwtModel)
        {
            string parentCode = item.ParentCode.Trim().ToLower();
            IQueryable<Item> items = GetAvailableItems(jwtModel).Where(o => o.ParentCode.Trim().ToLower() == parentCode);

            Guid bedGroupId = new Guid(ConstClass.ConstOtionGroupID.BedGroupId); //Do not include the 'Bed' option group as it is handled separately
            Guid finishGroupId = new Guid(ConstClass.ConstOtionGroupID.FinishGroupId);
            Guid specialGroupId = new Guid(ConstClass.ConstOtionGroupID.SpecialGroupId);

            //We need to do this complicated query because for some products, not all options in the same option group are available.  This query can be greatly simplified
            //if all options within one options group are always available.
            //The 'Traditional' option in 'Finish' option group's code is an empty string; but for others, option code cannot be empty string.
            try
            {
                var itemOptions = (from p in items
                                   from o in _ctx.Options
                                   where (

                                        (
                                            (
                                                !(SqlFunctions.PatIndex("%.____", p.SKU.Trim()) > 0) // not apply for new sku code .xxxx
                                                &&
                                                (// get sku from begin to "." for pattern sku.option
                                                    o.Code.Trim().ToLower() == (p.SKU.Substring(parentCode.Length).Length != 2 ? // if optioncode in sku = 1 character then get 1
                                                            p.SKU.Substring(parentCode.Length).Substring(0, 1).ToLower() :
                                                        // if optioncode in sku = 2 character then get 2
                                                        p.SKU.Substring(parentCode.Length).Substring(0, 2).ToLower())
                                                    ||
                                                    o.Code.Trim().ToLower() == (p.SKU.Substring(parentCode.Length).Length > 2 ? // if optioncode in sku > 2 character then get all except first character
                                                            p.SKU.Substring(parentCode.Length).Substring(1).ToLower() : "")
                                                    // if optioncode in sku = 3 character then get all characters (try to get all, option >2 is trying to get all except the first char
                                                    ||
                                                    o.Code.Trim().ToLower() == (p.SKU.Substring(parentCode.Length).Length > 2 ? // if optioncode in sku > 2 character then get all except first character
                                                            p.SKU.Substring(parentCode.Length).ToLower() : "")
                                                )
                                                &&
                                                (
                                                    (o.Code.Trim() != "" && o.Name != "Castle Bromwich") || // FW is also traditional, let exclude them but include in below 2 lines
                                                    ((p.OptionGroup_ID == finishGroupId || p.OptionGroup2_ID == finishGroupId) && p.SKU.Substring(0, p.SKU.IndexOf(".") >= 0 ? p.SKU.IndexOf(".") : p.SKU.Length).Substring(parentCode.Length).Length == 0)
                                                    || ((p.OptionGroup_ID == finishGroupId || p.OptionGroup2_ID == finishGroupId) && o.Name == "Castle Bromwich")
                                                )
                                            )
                                            ||  // new suffix .5AAA
                                            (
                                                ((SqlFunctions.PatIndex("%.____", p.SKU.Trim()) > 0) || p.SKU.Trim() == p.ParentCode.Trim()) // case for CB11003.5AAA and CB11003 only
                                                &&
                                                (
                                                    (   // case new suffix sku: CB11003.5AAA and option: .5AAA
                                                        (SqlFunctions.PatIndex(".____", o.Code.Trim()) > 0) &&  // check new suffix option case
                                                        (SqlFunctions.PatIndex("%" + o.Code.Trim(), p.SKU.Trim()) > 0) // sku end with new suffix
                                                    )
                                                    ||  // case traditional, sku: CB11003, and option: traditional (code: " ")
                                                    (
                                                        (o.Code.Trim() == "") &&  // traditional option
                                                        p.SKU.Trim() == p.ParentCode.Trim() // parent item
                                                    )
                                                )
                                            )
                                        )
                                   )
                                   select new ItemOptionsQueryableModel
                                   {
                                       ID = p.ID,
                                       SKU = p.SKU,
                                       Name = o.Name,
                                       OptionGroup = o.OptionGroup.Name,
                                       OptionGroupID = o.ID,
                                       Selected = p.ID == item.ID,
                                       Filename = o.Filename
                                   });
                /* REM to fix issue of duplicated finish for AC50004.C049 and CB53030.C026 and some case it includes itself.
                //var z = itemOptions.ToList();
                //When there are more than 1 options, one of the options may not be specified in some SKU, those items also need to be included
                var optionNotIncluedInSKU = (from p in items
                                             from o in _ctx.OptionGroups.Where(k => k.ID != bedGroupId && k.ID != specialGroupId)
                                                 //(p.OptionGroup2_ID != null && p.OptionGroup.Name != p.OptionGroup1.Name) means there are more than 1 option groups, (p.SKU.Substring(p.ParentCode.Trim().Length).Length <= 2) means there is only 1 option in SKU.
                                                 //so one of the two option groups is not specified in SKU.  The option's code should not equal to the code embeded in SKU.
                                             where //p.ID != item.ID //does not include self item
                                              (
                                         p.OptionGroup2_ID != null && p.OptionGroup_ID != bedGroupId && p.OptionGroup.Name != p.OptionGroup1.Name
                                         && p.SKU.Substring(0, p.SKU.IndexOf(".") >= 0 ? p.SKU.IndexOf(".") : p.SKU.Length).Substring(parentCode.Length).Length <= 2 ?
                                         ((o.ID == p.OptionGroup_ID || o.ID == p.OptionGroup2_ID) && !o.Options.Any(w => w.Code == p.SKU.Substring(0, p.SKU.IndexOf(".") >= 0 ?
                                             p.SKU.IndexOf(".") : p.SKU.Length).Substring(parentCode.Length))) : false)
                                             select new ItemOptionsQueryableModel
                                             {
                                                 ID = p.ID,
                                                 SKU = p.SKU,
                                                 Name = "&nbsp;",
                                                 OptionGroup = o.Name,
                                                 OptionGroupID = o.ID,
                                                 Selected = p.ID == item.ID,
                                                 Filename = ""
                                             }
                                  ).OrderBy(o => o.SKU.Length);
                //var y = optionNotIncluedInSKU.ToList();
                itemOptions = itemOptions.Union(optionNotIncluedInSKU);
                */
                return itemOptions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TAQueryBuilderFilterRule
    {
        // TODO: Need move to layer 2 or 3
        [JsonProperty("Condition")]
        public string Condition { get; set; }

        [JsonProperty("Field")]
        public string Field { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Input")]
        public string Input { get; set; }

        [JsonProperty("Operator")]
        public string Operator { get; set; }

        [JsonProperty("Rules")]
        public List<TAQueryBuilderFilterRule> Rules { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Entity")]
        public string Entity { get; set; }

        private QueryBuilderFilterRule ConvertToQueryBuilderFilterRule()
        {
            QueryBuilderFilterRule queryBuilderFilterRule = new QueryBuilderFilterRule();
            queryBuilderFilterRule.Condition = this.Condition;
            queryBuilderFilterRule.Id = this.Id;
            queryBuilderFilterRule.Input = this.Input;
            queryBuilderFilterRule.Operator = this.Operator;
            queryBuilderFilterRule.Value = new[] { this.Value };
            if (!String.IsNullOrEmpty(this.Field))
            {
                queryBuilderFilterRule.Field = this.Field.Split('0')[0] ?? null;
                queryBuilderFilterRule.Type = this.Field.Split('0')[1] ?? null;
            }
            if (this.Rules != null)
            {
                queryBuilderFilterRule.Rules = this.Rules.Select(r => r.ConvertToQueryBuilderFilterRule()).ToList();
            }
            return queryBuilderFilterRule;
        }

        public static QueryBuilderFilterRule ConvertToQueryBuilderFilterRuleFromJsonRule(string jsonRule)
        {
            TAQueryBuilderFilterRule ruleWrapper = JsonConvert.DeserializeObject<TAQueryBuilderFilterRule>(jsonRule);
            QueryBuilderFilterRule ruleQuery = ruleWrapper.ConvertToQueryBuilderFilterRule();
            return ruleQuery;
        }
    }
}
