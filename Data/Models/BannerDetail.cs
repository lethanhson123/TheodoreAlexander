using System;
namespace TA.Data.Models
{
    public partial class BannerDetail : BaseModelERP
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsUSShow { get; set; }
        public bool? IsInternationalShow { get; set; }
        public string Description { get; set; }
        public string QuickTitle { get; set; }
        public string URL { get; set; }
        public string ImageDesktop { get; set; }
        public string ImageMobile { get; set; }
        public string ImageName { get; set; }
        public string URLImageDesktop { get; set; }
        public string URLImageMobile { get; set; }
        public string URLImageName { get; set; }        
    }
}

