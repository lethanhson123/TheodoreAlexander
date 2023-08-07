using System;
namespace TA.Data.Models
{
public partial class Brand: BaseModel
{
public Guid? ID { get; set; }
public string Name { get; set; }
public string URLCode { get; set; }
public string URL { get; set; }
public int? GroupCode { get; set; }
public int? SortCode { get; set; }
public int? ItemCount { get; set; }
public bool? Active { get; set; }
}
}

