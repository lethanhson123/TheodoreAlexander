using System;
namespace TA.Data2021.Models
{
    public partial class Dealer_Taus : BaseModel
    {
        public Guid UserID { get; set; }
        public string TausID { get; set; }
        public string TausName { get; set; }       
    }
}

