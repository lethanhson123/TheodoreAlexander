using System;
namespace TA.Data2021.Models
{
    public partial class User : BaseModel
    {
        public Guid? ID { get; set; }
        public Guid? UserType_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool? EmailVerified { get; set; }
        public bool? AccountEnabled { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Guid? City_ID { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public bool? ShowSKUs { get; set; }
        public bool? ShowPrice { get; set; }
        public bool? ShowAddress { get; set; }
        public bool? ShowWholesalePrice { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
    }
}

