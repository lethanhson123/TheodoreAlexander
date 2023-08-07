using System;
namespace TA.Data.Models
{
    public partial class SEOBlogStore : BaseModelERP
    {

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

