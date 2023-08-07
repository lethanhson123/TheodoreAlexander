
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_HistoricalStyle : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]
        public Guid? HistoricalStyle_ID { get; set; }
    
        public string HistoricalStyleName { get; set; }
      
    }
}

