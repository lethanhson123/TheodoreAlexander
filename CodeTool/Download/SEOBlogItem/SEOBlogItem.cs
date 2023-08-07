using System;
namespace TA.Data.Models
{
public partial class SEOBlogItem: BaseModel
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
public string ItemID { get; set; }
public string Description { get; set; }
public string Image { get; set; }
public string URLImage { get; set; }
}
}

