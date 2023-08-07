using System;
namespace TA.Data.Models
{
    public partial class SEOKeyword : BaseModelERP
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? SortCode { get; set; }
    }
}

