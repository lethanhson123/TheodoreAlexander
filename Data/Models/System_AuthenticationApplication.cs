using System;
namespace TA.Data.Models
{
    public partial class System_AuthenticationApplication : BaseModelERP
    {
        public int? MembershipID { get; set; }
        public int? ApplicationID { get; set; }
        public bool? IsAllow { get; set; }
        public bool? IsDefaults { get; set; }
    }
}

