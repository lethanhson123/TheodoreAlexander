
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class SKUListingForSizeAvailability : BaseModel
    {

        [Key]
        public Guid ID { get; set; }
        public Guid Item_ID { get; set; }       

        public string SKU { get; set; }
      
    }
}

