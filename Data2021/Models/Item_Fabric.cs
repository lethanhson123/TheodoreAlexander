using System;
namespace TA.Data2021.Models
{
    public partial class Item_Fabric : BaseModel
    {
        public Guid ID { get; set; }
        public Guid? ItemID { get; set; }
        public string FabricCode { get; set; }
        public bool? IsActive { get; set; }       
        public string Note { get; set; }       
    }
}

