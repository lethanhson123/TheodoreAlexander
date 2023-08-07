using System;
namespace TA.Data.Models
{
    public partial class SEOBlog : BaseModelERP
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
        public string Keyword { get; set; }
        public int? SEOBlogTemplateID { get; set; }
        public string CountryID { get; set; }
        public string RegionID { get; set; }
        public string CityID { get; set; }
        public int? KeywordID { get; set; }
        public string DesignerID { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string SEOBlogTemplateContent { get; set; }
        public string DesignerContent { get; set; }
        public string DesignerImage { get; set; }
        public string URLDesignerImage { get; set; }
        public string SEOBlogTemplateImage { get; set; }
        public string URLSEOBlogTemplateImage { get; set; }
        public string DesignerName { get; set; }
    }
}

