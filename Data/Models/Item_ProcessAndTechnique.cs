
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_ProcessAndTechnique : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]
        public Guid? ProcessAndTechnique_ID { get; set; }
    
        public string ProcessAndTechniqueName { get; set; }
      
    }
}

