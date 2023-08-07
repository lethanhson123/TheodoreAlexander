using System;

namespace TA.Data2021.Models
{
    public partial class MarketingResourceDetail : BaseModelERP
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public string URL { get; set; }
        public string URLThumbnail { get; set; }
    }
}

