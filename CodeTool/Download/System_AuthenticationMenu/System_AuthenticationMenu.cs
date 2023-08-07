using System;
namespace TA.Data.Models
{
public partial class System_AuthenticationMenu: BaseModel
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
public int? MembershipID { get; set; }
public int? MenuID { get; set; }
public bool? IsAllow { get; set; }
public bool? IsDefaults { get; set; }
}
}

