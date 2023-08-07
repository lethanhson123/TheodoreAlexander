using System;
namespace TA.Data.Models
{
    public partial class Care : BaseModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ContentTitle { get; set; }
        public string ContentBody { get; set; }       
        public string ContentImageS7 { get; set; }
    }
}

