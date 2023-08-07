using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class RegisterUserObj
    {
        [Required(ErrorMessage = "User profile cannot be empty")]
        
        public Guid UserType_ID { get; set; }

        //[Required(ErrorMessage = "Username cannot be empty")]
        //[MaxLength(254, ErrorMessage = "Username cannot be longer than 254 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [MaxLength(254, ErrorMessage = "Password cannot be longer than 254 characters.")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Firstname cannot be empty")]
        [MaxLength(254, ErrorMessage = "Firstname cannot be longer than 254 characters.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname cannot be empty")]
        [MaxLength(254, ErrorMessage = "Lastname cannot be longer than 254 characters.")]
        public string Lastname { get; set; }
        public bool EmailVerified { get; set; }
        public bool AccountEnabled { get; set; }
        public DateTime DateCreated { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Guid? City_ID { get; set; }
        public string PostalCode { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public bool IsEmailSubscribed { get; set; }
        public List<AnonymousWishList> WishListItems { get; set; }
        public RegisterUserObj()
        {
            WishListItems = new List<AnonymousWishList>();
        }
    }
}
