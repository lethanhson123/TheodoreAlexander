
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_ColourAndFinish : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]
        public Guid? ColourAndFinish_ID { get; set; }
    
        public string ColourAndFinishName { get; set; }
      
    }
}

