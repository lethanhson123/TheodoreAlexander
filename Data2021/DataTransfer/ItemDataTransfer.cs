using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data2021.Models;

namespace TA.Data2021.DataTransfer
{
    public partial class ItemDataTransfer: Item
    {       
        public string BrandName { get; set; }
        public string CollectionName { get; set; }
        public string RoomAndUsageName { get; set; }
        public string TypeName { get; set; }
        public bool? IsInWishList { get; set; }
    }
}
