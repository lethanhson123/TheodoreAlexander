using System;
namespace TA.Data.Models
{
    public partial class City : BaseModel
    {
        public Guid? ID { get; set; }
        public Guid? Region_ID { get; set; }
        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Population { get; set; }
        public string Timezone { get; set; }
        public decimal? GMToffset { get; set; }
    }
}

