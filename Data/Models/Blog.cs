using System;
namespace TA.Data.Models
{
    public partial class Blog : BaseModel
    {   
        public string title { get; set; }
        public string slug { get; set; }
        public string feature_image { get; set; }      
    }
}

