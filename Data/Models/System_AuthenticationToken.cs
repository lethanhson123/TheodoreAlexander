using System;
namespace TA.Data.Models
{
    public partial class System_AuthenticationToken : BaseModelERP
    {
        public int? MembershipID { get; set; }
        public int? ApplicationID { get; set; }
        public string AuthenticationToken { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}

