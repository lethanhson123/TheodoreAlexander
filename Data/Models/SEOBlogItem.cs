using System;
namespace TA.Data.Models
{
    public partial class SEOBlogItem : BaseModelERP
    {

        public string Code { get; set; }
        public string Title { get; set; }
        public int? SortCode { get; set; }
        public string ItemID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string URLImage { get; set; }
        public string TypeID { get; set; }
    }
}

