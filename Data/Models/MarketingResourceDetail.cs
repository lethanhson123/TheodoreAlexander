using System;
namespace TA.Data.Models
{
    public partial class MarketingResourceDetail : BaseModelERP
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public string URL { get; set; }
        public string URLThumbnail { get; set; }
        public bool? IsUSShow { get; set; }
        public bool? IsInternationalShow { get; set; }
    }
}

