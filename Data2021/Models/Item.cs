
using System;
namespace TA.Data2021.Models
{
    public partial class Item : BaseModel
    {
        public Guid ID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string Story { get; set; }
        public string VariationDescription { get; set; }
        public string ExtendedDescription { get; set; }
        public string AdditionalFeatures { get; set; }
        public string ParentCode { get; set; }
        public string DefaultCode { get; set; }
        public Guid? Designer_ID { get; set; }
        public Guid? LifeStyle_ID { get; set; }
        public Guid? Style_ID { get; set; }
        public Guid? Type_ID { get; set; }
        public Guid? RoomAndUsage_ID { get; set; }
        public Guid? Brand_ID { get; set; }
        public Guid? Collection_ID { get; set; }
        public Guid? PrimaryMaterial_ID { get; set; }
        public Guid? SecondaryMaterial_ID { get; set; }
        public Guid? TertiaryMaterial_ID { get; set; }
        public string Keywords { get; set; }
        public Guid? OptionGroup_ID { get; set; }
        public Guid? OptionGroup2_ID { get; set; }
        public Guid? OptionGroup3_ID { get; set; }
        public bool? HasOtherSizes { get; set; }
        public float? CBM { get; set; }
        public string Depth { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string ChairSeatHeight { get; set; }
        public string ChairArmHeight { get; set; }
        public string ChairInsideSeatDepth { get; set; }
        public string ChairInsideSeatWidth { get; set; }
        public Guid? MatchingArmOrSide { get; set; }
        public string TableClearance { get; set; }
        public string TableClosedDepth { get; set; }
        public string TableClosedWidth { get; set; }
        public string TableClosedHeight { get; set; }
        public int? TableLeavesCount { get; set; }
        public string TableLeavesWidth { get; set; }
        public int? TablesSeatsCountClosed { get; set; }
        public int? TablesSeatsCountOpen { get; set; }
        public bool? IsBestSeller { get; set; }
        public bool? IsUpholsteredBack_WoodBack { get; set; }
        public bool? Extending { get; set; }
        public bool? Nail { get; set; }
        public bool? UPHFinish { get; set; }
        public bool? IsNew { get; set; }
        public int? QuantityMultiplier { get; set; }
        public DateTime? DateCreated { get; set; }
        public string IntroductionDate { get; set; }
        public bool? IsStocked { get; set; }
        public bool? IsCFPItem { get; set; }
        public bool? IsAXHCFPItem { get; set; }
        public bool InStockProgram { get; set; }
        public bool? IsActiveINTL { get; set; }
        public bool? IsActiveTAUS { get; set; }
        public bool? IsActive { get; set; }
        public string Shipping { get; set; }
        public string URLCode { get; set; }
        public string Image { get; set; }
        public string ImageSirv { get; set; }
        public string Description { get; set; }
        public string METAKeyword { get; set; }
        public string METADescription { get; set; }
        public bool? IsDownloadImageSirv { get; set; }
        public int? ImageCount { get; set; }
        public string SketchImage { get; set; }
        public string SeatingPlanImage { get; set; }
        public string SeatingPlanPdf { get; set; }
        public decimal? CMSideAndFrontRailApronClearance { get; set; }
        public decimal? CMSlatToTopOfSideRailClearance { get; set; }
        public decimal? CMSlatToTopOfFootRailClearance { get; set; }
        public decimal? INCHSideAndFrontRailApronClearance { get; set; }
        public decimal? INCHSlatToTopOfSideRailClearance { get; set; }
        public decimal? INCHSlatToTopOfFootRailClearance { get; set; }
    }
}

