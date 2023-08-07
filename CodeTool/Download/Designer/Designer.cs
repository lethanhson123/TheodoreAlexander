using System;
namespace TA.Data.Models
{
public partial class Designer: BaseModel
{
public Guid? ID { get; set; }
public string Name { get; set; }
public string URLCode { get; set; }
public string URL { get; set; }
public int? GroupCode { get; set; }
public int? SortCode { get; set; }
public int? ItemCount { get; set; }
public bool? IsActive { get; set; }
public string Description { get; set; }
public string METAKeyword { get; set; }
public string METADescription { get; set; }
public string Title001 { get; set; }
public string Title002 { get; set; }
public string DisplayName { get; set; }
public string ImageIcon { get; set; }
public string ImageMain { get; set; }
public string ImageBackground { get; set; }
public string URLImageIcon { get; set; }
public string URLImageMain { get; set; }
public string URLImageBackground { get; set; }
public string DescriptionLong { get; set; }
}
}

