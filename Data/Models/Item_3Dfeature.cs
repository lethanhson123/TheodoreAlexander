
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Data.Models
{
    public partial class Item_3Dfeature : BaseModel
    {
        
        public Guid Item_ID { get; set; }
        [Key]


        [Column("3Dfeature_ID")]
        public Guid? Feature_ID3D { get; set; }

        public string FeatureName { get; set; }
      
    }
}

