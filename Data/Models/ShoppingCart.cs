using System;
namespace TA.Data.Models
{
    public partial class ShoppingCart : BaseModel
    {
        public Guid? ID { get; set; }
        public DateTime? DateOrderCreated { get; set; }
        public Guid? UserID { get; set; }
        public decimal? CBMTotal { get; set; }
        public decimal? PriceTotal { get; set; }
        public int? ItemTotal { get; set; }
        public string Code { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ItemCount { get; set; }
        public string Total { get; set; }
        public string Volume { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public string UserTypeName { get; set; }        
        public string ShippingDate { get; set; }
        public string Email { get; set; }        
        public string BillingAddressString { get; set; }
        public string ShippingAddressString { get; set; }
        public string ContainerReference { get; set; }
        public string SpecialInstruction { get; set; }
        public string Phone { get; set; }
        public bool? IsActive { get; set; }
        public string StoreID { get; set; }        
        public string AccountNumber { get; set; }
        public string TausID { get; set; }
    }
}

