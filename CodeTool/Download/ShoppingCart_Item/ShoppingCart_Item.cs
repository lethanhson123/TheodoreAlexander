using System;
namespace TA.Data.Models
{
public partial class ShoppingCart_Item: BaseModel
{
public Guid? ShoppingCart_ID { get; set; }
public Guid? Item_ID { get; set; }
public int? Quantity { get; set; }
public DateTime? DateAdded { get; set; }
}
}

