using System;
namespace TA.Data.Models
{
public partial class Material: BaseModel
{
public Guid? ID { get; set; }
public Guid? MaterialCategory_ID { get; set; }
public string Name { get; set; }
}
}

