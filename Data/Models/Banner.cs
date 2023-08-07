using System;
namespace TA.Data.Models
{
    public partial class Banner : BaseModelERP
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsUSShow { get; set; }
        public bool? IsInternationalShow { get; set; }
        public int? Timer { get; set; }
    }
}

