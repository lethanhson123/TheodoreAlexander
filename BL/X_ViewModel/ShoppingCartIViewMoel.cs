using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ShoppingCartViewModel
    {
        public string Count { get; set; }
        public string Volume { get; set; }
        public string Total { get; set; }
        public IList<ShoppingCartItemViewMoel> LstItem { get; set; }
        public ShoppingCartViewModel()
        {
            Count = "0";
            Volume = "0";
            Total = "0";
            LstItem = new List<ShoppingCartItemViewMoel>();
        }
    }
    public class AddToCardRequestObj
    {
        [Required]
        public Guid? ItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int QuantityMultiplier { get; set; }
        public bool IsAdd { get; set; }
    }
    public class ShoppingCartItemViewMoel : ItemDto
    {
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
        public double Volume { get; set; }
        public bool IsAvailabiliyChanged { get; set; }
        public string NewAvailability { get; set; }

        public ShoppingCartItemViewMoel(Item item) : base(item)
        {
        }
    }
    public class AvailabilityChangedShoppingCart : ShoppingCartViewModel
    {
        public bool IsAvailabiliyChanged { get; set; }
        public AvailabilityChangedShoppingCart()
        {
            Count = "0";
            Volume = "0";
            Total = "0";
            IsAvailabiliyChanged = false;
            LstItem = new List<ShoppingCartItemViewMoel>();
        }
    }
    public class Inventories
    {
        public Guid Item_ID { get; set; }
        public Guid ShippingStatus_ID { get; set; }
        public string DeliveryTime { get; set; }
        public int MinimumDelay { get; set; }
        public int Quantity { get; set; }
    }

    //public class OrderedOrderInfos
    //{
    //    public string ContainerReference { get; set; }
    //    public DateTime OrderDate { get; set; }
    //    public string SpecialInstruction { get; set; }
    //    public string BillingAddressString { get; set; }
    //    public string ShippingAddressString { get; set; }
    //    public ShoppingCartViewModel ShoppingCartInfos { get; set; }
    //    public String OrderBy { get; set; }
    //    public List<string> ShippingDates { get; set; }
    //    public Guid ShoppingCartId { get; set; }
    //    public OrderedOrderInfos()
    //    {
    //        ShoppingCartId = Guid.Empty;
    //    }
    //}
}
