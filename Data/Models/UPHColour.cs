using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Data.Models
{
    public partial class UPHColour : BaseModel
    {
        [Key]
        public string colour { get; set; }       
        public string code { get; set; }
        public bool? enable { get; set; }
        public string CodeHex { get; set; }                       
    }
}

