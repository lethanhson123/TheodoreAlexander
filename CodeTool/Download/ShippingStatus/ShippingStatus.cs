using System;
namespace TA.Data.Models
{
public partial class ShippingStatus: BaseModel
{
public Guid? ID { get; set; }
public string DeliveryTime { get; set; }
public string DeliveryState { get; set; }
public int? MinimumDelay { get; set; }
}
}

