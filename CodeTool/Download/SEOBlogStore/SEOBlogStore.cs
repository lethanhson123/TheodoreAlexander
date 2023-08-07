using System;
namespace TA.Data.Models
{
public partial class SEOBlogStore: BaseModel
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
public string Title { get; set; }
public int? SortCode { get; set; }
public string StoreID { get; set; }
public string Address { get; set; }
public string Phone { get; set; }
public string Email { get; set; }
public string Website { get; set; }
public string Facebook { get; set; }
public string Twitter { get; set; }
}
}

