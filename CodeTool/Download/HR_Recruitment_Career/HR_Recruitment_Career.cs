using System;
namespace TA.Data.Models
{
public partial class HR_Recruitment_Career: BaseModel
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
public string Experience{ get; set; }
public string MediaSource{ get; set; }
public string JobFunction{ get; set; }
}
}

