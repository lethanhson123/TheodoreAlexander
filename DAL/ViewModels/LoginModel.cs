using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public List<AnonymousWishList> WishListItems { get; set; }
        public LoginModel()
        {
            WishListItems = new List<AnonymousWishList>();
        }
    }
}
