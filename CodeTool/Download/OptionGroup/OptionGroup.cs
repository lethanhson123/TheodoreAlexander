using System;
namespace TA.Data.Models
{
public partial class OptionGroup: BaseModel
{
public Guid? ID { get; set; }
public string GroupName { get; set; }
public string Name { get; set; }
}
}

