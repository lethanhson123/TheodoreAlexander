using System;
namespace TA.Data.Models
{
    public partial class Region : BaseModel
    {
        public Guid? ID { get; set; }
        public Guid? Country_ID { get; set; }
        public string Name { get; set; }
    }
}

