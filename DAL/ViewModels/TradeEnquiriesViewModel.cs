using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class TradeEnquiriesViewModel
    {
        // Contact info
        [Required(ErrorMessage = "Name cannot be empty")]
        [MaxLength(254, ErrorMessage = "Name cannot be longer than 254 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }

        // Store info
        [Required(ErrorMessage = "Store name cannot be empty")]
        [MaxLength(254, ErrorMessage = "Store name cannot be longer than 254 characters.")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Your end consumer cannot be empty")]
        [MaxLength(254, ErrorMessage = "Your end consumer cannot be longer than 254 characters.")]
        public string EndConsumer { get; set; }

        [Required(ErrorMessage = "Number of stores cannot be empty")]
        //[MaxLength(12)]
        //[MinLength(1)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Number of stores must be numeric")]
        public int NumberOfStores { get; set; }
        public string PositionAtPrimaryStore { get; set; }
        public string StoreWebAddress { get; set; }

        [Required(ErrorMessage = "Address Line 1 cannot be empty")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City cannot be empty")]
        [MaxLength(254, ErrorMessage = "City cannot be longer than 254 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country cannot be empty")]
        [MaxLength(254, ErrorMessage = "Country cannot be longer than 254 characters.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State/Province cannot be empty")]
        [MaxLength(254, ErrorMessage = "State/Province cannot be longer than 254 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip/Postal code cannot be empty")]
        public int ZipCode { get; set; }

        public string Questions { get; set; }
    }
}
