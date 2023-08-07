using System;
namespace TA.Data.Models
{
    public partial class System_Membership : BaseModelERP
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public Guid? UserID { get; set; }
        public string GUICode { get; set; }
    }
}

