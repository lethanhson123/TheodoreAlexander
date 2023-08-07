
using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Data.Models
{
    public partial class Item_Fabric : BaseModel
    {
        [Key]
        public Guid ID { get; set; }        
        public Guid? ItemID { get; set; }
        public string FabricCode { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }        
    }
}

