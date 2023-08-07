
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_2Dfeature : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]

        [Column("2Dfeature_ID")]
        public Guid? Feature_ID2D { get; set; }
    
        public string FeatureName { get; set; }
      
    }
}

