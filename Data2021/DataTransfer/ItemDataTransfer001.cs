using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data2021.Models;

namespace TA.Data2021.DataTransfer
{
    public class ItemDataTransfer001
    {
        public Guid ID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string URLCode { get; set; }
        public string ExtendedDescription { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsCFPItem { get; set; }
        public bool? IsAXHCFPItem { get; set; }
        public bool? IsBestSeller { get; set; }
        public string ImageSirv { get; set; }
        public string Image { get; set; }
        public string BrandName { get; set; }
        public string CollectionName { get; set; }
        public string RoomAndUsageName { get; set; }
        public string TypeName { get; set; }
        public bool? IsInWishList { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
