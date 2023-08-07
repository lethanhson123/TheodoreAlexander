using System;

namespace TA.Data2021.Models
{
    public partial class MarketingResourceCategory : BaseModelERP
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
    }
}

