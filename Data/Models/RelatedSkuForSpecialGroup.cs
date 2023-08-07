
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class RelatedSkuForSpecialGroup : BaseModel
    {
        public Guid Item_ID { get; set; }
        [Key]
        public string SKU { get; set; }

    }
}

