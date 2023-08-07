using System;
namespace TA.Data.Models
{
public partial class HR_Employee_HistoryWork: BaseModel
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
public DateTime? DateJoined { get; set; }
public DateTime? DateLeft { get; set; }
public int? DivisionID { get; set; }
public string DivisionCode { get; set; }
public int? StatusID { get; set; }
public string StatusCode { get; set; }
public string StatusName { get; set; }
public int? DepartmentID { get; set; }
public string DepartmentCode { get; set; }
public string DepartmentName { get; set; }
public int? BlockNameID { get; set; }
public string BlockName { get; set; }
public int? TeamNameID { get; set; }
public int? GroupNameID { get; set; }
public string TeamName { get; set; }
public string GroupName { get; set; }
public int? DutyID { get; set; }
public string DutyCode { get; set; }
public string DutyName { get; set; }
public string WorkingStatusName { get; set; }
}
}

