using System;
namespace TA.Data.Models
{
public partial class ShoppingCart_Item_ShippingStatus: BaseModel
{
public Guid? ShoppingCart_ID { get; set; }
public Guid? Item_ID { get; set; }
public Guid? ShippingStatus_ID { get; set; }
public int? Quantity { get; set; }
}
}

