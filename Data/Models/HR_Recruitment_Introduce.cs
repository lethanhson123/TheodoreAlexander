using System;
namespace TA.Data.Models
{
    public partial class HR_Recruitment_Introduce : BaseModelERP
    {        
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BankID { get; set; }
        public string BankName { get; set; }        
    }
}

