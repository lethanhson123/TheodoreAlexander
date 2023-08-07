using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TA_Web_2020_API.ViewModel
{
    public class OrderViewModel
    {
        public string ContainerReference { get; set; }
        public DateTime OrderDate { get; set; }
        public string SpecialInstruction { get; set; }
        public String OrderBy { get; set; }
        public List<string> ShippingDate { get; set; }
        public string ShippingAddressString { get; set; }
        public string BillingAddressString { get; set; }
        public string StoreID { get; set; }
        public string TausID { get; set; }
        public Guid ShoppingCartId { get; set; }
        public BL.DTO.ShoppingCartViewModel ShoppingCartInfos { get; set; }
        public OrderViewModel()
        {
            ShoppingCartId = Guid.Empty;
        }

        public static System.Linq.Expressions.Expression<Func<OrderDto, OrderViewModel>> Dto2ViewModelSelector = i => new OrderViewModel()
        {
            BillingAddressString = i.BillingAddressString,
            ContainerReference = i.ContainerReference,
            StoreID = i.StoreID,
            TausID = i.TausID,
            OrderBy = i.OrderBy,
            OrderDate = i.OrderDate,
            ShippingAddressString = i.ShippingAddressString,
            ShippingDate = i.ShippingDate,
            ShoppingCartId = i.ShoppingCartId,
            ShoppingCartInfos = i.ShoppingCartInfos,
            SpecialInstruction = i.SpecialInstruction,
        };


        public static System.Linq.Expressions.Expression<Func<OrderViewModel, OrderDto>> ViewModel2DtoSelector = i => new OrderDto()
        {
            BillingAddressString = i.BillingAddressString,            
            ContainerReference = i.ContainerReference,
            StoreID = i.StoreID,
            TausID = i.TausID,
            OrderBy = i.OrderBy,
            OrderDate = i.OrderDate,
            ShippingAddressString = i.ShippingAddressString,
            ShippingDate = i.ShippingDate,
            ShoppingCartId = i.ShoppingCartId,
            ShoppingCartInfos = i.ShoppingCartInfos,
            SpecialInstruction = i.SpecialInstruction,
        };
    }
}
