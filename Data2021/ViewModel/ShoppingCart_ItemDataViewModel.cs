using System;
namespace TA.Data2021.ViewModels
{
    public class ShoppingCart_ItemDataViewModel
    {
        public string ImageURL { get; set; }
        public string URL { get; set; }
        public Guid? ShoppingCart_ID { get; set; }
        public Guid? Item_ID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public double? Volume { get; set; }
        public int? Quantity { get; set; }
        public string Availability { get; set; }
        public decimal? ItemTotal { get; set; }
        public decimal? Price { get; set; }
        public decimal? DesignerPrice { get; set; }
        public decimal? DealerPrice { get; set; }      
    }
}

