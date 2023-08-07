using System;
namespace TA.Data.Models
{
    public partial class RoomAndUsage : BaseModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }
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
        public bool? IsMenuShow { get; set; }
        public string Image { get; set; }
        public string ImageURL { get; set; }
        public bool? IsStory { get; set; }
        public string ImageName { get; set; }
        public string URLImageName { get; set; }
    }
}

