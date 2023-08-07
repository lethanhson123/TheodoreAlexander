using System;
namespace TA.Data.Models
{
public partial class Store: BaseModel
{
public Guid? ID { get; set; }
public string Name { get; set; }
public string Email { get; set; }
public string Website { get; set; }
public float? PriceMultiplier { get; set; }
public float? PriceMultiplierTAS { get; set; }
public bool? AccountEnabled { get; set; }
public DateTime? DateCreated { get; set; }
public bool? IsPreferred { get; set; }
public string Address1 { get; set; }
public string Address2 { get; set; }
public Guid? City_ID { get; set; }
public string PostalCode { get; set; }
public string Phone { get; set; }
public string Fax { get; set; }
public DateTime? DateModified { get; set; }
public bool? IsAlthorpLivingHistory { get; set; }
public bool? IsAlexaHampton { get; set; }
public bool? IsUpholstery { get; set; }
public bool? IsTAStudio { get; set; }
public bool? IsSalone { get; set; }
public bool? IsRalphLauren { get; set; }
public float? Latitude { get; set; }
public float? Longitude { get; set; }
public string GoogleUrl { get; set; }
public bool? IsActive { get; set; }
}
}

