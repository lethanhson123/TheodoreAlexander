using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class SubcribedEmailResigterObj
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }
    }
    public class SubcribedEmailViewModel
    {
        public string Email { get; set; }
    }
}
