using System;
namespace TA.Data.Models
{
public partial class UPHFabric: BaseModel
{
public string Fabric { get; set; }
public int? Grade { get; set; }
public string GradeStudio { get; set; }
public string Content1 { get; set; }
public string Content2 { get; set; }
public string Content3 { get; set; }
public string Content4 { get; set; }
public string Content5 { get; set; }
public string Content6 { get; set; }
public string Sampled { get; set; }
public string Color { get; set; }
public string ColorCode { get; set; }
public string Pattern { get; set; }
public string PatternCode { get; set; }
public string VRepeat { get; set; }
public string HRepeat { get; set; }
public string Width { get; set; }
public string CleaningCode { get; set; }
public string Application { get; set; }
public string Durability { get; set; }
public bool? enable { get; set; }
public DateTime? CreatedDate { get; set; }
public bool? InStock { get; set; }
public bool? IsEnabledOnWeb { get; set; }
public bool? IsCutYardage { get; set; }
public string Name { get; set; }
public bool? RLC { get; set; }
public string GradeTrim { get; set; }
public string Category { get; set; }
public string CategoryTrim { get; set; }
public string Rubs { get; set; }
public decimal? QtyOnHand { get; set; }
public string UM { get; set; }
public bool? PFP { get; set; }
}
}

