using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class OrderDto
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
        public OrderDto()
        {
            ShoppingCartId = Guid.Empty;
        }
    }
}
