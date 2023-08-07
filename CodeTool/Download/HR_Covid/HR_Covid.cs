using System;
namespace TA.Data.Models
{
public partial class HR_Covid: BaseModel
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
public int? EmployeeID { get; set; }
public string EmployeeCode { get; set; }
public int? CovidTypeID { get; set; }
public int? CovidLocalID { get; set; }
public int? CovidTestID { get; set; }
public int? CovidResultID { get; set; }
public DateTime? CovidTestDate { get; set; }
public string IsolationLocal { get; set; }
public DateTime? IsolationDateBegin { get; set; }
public DateTime? IsolationDateEnd { get; set; }
public string AddressContact { get; set; }
public string AddressContactProvince { get; set; }
public string AddressContactDistrict { get; set; }
public string AddressContactWard { get; set; }
}
}

