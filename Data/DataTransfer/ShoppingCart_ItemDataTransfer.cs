using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class ShoppingCart_ItemDataTransfer : TA.Data.Models.ShoppingCart_Item
    {
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ImageSirv { get; set; }
        public decimal? Price { get; set; }
        public float? CBM { get; set; }
    }
}
