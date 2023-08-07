
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class RelatedItem : BaseModel
    {       
        public Guid Item_ID { get; set; }
        [Key]
        public Guid RelatedItem_ID { get; set; }    
        public string Item01SKU { get; set; }
        public string Item01Name { get; set; }
        public string Item01URLCode { get; set; }
        public string Item02SKU { get; set; }
        public string Item02Name { get; set; }
        public string Item02URLCode { get; set; }       

    }
}

