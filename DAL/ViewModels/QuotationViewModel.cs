using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class QuotationViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Designer { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public string Types { get; set; }
        public string Detail { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string ExpressionTheme { get; set; }
        public string Themes { get; set; }
        public string Style { get; set; }
        public string City { get; set; }
        public string ST_Abbr { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Rep { get; set; }
        public string DateSent2Rep { get; set; }
        public string Dealer { get; set; }
        public string DealerEmail { get; set; }
        public string DealerStore { get; set; }
        public string DateSent2Dealer { get; set; }
        public string Comment { get; set; }
        public string DateDealerContactedConsumer { get; set; }
        public string Address { get; set; }
        public bool IsWishListItem { get; set; } = false;
        public IList<WishListItemQuotation> WishListItems { get; set; }
    }
    public class WishListItemQuotation
    {
        public string SKU { get; set; }
        public Guid ID { get; set; }
        public string ProductName { get; set; }
    }
    public class RequestQuoteObj
    {
        public string Item { get; set; }
        public Guid ItemId { get; set; }
        public string Brand { get; set; }
        public string Collection { get; set; }
        public string RoomAndUsage { get; set; }
        public string ProductType { get; set; }
        public string LifeStyle { get; set; }
        public string ProductStyle { get; set; }
        public bool Designer { get; set; }
        public bool IsSendCopy { get; set; }
        public string PreferredContactMedia { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [MaxLength(254, ErrorMessage = "Name cannot be longer than 254 characters.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        public string Detail { get; set; }

        [Required(ErrorMessage = "City cannot be empty")]
        [MaxLength(254, ErrorMessage = "City cannot be longer than 254 characters.")]
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Country cannot be empty")]
        [MaxLength(254, ErrorMessage = "Country cannot be longer than 254 characters.")]
        public string Country { get; set; }
        public string Types { get; set; }
        public bool IsWishListItem { get; set; } = false;
        public string Address { get; set; }
        public IList<WishListItemQuotation> WishListItems { get; set; }
    }
}
