using System;
namespace TA.Data.Models
{
    public partial class System_AuthenticationMenu : BaseModelERP
    {
        public int? MembershipID { get; set; }
        public int? MenuID { get; set; }
        public bool? IsAllow { get; set; }
        public bool? IsDefaults { get; set; }
    }
}

