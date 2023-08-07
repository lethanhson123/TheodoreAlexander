using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ItemViewModel
    {
        public Guid ID{get; set;}
        public string SKU{get; set;}
        public string ProductName { get; set; }
        public string VariationDescription { get; set; }
        public string ExtendedDescription { get; set; }
        public string AdditionalFeatures { get; set; }
        public string ParentCode { get; set; }
        public string DefaultCode { get; set; }
        public Guid Collection_ID { get; set; }
        public string CollectionName { get; set; }
        public Guid Brand_ID { get; set; }
        public string BrandName { get; set; }
        public Guid? MaterialPri_ID { get; set; }
        public string MaterialPriName { get; set; }
        public Guid? MaterialSec_ID { get; set; }
        public string MaterialSecName { get; set; }
        public Guid? MaterialTer_ID { get; set; }
        public string MaterialTerName { get; set; }
        public List<string> MaterialNames { get; set; }
        public string Keywords { get; set; }
        public string OptionGroupName { get; set; }
        public string OptionGroups { get; set; }
        public Guid? OptionGroup_ID { get; set; }
        public Guid? OptionGroup2_ID { get; set; }
        public Guid? OptionGroup3_ID { get; set; }
        public string ColourAndFinishes { get; set; }
        public int MinimumDelay { get; set; }
        public bool HasOtherSizes { get; set; }
        public double Depth { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double TableClosedDepth { get; set; }
        public double TableClosedWidth { get; set; }
        public double TableClosedHeight { get; set; }
        public double ChairSeatHeight { get; set; }
        public double ChairArmHeight { get; set; }
        public double ChairInsideSeatDepth { get; set; }
        public double ChairInsideSeatWidth { get; set; }
        public double TableClearance { get; set; }
        public int TableLeavesCount { get; set; }
        public double TableLeavesWidth { get; set; }
        public int TableSeatsCountClosed { get; set; }
        public int TableSeatsCountOpen { get; set; }

        //inch properties
        public string TableClosedDepthInch { get; set; }
        public string TableClosedWidthInch { get; set; }
        public string TableClosedHeightInch { get; set; }
        public string ChairSeatHeightInch { get; set; }
        public string ChairArmHeightInch { get; set; }
        public string ChairInsideSeatDepthInch { get; set; }
        public string ChairInsideSeatWidthInch { get; set; }
        public string TableClearanceInch { get; set; }
        public string TableLeavesWidthInch { get; set; }
        //endinch properties

        public bool IsNew { get; set; }
        public List<string> Colour { get; set; }
        public List<string> Shape { get; set; }
        public Guid RoomAndUsage_ID { get; set; }
        public string RoomAndUsageName { get; set; }
        public Guid Type_ID { get; set; }
        public string TypeName { get; set; }
        public Guid LifeStyle_ID { get; set; }
        public string LifeStyleName { get; set; }
        public Guid Style_ID { get; set; }
        public string StyleName { get; set; }
        public Guid Designer_ID { get; set; }
        public string DesignerName { get; set; }
        public string UPHFinishDownloadLink { get; set; }
        public string NailOptionsDownloadLink { get; set; }
        public bool UPHFinish { get; set; }
        public bool Nail { get; set; }
        public List<string> Geography { get; set; }
        public List<string> Century { get; set; }
        public List<string> ProcessAndTechnique { get; set; }
        public List<string> Feature2D { get; set; }
        public List<string> Feature3D { get; set; }
        public List<ShapeViewModel> Shapes { get; set; }
        //public double Price{get; set;}
        public string Story{get; set;}
        public bool IsActive{get; set;}
        public bool IsAuthorized{get; set;}
        public string Availability{get; set;}
        public int QuantityMultiplier{get; set;}
        //public double MSRPrice{get; set;}
        public double CFPPrice { get; set;}
        public double AXHCFPPrice { get; set; }
        public bool IsAXHGroup { get; set; }
        public bool IsAXHGroupTAUS { get; set; }
        public bool IsAXHGroupIntl { get; set; }
        public bool IsCustomFinish { get; set; }
        public string Options { get; set; }
        public bool InStockProgram { get; set; }
        public bool Extending { get; set; }
        //Get image on client
        //public string ImageUrl { get; set; }
    }
    public class ItemDetailsViewModel: ItemViewModel //TODO: Need to delete it
    {
        //Hau add more property for new website
        public string PurchaseAvailability { get; set; }
        public bool IsUPDGroup { get; set; }
        public bool IsUSUpholsteryGroup { get; set; }
        public bool IsINTUpholsteryGroup { get; set; }
        public bool IsLeatherInlayGroup { get; set; }
        public bool IsSteveLeungCollection { get; set; }
        public string Dimensions { get; set; }
        public string DimensionsCM { get; set; }
        //public bool IsInSpecialCase { get; set; }
        //public bool CanBuy { get; set; }
        public bool CanAddtoWishList { get; set; }
        //public double PriceMultiplier { get; set; }
        //public StorePrice DisplayedStorePrice { get; set; }
        //public StorePrice DisplayedCustomFinishPrice { get; set; }
        //public StorePrice DisplayedWholesalePrice { get; set; }
        //public StorePrice  DisplayedWholesaleCustomFinishPrice { get; set; }
        public IList<CareViewModel> ListCare { get; set; }
        public IList<ColourAndFinishViewModel> ListColourAndFinish { get; set; }
        public IList<ItemOptionGroupViewModel> ListOption { get; set; }
        public IList<ItemOptionGroupViewModel> ListBedSizeOption { get; set; }
        public IList<ItemOptionGroupViewModel> ListAvailableSizesOption { get; set; }
        public IList<ItemOptionGroupViewModel> ListSpecialOption { get; set; }
        public IList<RelatedItemViewModel> RelatedItems { get; set; }
        public IList<ItemLabel> LabelSection { get; set; }
        public IList<ItemDownloadInfo> CatalogsDownload { get; set; }
        public IList<ItemDownloadInfo> SchematicDiagram { get; set; }
        public IList<Downloads> Downloads { get; set; }
        public PriceList RetailPriceList { get; set; }
        public PriceList WholesalePriceList { get; set; }
        public ItemDetailsViewModel()
        {
            ListColourAndFinish = new List<ColourAndFinishViewModel>();
            ListOption = new List<ItemOptionGroupViewModel>();
            ListBedSizeOption = new List<ItemOptionGroupViewModel>();
            ListAvailableSizesOption = new List<ItemOptionGroupViewModel>();
            ListSpecialOption = new List<ItemOptionGroupViewModel>();
            RelatedItems = new List<RelatedItemViewModel>();
            LabelSection = new List<ItemLabel>();
            //DisplayedStorePrice = new StorePrice {
            //    Title = "Store Price:",
            //    StringPrice = string.Empty
            //};
            //DisplayedCustomFinishPrice = new StorePrice
            //{
            //    Title = "Custom Palette Finishing Service:",
            //    StringPrice = string.Empty
            //};
            //DisplayedWholesalePrice = new StorePrice
            //{
            //    Title = "Wholesale Price:",
            //    StringPrice = string.Empty
            //};
            //DisplayedWholesaleCustomFinishPrice = new StorePrice
            //{
            //    Title = "Wholesale Custom Palette Finishing Service:",
            //    StringPrice = string.Empty
            //};

            WholesalePriceList = new PriceList();
            WholesalePriceList.DealerPrice = new StorePrice
            {
                Order = 20,
                Title = "Wholesale"
            };
            WholesalePriceList.DesignerPrice = new StorePrice
            {
                Order = 40,
                Title = "Designer Price"
            };
            WholesalePriceList.AXHCustomFinishPrice = new StorePrice
            {
                Order = 60,
                Title = "Total Wholesale Price With AXH Custom Finish"
            };
            WholesalePriceList.CustomPaletteFinishServicePrice = new StorePrice
            {
                Order = 80,
                Title = "Wholesale Price Custom Palette Finishing Service"
            };
            WholesalePriceList.MSRPPrice = new StorePrice
            {
                Order = 100,
                Title = "Wholesale Suggested Retail Price"
            };

            RetailPriceList = new PriceList();
            RetailPriceList.DealerPrice = new StorePrice
            {
                Order = 20,
                Title = "Store Price"
            };
            RetailPriceList.DesignerPrice = new StorePrice
            {
                Order = 40,
                Title = "Retail Price"
            };
            RetailPriceList.AXHCustomFinishPrice = new StorePrice
            {
                Order = 60,
                Title = "Total Store Price With AXH Custom Finish"
            };
            RetailPriceList.CustomPaletteFinishServicePrice = new StorePrice
            {
                Order = 80,
                Title = "Store Price Custom Palette Finishing Service"
            };

            RetailPriceList.MSRPPrice = new StorePrice
            {
                Order = 100,
                Title = "Suggested Retail Price"
            };

            CatalogsDownload = new List<ItemDownloadInfo>();
            SchematicDiagram = new List<ItemDownloadInfo>();
            Downloads = new List<Downloads>();
        }
    }

    public class PriceList
    {
        public StorePrice MSRPPrice { get; set; }
        public StorePrice DesignerPrice { get; set; }
        public StorePrice DealerPrice { get; set; }
        public StorePrice AXHCustomFinishPrice { get; set; }
        public StorePrice CustomPaletteFinishServicePrice { get; set; }
    }

    public class StorePrice
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Order { get; set; }
    }
    public class Downloads
    {
        public string Name { get; set; }
        public IList<ItemDownloadInfo> ItemDownloadInfos { get; set; }
        public Downloads()
        {
            ItemDownloadInfos = new List<ItemDownloadInfo>();
        }
    }
    public class ItemDownloadInfo
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
    }

    public class ItemLabel
    {
        public string Name { get; set; }
        public bool Visible { get; set; }
        public string Content { get; set; }
    }
    public class StyleViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
    public class TypeViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
    public class ColourAndFinishViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
    public class SKUListingForSizeAvailabilityViewModel
    {
        public Guid ID { get; set; }
        public Guid Item_ID { get; set; }
        public string SKU { get; set; }
    }
    public class CareViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ContentTitle { get; set; }
        public string ContentBody { get; set; }
        public string ContentImageS7 { get; set; }
    }
    public class RelatedItemViewModel
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string DefaultCode { get; set; }
        public int Order { get; set; }
        public bool IsInWishList { get; set; }
    }
    public class HistoricalViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
    public class ShapeViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
    public class DownloadFileRelatedItem
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public string FileLink { get; set; }
    }
    public class FileCategory
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public IList<DownloadFileRelatedItem> Files { get; set; }
        public FileCategory()
        {
            Files = new List<DownloadFileRelatedItem>();
        }
    }
}
