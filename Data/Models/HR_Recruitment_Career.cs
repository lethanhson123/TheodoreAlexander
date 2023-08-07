using System;
namespace TA.Data.Models
{
    public partial class HR_Recruitment_Career : BaseModelERP
    {        
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string MediaSource { get; set; }
        public string JobFunction { get; set; }
        public bool? IsBanner { get; set; }
        public bool? IsFacebook { get; set; }
        public bool? IsZalo { get; set; }
        public bool? IsFriend { get; set; }
        public string RecommendFullName { get; set; }
        public string RecommendPhone { get; set; }
        public string Address { get; set; }
    }
}

