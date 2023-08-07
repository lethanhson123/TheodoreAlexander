
using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Data.Models
{
    public partial class Item_Status : BaseModel
    {
        [Key]
        public string SKU { get; set; }        
        public string Region { get; set; }        
        public bool? IsActive { get; set; }        
    }
}

