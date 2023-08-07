
using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Data.Models
{
    public partial class Item_Shape : BaseModel
    {
        [Key]
        public Guid Item_ID { get; set; }        
        public Guid? Shape_ID { get; set; }
        public string ShapeName { get; set; }
        public string ItemName { get; set; }
        public string ItemSKU { get; set; }
    }
}

