using System;
namespace TA.Data.Models
{
public partial class HR_Recruitment_Introduce: BaseModel
{
public int ID{ get; set; }
public string UserCreated{ get; set; }
public DateTime DateCreated{ get; set; }
public string UserUpdated{ get; set; }
public DateTime DateUpdated{ get; set; }
public bool Active{ get; set; }
public int RowVersion{ get; set; }
public int ParentID{ get; set; }
public string CodeManage{ get; set; }
public string FullName{ get; set; }
public string Phone{ get; set; }
public string Email{ get; set; }
public string BạnkID{ get; set; }
public string BankName{ get; set; }
public string CandidateFullName{ get; set; }
public string CandidatePhone{ get; set; }
}
}

