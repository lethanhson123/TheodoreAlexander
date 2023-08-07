using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string Count { get; set; }
        public string Volume { get; set; }
        public string Total { get; set; }
        public IList<ItemsInShoppingCart> LstItem { get; set; }
        public ShoppingCartViewModel()
        {
            Count = "0";
            Volume ="0";
            Total = "0";
            LstItem = new List<ItemsInShoppingCart>();
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
        public bool IsAdd { get; set; } = true;
    }
    public class ItemsInShoppingCart
    {
        public Guid Item_ID { get; set; }
        public string SKU { get; set; }
        public string DefaultCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
        public int QuantityMultiplier { get; set; }
        public bool IsActive { get; set; }
        public double Volume { get; set; }
        public string Colors { get; set; }
        public string DeliveryTime { get; set; }
        public int? MinimumDelay { get; set; }
        public bool InStockProgram { get; set; }
    }
    public class AvailabilityChangedShoppingCartItem:ItemsInShoppingCart
    {
        public bool IsAvailabiliyChanged { get; set; }
        public string NewAvailability { get; set; }
    }
    public class AvailabilityChangedShoppingCart
    {
        public string Count { get; set; }
        public string Volume { get; set; }
        public string Total { get; set; }
        public bool IsAvailabiliyChanged { get; set; }
        public IList<AvailabilityChangedShoppingCartItem> LstItem { get; set; }
        public AvailabilityChangedShoppingCart()
        {
            Count = "0";
            Volume = "0";
            Total = "0";
            IsAvailabiliyChanged = false;
            LstItem = new List<AvailabilityChangedShoppingCartItem>();
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
}
