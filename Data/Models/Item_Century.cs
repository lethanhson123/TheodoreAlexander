
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_Century : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]
        public Guid? Century_ID { get; set; }
    
        public string CenturyName { get; set; }
      
    }
}

