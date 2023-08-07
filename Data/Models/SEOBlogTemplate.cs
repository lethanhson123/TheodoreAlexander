using System;
namespace TA.Data.Models
{
    public partial class SEOBlogTemplate : BaseModelERP
    {

        public string Code { get; set; }
        public string Title { get; set; }
        public string HTMLContent { get; set; }
        public string URLCode { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string METAKeyword { get; set; }
        public string METADescription { get; set; }
        public string URLImage { get; set; }
    }
}

