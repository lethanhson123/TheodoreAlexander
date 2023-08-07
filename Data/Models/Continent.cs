using System;
namespace TA.Data.Models
{
    public partial class Continent : BaseModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

