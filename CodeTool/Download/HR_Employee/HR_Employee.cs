using System;
namespace TA.Data.Models
{
public partial class HR_Employee: BaseModel
{
public int? ID { get; set; }
public string UserCreated { get; set; }
public DateTime? DateCreated { get; set; }
public string UserUpdated { get; set; }
public DateTime? DateUpdated { get; set; }
public bool? Active { get; set; }
public int? RowVersion { get; set; }
public int? ParentID { get; set; }
public string CodeManage { get; set; }
public string Note { get; set; }
public string Code { get; set; }
public string AttendanceCard { get; set; }
public string FullName { get; set; }
public int? Gender { get; set; }
public string Phone { get; set; }
public string Address { get; set; }
public string AddressProvisional { get; set; }
public string AddressContact { get; set; }
public string AddressContactProvince { get; set; }
public string AddressContactDistrict { get; set; }
public string AddressContactWard { get; set; }
public int? AddressContactProvinceID { get; set; }
public int? AddressContactDistrictID { get; set; }
public int? AddressContactWardID { get; set; }
public DateTime? BirthDate { get; set; }
public string BirthPlace { get; set; }
public string BirthNativePlace { get; set; }
public int? BirthPlaceID { get; set; }
public int? BirthNativePlaceID { get; set; }
public string IDCard { get; set; }
public string IDCardIssued { get; set; }
public int? IDCardIssuedID { get; set; }
public DateTime? IDCardDate { get; set; }
}
}

