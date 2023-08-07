
using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Data.Models
{
    public partial class Item_Price : BaseModel
    {
        [Key]
        public string SKU { get; set; }        
        public string Region { get; set; }        
        public decimal? Price { get; set; }        
    }
}

