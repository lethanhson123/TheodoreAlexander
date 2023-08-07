
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_Geography : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]
        public Guid? Geography_ID { get; set; }
    
        public string GeographyName { get; set; }
      
    }
}

