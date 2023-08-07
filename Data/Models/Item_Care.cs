
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_Care : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]
        public Guid? Care_ID { get; set; }

        public string CareName { get; set; }
      
    }
}

