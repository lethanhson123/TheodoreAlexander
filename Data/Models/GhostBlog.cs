using System;
namespace TA.Data.Models
{
    public partial class GhostBlog : BaseModelERP
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
        public string Author { get; set; }
        public DateTime? DatePost { get; set; }
        public bool? IsBanner { get; set; }
        public bool? IsPopular { get; set; }
        public string DatePostString { get; set; }
        public string ShareFacebook { get; set; }
        public string ShareTwitter { get; set; }
        public string SharePinterest { get; set; }

    }
}

