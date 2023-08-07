using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class ItemDataTransfer: Item
    {       
        public string BrandName { get; set; }
        public string BrandURLCode { get; set; }
        public string CollectionName { get; set; }
        public string CollectionURLCode { get; set; }
        public string RoomAndUsageName { get; set; }
        public string RoomAndUsageURLCode { get; set; }
        public string TypeName { get; set; }
        public string TypeURLCode { get; set; }
        public string DesignerName { get; set; }
        public string StyleName { get; set; }
        public string StyleURLCode { get; set; }
        public string LifeStyleName { get; set; }
        public string LifeStyleURLCode { get; set; }

        public string PrimaryMaterialName { get; set; }

        public string PrimaryMaterialMaterialCategoryName { get; set; }

        public string SecondaryMaterialName { get; set; }

        public string SecondaryMaterialCategoryName { get; set; }
        public string TertiaryMaterialName { get; set; }
        public string TertiaryMaterialCategoryName { get; set; }
        public string OptionGroupName { get; set; }
        public string OptionGroupGroupName { get; set; }
        public string OptionGroup2Name { get; set; }
        public string OptionGroup2GroupName { get; set; }
        public string OptionGroup3Name { get; set; }
        public string OptionGroup3GroupName { get; set; }
        public string MatchingArmOrSideName { get; set; }

        public bool? IsInWishList { get; set; }
    }
}
