using System;
namespace TA.Data.Models
{
public partial class City: BaseModel
{
public Guid? ID { get; set; }
public Guid? Region_ID { get; set; }
public string Name { get; set; }
public string Latitude { get; set; }
public string Longitude { get; set; }
public int? Population { get; set; }
public string Timezone { get; set; }
public string GMToffset { get; set; }
}
}

