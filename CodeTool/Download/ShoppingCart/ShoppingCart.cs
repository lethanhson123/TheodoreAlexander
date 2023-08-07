using System;
namespace TA.Data.Models
{
public partial class ShoppingCart: BaseModel
{
public Guid? ID { get; set; }
public DateTime? DateOrderCreated { get; set; }
public Guid? UserID { get; set; }
}
}

