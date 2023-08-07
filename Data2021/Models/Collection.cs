using System;
namespace TA.Data2021.Models
{
    public partial class Collection : BaseModel
    {
        public Guid ID { get; set; }
        public Guid? Brand_ID { get; set; }
        public string Name { get; set; }
        public string URLCode { get; set; }
        public string URL { get; set; }
        public int? GroupCode { get; set; }
        public int? SortCode { get; set; }
        public int? ItemCount { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public string METAKeyword { get; set; }
        public string METADescription { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string ImageURL { get; set; }
    }
}

