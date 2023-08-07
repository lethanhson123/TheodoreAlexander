using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ItemDto
    {
        [NonSerialized]
        public Item entity;
        #region Basic property
        public System.Guid ID { get; set; }
        public string SKU { get; set; }
        public string URLCode { get; set; }
        public string ProductName { get; set; }
        public string ParentCode { get; set; }
        public string DefaultCode { get; set; }
        public string Story { get; set; }
        public string VariationDescription { get; set; }
        public string ExtendedDescription { get; set; }
        public string AdditionalFeatures { get; set; }
        public bool IsNew { get; set; }
        public int QuantityMultiplier { get; set; }
        public bool UPHFinish { get; set; }
        public bool IsNail { get; set; }

        #endregion

        #region Item dimension
        public double? CBM { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string Dimensions { get; set; }
        public string DimensionsCM { get; set; }

        public decimal? ChairArmHeight { get; set; }
        public string ChairArmHeightInch { get; set; }
        public decimal? ChairSeatHeight { get; set; }
        public string ChairSeatHeightInch { get; set; }
        public decimal? ChairInsideSeatDepth { get; set; }
        public string ChairInsideSeatDepthInch { get; set; }
        public decimal? ChairInsideSeatWidth { get; set; }
        public string ChairInsideSeatWidthInch { get; set; }
        public decimal? TableClearance { get; set; }
        public string TableClearanceInch { get; set; }
        public decimal? TableClosedDepth { get; set; }
        public string TableClosedDepthInch { get; set; }
        public decimal? TableClosedWidth { get; set; }
        public string TableClosedWidthInch { get; set; }
        public decimal? TableClosedHeight { get; set; }
        public string TableClosedHeightInch { get; set; }
        public decimal? TableLeavesWidth { get; set; }
        public string TableLeavesWidthInch { get; set; }
        public int? TableLeavesCount { get; set; }
        public int? TablesSeatsCountClosed { get; set; }
        public int? TablesSeatsCountOpen { get; set; }
        public decimal? CMSideAndFrontRailApronClearance { get; set; }
        public decimal? CMSlatToTopOfSideRailClearance { get; set; }
        public decimal? CMSlatToTopOfFootRailClearance { get; set; }
        public decimal? INCHSideAndFrontRailApronClearance { get; set; }
        public decimal? INCHSlatToTopOfSideRailClearance { get; set; }
        public decimal? INCHSlatToTopOfFootRailClearance { get; set; }
        public string INCHSideAndFrontRailApronClearanceString { get; set; }
        public string INCHSlatToTopOfSideRailClearanceString { get; set; }
        public string INCHSlatToTopOfFootRailClearanceString { get; set; }
        #endregion

        #region Item taxonomy
        public ObjectIdName Designer { get; set; }
        public string Designer_ID { get; set; }
        public string Designer_Name { get; set; }
        public ObjectIdName LifeStyle { get; set; }
        public string LifeStyle_ID { get; set; }
        public string LifeStyle_Name { get; set; }
        public ObjectIdName Style { get; set; }
        public string Style_ID { get; set; }
        public string Style_Name { get; set; }
        public ObjectIdName Type { get; set; }
        public string Type_ID { get; set; }
        public string Type_Name { get; set; }
        public ObjectIdName RoomAndUsage { get; set; }
        public string RoomAndUsage_ID { get; set; }
        public string RoomAndUsage_Name { get; set; }
        public ObjectIdName Brand { get; set; }
        public string Brand_ID { get; set; }
        public string Brand_Name { get; set; }
        public ObjectIdName Collection { get; set; }
        public string Collection_ID { get; set; }
        public string Collection_Name { get; set; }
        public List<ObjectIdName> OptionGroups { get; set; }
        public string OptionGroup_ID { get; set; }
        public string OptionGroup_Name { get; set; }
        public string OptionGroup_GroupName { get; set; }
        public string OptionGroup2_ID { get; set; }
        public string OptionGroup2_Name { get; set; }
        public string OptionGroup2_GroupName { get; set; }
        public string OptionGroup3_ID { get; set; }
        public string OptionGroup3_Name { get; set; }
        public string OptionGroup3_GroupName { get; set; }

        public string Material1_ID { get; set; }
        public string Material1_Name { get; set; }
        public string Material2_ID { get; set; }
        public string Material2_Name { get; set; }
        public string Material3_ID { get; set; }
        public string Material3_Name { get; set; }

        public List<ObjectIdName> Materials { get; set; }
        public List<ObjectIdName> Shapes { get; set; }
        public List<CareViewModel> FurnitureCares { get; set; }
        public List<UPHFabricDTO> Fabrics { get; set; }
        [NonSerialized]
        public ICollection<ObjectIdName> ExclusivityGroups;
        #endregion

        #region Item options
        public List<string> images { get; set; }
        public string sketchImage { get; set; }
        public string seatingPlanImage { get; set; }
        public string seatingPlanPdf { get; set; }
        public IList<ItemOptionGroupViewModel> ListOption { get; set; }
        public IList<ItemOptionGroupViewModel> ListBedSizeOption { get; set; }
        public IList<ItemOptionGroupViewModel> ListAvailableSizesOption { get; set; }
        public IList<ItemOptionGroupViewModel> ListSpecialOption { get; set; }
        #endregion

        #region Item price
        public PriceList RetailPriceList { get; set; }
        public PriceList WholesalePriceList { get; set; }
        #endregion

        #region Extra property
        public IList<RelatedItemViewModel> RelatedItems { get; set; }
        public IList<ItemDownloadInfo> CatalogsDownload { get; set; }
        public IList<ItemDownloadInfo> SchematicDiagram { get; set; }
        public IList<Downloads> Downloads { get; set; }
        public int MinimumDelay { get; set; }
        public bool InStockProgram { get; set; }
        public string Availability { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsCFPItem { get; set; }
        public bool IsAXHCFPItem { get; set; }
        public bool IsInWishList { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveTAUS { get; set; }
        public bool IsActiveINTL { get; set; }
        public Dictionary<string, bool> Tags = new Dictionary<string, bool>();
        #endregion

        public static System.Linq.Expressions.Expression<Func<Item, ItemDto>> FromEntityConverterForQueryBuilder = item => new ItemDto()
        {
            entity = item,
            #region Basic property
            ID = item.ID,
            SKU = item.SKU,
            ProductName = item.ProductName,
            Story = item.Story,
            VariationDescription = item.VariationDescription,
            ExtendedDescription = item.ExtendedDescription,
            AdditionalFeatures = item.AdditionalFeatures,
            ParentCode = item.ParentCode,
            DefaultCode = item.DefaultCode,
            IsNew = item.IsNew,
            QuantityMultiplier = item.QuantityMultiplier != 0 ? item.QuantityMultiplier : 1,
            UPHFinish = item.UPHFinish ?? false,
            IsAXHCFPItem = item.IsAXHCFPItem ?? false,
            IsCFPItem = item.IsCFPItem ?? false,
            InStockProgram = item.InStockProgram ?? false,
            IsNail = item.Nail ?? false,
            IsActive = item.IsActive ?? false,
            IsActiveINTL = item.IsActiveINTL ?? false,
            IsActiveTAUS = item.IsActiveTAUS ?? false,
            #endregion

            #region Item dimension
            //CBM = item.CBM.Value,
            //Depth = item.Depth,
            //Width = item.Width,
            //Height = item.Height,
            ////Dimensions = "W " + Helper.CmToInch(item.Width) + " x D " + Helper.CmToInch(item.Depth) + " x H " + Helper.CmToInch(item.Height),
            ////DimensionsCM = "W " + Convert.ToDouble((item.Width)).ToString() + " x D " + Convert.ToDouble((item.Depth)).ToString() + " x H " + Convert.ToDouble((item.Height)).ToString(),
            //ChairArmHeight = item.ChairArmHeight,
            ////ChairArmHeightInch = Helper.CmToInch(item.ChairArmHeight),
            //ChairSeatHeight = item.ChairSeatHeight,
            ////ChairSeatHeightInch = Helper.CmToInch(item.ChairSeatHeight),
            //ChairInsideSeatDepth = item.ChairInsideSeatDepth,
            ////ChairInsideSeatDepthInch = Helper.CmToInch(item.ChairInsideSeatDepth),
            //ChairInsideSeatWidth = item.ChairInsideSeatWidth,
            ////ChairInsideSeatWidthInch = Helper.CmToInch(item.ChairInsideSeatWidth),
            //TableClearance = item.TableClearance,
            ////TableClearanceInch = Helper.CmToInch(item.TableClearance),
            //TableClosedDepth = item.TableClosedDepth,
            ////TableClosedDepthInch = Helper.CmToInch(item.TableClosedDepth),
            //TableClosedWidth = item.TableClosedWidth,
            ////TableClosedWidthInch = Helper.CmToInch(item.TableClosedWidth),
            //TableClosedHeight = item.TableClosedHeight,
            ////TableClosedHeightInch = Helper.CmToInch(item.TableClosedHeight),
            //TableLeavesWidth = item.TableLeavesWidth,
            ////TableLeavesWidthInch = Helper.CmToInch(item.TableLeavesWidth),
            //TableLeavesCount = item.TableLeavesCount,
            //TablesSeatsCountClosed = item.TablesSeatsCountClosed,
            //TablesSeatsCountOpen = item.TablesSeatsCountOpen,
            #endregion

            #region Item taxonomy
            //Designer = item.Designer != null ? new ObjectIdName() { ID = item.Designer.ID, Name = item.Designer.Name } : null,
            Designer_ID = item.Designer_ID.HasValue ? item.Designer_ID.ToString() : String.Empty,
            Designer_Name = item.Designer == null ? String.Empty : item.Designer.Name,

            //LifeStyle = item.LifeStyle != null ? new ObjectIdName() { ID = item.LifeStyle.ID, Name = item.LifeStyle.Name } : null,
            LifeStyle_ID = item.LifeStyle_ID.HasValue ? item.LifeStyle_ID.ToString() : String.Empty,
            LifeStyle_Name = item.LifeStyle == null ? String.Empty : item.LifeStyle.Name,

            //Style = item.Style != null ? new ObjectIdName() { ID = item.Style.ID, Name = item.Style.Name } : null,
            Style_ID = item.Style_ID.HasValue ? item.Style_ID.ToString() : String.Empty,
            Style_Name = item.Style == null ? String.Empty : item.Style.Name,

            //Type = item.Type != null ? new ObjectIdName() { ID = item.Type.ID, Name = item.Type.Name } : null,
            Type_ID = item.Type_ID.HasValue ? item.Type_ID.ToString() : String.Empty,
            Type_Name = item.Type == null ? String.Empty : item.Type.Name,

            //RoomAndUsage = item.RoomAndUsage != null ? new ObjectIdName() { ID = item.RoomAndUsage.ID, Name = item.RoomAndUsage.Name } : null,
            RoomAndUsage_ID = item.RoomAndUsage_ID.HasValue ? item.RoomAndUsage_ID.ToString() : String.Empty,
            RoomAndUsage_Name = item.RoomAndUsage == null ? String.Empty : item.RoomAndUsage.Name,

            //Brand = item.Brand != null ? new ObjectIdName() { ID = item.Brand.ID, Name = item.Brand.Name } : null,
            Brand_ID = item.Brand_ID.ToString(),
            Brand_Name = item.Brand == null ? String.Empty : item.Brand.Name,

            //Collection = item.Collection != null ? new ObjectIdName() { ID = item.Collection.ID, Name = item.Collection.Name } : null,
            Collection_ID = item.Collection_ID.HasValue ? item.Collection_ID.ToString() : String.Empty,
            Collection_Name = item.Collection == null ? String.Empty : item.Collection.Name,

            OptionGroup_ID = item.OptionGroup_ID.HasValue ? item.OptionGroup_ID.ToString() : String.Empty,
            OptionGroup_Name = item.OptionGroup == null ? String.Empty : item.OptionGroup.Name,
            OptionGroup_GroupName = item.OptionGroup == null ? String.Empty : item.OptionGroup.GroupName,
            OptionGroup2_ID = item.OptionGroup2_ID.HasValue ? item.OptionGroup2_ID.ToString() : String.Empty,
            OptionGroup2_Name = item.OptionGroup1 == null ? String.Empty : item.OptionGroup1.Name,
            OptionGroup2_GroupName = item.OptionGroup1 == null ? String.Empty : item.OptionGroup1.GroupName,
            OptionGroup3_ID = item.OptionGroup3_ID.HasValue ? item.OptionGroup3_ID.ToString() : String.Empty,
            OptionGroup3_Name = item.OptionGroup2 == null ? String.Empty : item.OptionGroup2.Name,
            OptionGroup3_GroupName = item.OptionGroup2 == null ? String.Empty : item.OptionGroup2.GroupName,
            Material1_ID = item.PrimaryMaterial_ID.HasValue ? item.Material.ID.ToString() : string.Empty,
            Material1_Name = item.Material == null ? string.Empty : item.Material.Name,
            Material2_ID = item.SecondaryMaterial_ID.HasValue ? item.Material1.ID.ToString() : string.Empty,
            Material2_Name = item.Material1 == null ? string.Empty : item.Material1.Name,
            Material3_ID = item.TertiaryMaterial_ID.HasValue ? item.Material2.ID.ToString() : string.Empty,
            Material3_Name = item.Material2 == null ? string.Empty : item.Material2.Name,
            //Shapes = item.Shapes.Select(e => new ObjectIdName() { ID = e.ID, Name = e.Name }).ToList(),
            //FurnitureCares = item.Cares.Select(c => new CareViewModel { ID = c.ID, Name = c.Name, ContentTitle = c.ContentTitle, ContentBody = c.ContentBody, ContentImageS7 = c.ContentImageS7 }).ToList(),
            //ExclusivityGroups = item.ExclusivityGroups.Select(e => new ObjectIdName() { ID = e.ID, Name = e.Name }).ToList(),

            //MinimumDelay = item.Item_ShippingStatus.Any(iss => iss.Quantity > 0) ? item.Item_ShippingStatus.Where(iss => iss.Quantity > 0).OrderBy(s => s.ShippingStatu.MinimumDelay).FirstOrDefault().ShippingStatu.MinimumDelay : 16,//16 is longest Ships in 22-28 weeks
            //Availability = item.Item_ShippingStatus.Any(iss => iss.Quantity > 0) ? item.Item_ShippingStatus.Where(iss => iss.Quantity > 0).OrderBy(s => s.ShippingStatu.MinimumDelay).FirstOrDefault().ShippingStatu.DeliveryTime : "Ships in 22-28 weeks",
            #endregion
        };


        public static ItemDto BuildNonEntityFields(ItemDto item)
        {
            item.Dimensions = "W " + Helper.CmToInch(item.Width) + " x D " + Helper.CmToInch(item.Depth) + " x H " + Helper.CmToInch(item.Height);
            item.DimensionsCM = "W " + Convert.ToDouble((item.Width)).ToString() + " x D " + Convert.ToDouble((item.Depth)).ToString() + " x H " + Convert.ToDouble((item.Height)).ToString();
            item.ChairArmHeightInch = Helper.CmToInch(item.ChairArmHeight);
            item.ChairSeatHeightInch = Helper.CmToInch(item.ChairSeatHeight);
            item.ChairInsideSeatDepthInch = Helper.CmToInch(item.ChairInsideSeatDepth);
            item.ChairInsideSeatWidthInch = Helper.CmToInch(item.ChairInsideSeatWidth);
            item.TableClearanceInch = Helper.CmToInch(item.TableClearance);
            item.TableClosedDepthInch = Helper.CmToInch(item.TableClosedDepth);
            item.TableClosedWidthInch = Helper.CmToInch(item.TableClosedWidth);
            item.TableClosedHeightInch = Helper.CmToInch(item.TableClosedHeight);
            item.TableLeavesWidthInch = Helper.CmToInch(item.TableLeavesWidth);

            item.OptionGroups = new List<ObjectIdName>();
            if (!String.IsNullOrEmpty(item.OptionGroup_ID)) { item.OptionGroups.Add(new ObjectIdName(Guid.Parse(item.OptionGroup_ID), item.OptionGroup_Name, item.OptionGroup_GroupName)); };
            if (!String.IsNullOrEmpty(item.OptionGroup2_ID)) { item.OptionGroups.Add(new ObjectIdName(Guid.Parse(item.OptionGroup2_ID), item.OptionGroup2_Name, item.OptionGroup2_GroupName)); };
            if (!String.IsNullOrEmpty(item.OptionGroup3_ID)) { item.OptionGroups.Add(new ObjectIdName(Guid.Parse(item.OptionGroup3_ID), item.OptionGroup3_Name, item.OptionGroup3_GroupName)); };

            item.Materials = new List<ObjectIdName>();
            if (!String.IsNullOrEmpty(item.Material1_ID)) { item.Materials.Add(new ObjectIdName(Guid.Parse(item.Material1_ID), item.Material1_Name)); };
            if (!String.IsNullOrEmpty(item.Material2_ID)) { item.Materials.Add(new ObjectIdName(Guid.Parse(item.Material2_ID), item.Material2_Name)); };
            if (!String.IsNullOrEmpty(item.Material3_ID)) { item.Materials.Add(new ObjectIdName(Guid.Parse(item.Material3_ID), item.Material3_Name)); };

            return item;
        }

        public ItemDto(Item item) : this()
        {
            if (item != null)
            {
                entity = item;
                #region Basic property
                ID = item.ID;
                SKU = item.SKU;
                URLCode = item.URLCode;
                CMSideAndFrontRailApronClearance = item.CMSideAndFrontRailApronClearance;
                CMSlatToTopOfSideRailClearance = item.CMSlatToTopOfSideRailClearance;
                CMSlatToTopOfFootRailClearance = item.CMSlatToTopOfFootRailClearance;
                INCHSideAndFrontRailApronClearance = item.INCHSideAndFrontRailApronClearance;
                INCHSlatToTopOfSideRailClearance = item.INCHSlatToTopOfSideRailClearance;
                INCHSlatToTopOfFootRailClearance = item.INCHSlatToTopOfFootRailClearance;
                INCHSideAndFrontRailApronClearanceString = item.INCHSideAndFrontRailApronClearanceString;
                INCHSlatToTopOfSideRailClearanceString = item.INCHSlatToTopOfSideRailClearanceString;
                INCHSlatToTopOfFootRailClearanceString = item.INCHSlatToTopOfFootRailClearanceString;
                ProductName = item.ProductName;
                Story = item.Story;
                VariationDescription = item.VariationDescription;
                ExtendedDescription = item.ExtendedDescription;
                AdditionalFeatures = item.AdditionalFeatures;
                ParentCode = item.ParentCode;
                DefaultCode = item.DefaultCode;
                IsNew = item.IsNew;
                QuantityMultiplier = item.QuantityMultiplier != 0 ? item.QuantityMultiplier : 1;
                UPHFinish = item.UPHFinish ?? false;
                IsAXHCFPItem = item.IsAXHCFPItem ?? false;
                IsCFPItem = item.IsCFPItem ?? false;
                InStockProgram = item.InStockProgram ?? false;
                IsNail = item.Nail ?? false;
                IsActive = item.IsActive ?? false;
                IsActiveINTL = item.IsActiveINTL ?? false;
                IsActiveTAUS = item.IsActiveTAUS ?? false;
                #endregion

                #region Item dimension
                CBM = item.CBM;
                Depth = item.Depth;
                Width = item.Width;
                Height = item.Height;
                Dimensions = "W " + Helper.CmToInch(item.Width) + " x D " + Helper.CmToInch(item.Depth) + " x H " + Helper.CmToInch(item.Height);
                DimensionsCM = "W " + Convert.ToDouble((item.Width)).ToString() + " x D " + Convert.ToDouble((item.Depth)).ToString() + " x H " + Convert.ToDouble((item.Height)).ToString();
                ChairArmHeight = item.ChairArmHeight;
                ChairArmHeightInch = Helper.CmToInch(item.ChairArmHeight);
                ChairSeatHeight = item.ChairSeatHeight;
                ChairSeatHeightInch = Helper.CmToInch(item.ChairSeatHeight);
                ChairInsideSeatDepth = item.ChairInsideSeatDepth;
                ChairInsideSeatDepthInch = Helper.CmToInch(item.ChairInsideSeatDepth);
                ChairInsideSeatWidth = item.ChairInsideSeatWidth;
                ChairInsideSeatWidthInch = Helper.CmToInch(item.ChairInsideSeatWidth);
                TableClearance = item.TableClearance;
                TableClearanceInch = Helper.CmToInch(item.TableClearance);
                TableClosedDepth = item.TableClosedDepth;
                TableClosedDepthInch = Helper.CmToInch(item.TableClosedDepth);
                TableClosedWidth = item.TableClosedWidth;
                TableClosedWidthInch = Helper.CmToInch(item.TableClosedWidth);
                TableClosedHeight = item.TableClosedHeight;
                TableClosedHeightInch = Helper.CmToInch(item.TableClosedHeight);
                TableLeavesWidth = item.TableLeavesWidth;
                TableLeavesWidthInch = Helper.CmToInch(item.TableLeavesWidth);
                TableLeavesCount = item.TableLeavesCount;
                TablesSeatsCountClosed = item.TablesSeatsCountClosed;
                TablesSeatsCountOpen = item.TablesSeatsCountOpen;
                #endregion

                #region Item taxonomy
                Designer = item.Designer != null ? new ObjectIdName() { ID = item.Designer.ID, Name = item.Designer.Name } : null;
                Designer_ID = item.Designer_ID.HasValue ? item.Designer_ID.ToString() : String.Empty;
                Designer_Name = item.Designer == null ? String.Empty : item.Designer.Name;

                LifeStyle = item.LifeStyle != null ? new ObjectIdName() { ID = item.LifeStyle.ID, Name = item.LifeStyle.Name } : null;
                LifeStyle_ID = item.LifeStyle_ID.HasValue ? item.LifeStyle_ID.ToString() : String.Empty;
                LifeStyle_Name = item.LifeStyle == null ? String.Empty : item.LifeStyle.Name;

                Style = item.Style != null ? new ObjectIdName() { ID = item.Style.ID, Name = item.Style.Name } : null;
                Style_ID = item.Style_ID.HasValue ? item.Style_ID.ToString() : String.Empty;
                Style_Name = item.Style == null ? String.Empty : item.Style.Name;

                Type = item.Type != null ? new ObjectIdName() { ID = item.Type.ID, Name = item.Type.Name } : null;
                Type_ID = item.Type_ID.HasValue ? item.Type_ID.ToString() : String.Empty;
                Type_Name = item.Type == null ? String.Empty : item.Type.Name;

                RoomAndUsage = item.RoomAndUsage != null ? new ObjectIdName() { ID = item.RoomAndUsage.ID, Name = item.RoomAndUsage.Name } : null;
                RoomAndUsage_ID = item.RoomAndUsage_ID.HasValue ? item.RoomAndUsage_ID.ToString() : String.Empty;
                RoomAndUsage_Name = item.RoomAndUsage == null ? String.Empty : item.RoomAndUsage.Name;

                Brand = item.Brand != null ? new ObjectIdName() { ID = item.Brand.ID, Name = item.Brand.Name } : null;
                Brand_ID = item.Brand_ID.ToString();
                Brand_Name = item.Brand == null ? String.Empty : item.Brand.Name;

                Collection = item.Collection != null ? new ObjectIdName() { ID = item.Collection.ID, Name = item.Collection.Name } : null;
                Collection_ID = item.Collection_ID.HasValue ? item.Collection_ID.ToString() : String.Empty;
                Collection_Name = item.Collection == null ? String.Empty : item.Collection.Name;

                OptionGroup_ID = item.OptionGroup_ID.HasValue ? item.OptionGroup_ID.ToString() : String.Empty;
                OptionGroup_Name = item.OptionGroup == null ? String.Empty : item.OptionGroup.Name;
                OptionGroup_GroupName = item.OptionGroup == null ? String.Empty : item.OptionGroup.GroupName;
                OptionGroup2_ID = item.OptionGroup2_ID.HasValue ? item.OptionGroup2_ID.ToString() : String.Empty;
                OptionGroup2_Name = item.OptionGroup1 == null ? String.Empty : item.OptionGroup1.Name;
                OptionGroup2_GroupName = item.OptionGroup1 == null ? String.Empty : item.OptionGroup1.GroupName;
                OptionGroup3_ID = item.OptionGroup3_ID.HasValue ? item.OptionGroup3_ID.ToString() : String.Empty;
                OptionGroup3_Name = item.OptionGroup2 == null ? String.Empty : item.OptionGroup2.Name;
                OptionGroup3_GroupName = item.OptionGroup2 == null ? String.Empty : item.OptionGroup2.GroupName;
                OptionGroups = new List<ObjectIdName>();
                if (!String.IsNullOrEmpty(OptionGroup_ID)) { OptionGroups.Add(new ObjectIdName(Guid.Parse(OptionGroup_ID), OptionGroup_Name, OptionGroup_GroupName)); };
                if (!String.IsNullOrEmpty(OptionGroup2_ID)) { OptionGroups.Add(new ObjectIdName(Guid.Parse(OptionGroup2_ID), OptionGroup2_Name, OptionGroup2_GroupName)); };
                if (!String.IsNullOrEmpty(OptionGroup3_ID)) { OptionGroups.Add(new ObjectIdName(Guid.Parse(OptionGroup3_ID), OptionGroup3_Name, OptionGroup3_GroupName)); };

                Material1_ID = item.PrimaryMaterial_ID.HasValue ? item.Material.ID.ToString() : string.Empty;
                Material1_Name = item.Material == null ? string.Empty : item.Material.Name;
                Material2_ID = item.SecondaryMaterial_ID.HasValue ? item.Material1.ID.ToString() : string.Empty;
                Material2_Name = item.Material1 == null ? string.Empty : item.Material1.Name;
                Material3_ID = item.TertiaryMaterial_ID.HasValue ? item.Material2.ID.ToString() : string.Empty;
                Material3_Name = item.Material2 == null ? string.Empty : item.Material2.Name;
                Materials = new List<ObjectIdName>();
                if (!String.IsNullOrEmpty(Material1_ID)) { Materials.Add(new ObjectIdName(Guid.Parse(Material1_ID), Material1_Name)); };
                if (!String.IsNullOrEmpty(Material2_ID)) { Materials.Add(new ObjectIdName(Guid.Parse(Material2_ID), Material2_Name)); };
                if (!String.IsNullOrEmpty(Material3_ID)) { Materials.Add(new ObjectIdName(Guid.Parse(Material3_ID), Material3_Name)); };

                Shapes = item.Shapes.Select(e => new ObjectIdName() { ID = e.ID, Name = e.Name }).ToList();
                Fabrics = item.Item_Fabric.Select(iff => iff.UPHFabric).Select(f => new UPHFabricDTO() { Fabric = f.Fabric, Category = f.Category, Name = f.Name, IsEnabled = f.enable, IsEnabledOnWeb = f.IsEnabledOnWeb, Grade = f.Grade ?? 0, GradeStudio = f.GradeStudio, IsCutYardage = f.IsCutYardage, RLC = f.RLC }).ToList();
                FurnitureCares = item.Cares.Select(c => new CareViewModel { ID = c.ID, Name = c.Name, ContentTitle = c.ContentTitle, ContentBody = c.ContentBody, ContentImageS7 = c.ContentImageS7 }).ToList();
                ExclusivityGroups = item.ExclusivityGroups.Select(e => new ObjectIdName() { ID = e.ID, Name = e.Name }).ToList();

                MinimumDelay = item.Item_ShippingStatus.Any(iss => iss.Quantity > 0) ? item.Item_ShippingStatus.Where(iss => iss.Quantity > 0).OrderBy(s => s.ShippingStatu.MinimumDelay).FirstOrDefault().ShippingStatu.MinimumDelay : 16;//16 is longest Ships in 22-28 weeks
                Availability = item.Shipping;
                //Availability = item.Item_ShippingStatus.Any(iss => iss.Quantity > 0) ? item.Item_ShippingStatus.Where(iss => iss.Quantity > 0).OrderBy(s => s.ShippingStatu.MinimumDelay).FirstOrDefault().ShippingStatu.DeliveryTime : "Ships in 22-28 weeks";
                #endregion

                BuildNonEntityFields(this);
            }
        }

        public ItemDto()
        {
            ListOption = new List<ItemOptionGroupViewModel>();
            ListBedSizeOption = new List<ItemOptionGroupViewModel>();
            ListAvailableSizesOption = new List<ItemOptionGroupViewModel>();
            ListSpecialOption = new List<ItemOptionGroupViewModel>();
            RelatedItems = new List<RelatedItemViewModel>();
            CatalogsDownload = new List<ItemDownloadInfo>();
            SchematicDiagram = new List<ItemDownloadInfo>();
            Downloads = new List<Downloads>();

            WholesalePriceList = new PriceList();
            WholesalePriceList.DealerPrice = new StorePrice
            {
                Order = 20,
                Title = "Wholesale As Shown Price"
            };
            WholesalePriceList.DesignerPrice = new StorePrice
            {
                Order = 40,
                Title = "Wholesale Price"
            };
            WholesalePriceList.AXHCustomFinishPrice = new StorePrice
            {
                Order = 60,
                Title = "Wholesale Total Price With AXH Custom Finish"
            };
            WholesalePriceList.CustomPaletteFinishServicePrice = new StorePrice
            {
                Order = 80,
                Title = "Wholesale Custom Palette Finishing Service"
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
                Title = "As Shown Price"
            };
            RetailPriceList.DesignerPrice = new StorePrice
            {
                Order = 40,
                Title = "Retail Price"
            };
            RetailPriceList.AXHCustomFinishPrice = new StorePrice
            {
                Order = 60,
                Title = "Total Price With AXH Custom Finish"
            };
            RetailPriceList.CustomPaletteFinishServicePrice = new StorePrice
            {
                Order = 80,
                Title = "Custom Palette Finishing Service"
            };

            RetailPriceList.MSRPPrice = new StorePrice
            {
                Order = 100,
                Title = "Suggested Retail Price"
            };
        }
    }

    public class ObjectIdName
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string SecondaryName { get; set; }

        public ObjectIdName() { }
        public ObjectIdName(Guid? ID, string Name, string SecondaryName = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.SecondaryName = SecondaryName;
        }
    }
}
