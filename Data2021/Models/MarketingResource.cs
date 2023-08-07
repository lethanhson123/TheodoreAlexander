using System;
namespace TA.Data2021.Models
{
    public partial class MarketingResource : BaseModelERP
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsUSShow { get; set; }
        public bool? IsInternationalShow { get; set; }
        public string URL { get; set; }
        public bool? IsDealerShow { get; set; }
        public bool? IsDesignerShow { get; set; }
    }
}

