using System;
namespace TA.Data.Models
{
public partial class Country: BaseModel
{
public Guid? ID { get; set; }
public Guid? Continent_ID { get; set; }
public string Name { get; set; }
public string ISO { get; set; }
public string ISO3 { get; set; }
public int? ISONumeric { get; set; }
public string fips { get; set; }
public string Capital { get; set; }
public int? AreaSqrKM { get; set; }
public int? Population { get; set; }
public string Continent { get; set; }
public string tld { get; set; }
public string CurrencyCode { get; set; }
public string CurrencyName { get; set; }
public string Phone { get; set; }
public string PostalCodeFormat { get; set; }
public string PostalCodeRegex { get; set; }
public string Languages { get; set; }
}
}

