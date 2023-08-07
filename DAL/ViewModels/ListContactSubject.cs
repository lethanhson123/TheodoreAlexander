using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ListContactSubject
    {
        public List<ContactSubjectViewModel> Subjects { get; set; }
        public ListContactSubject()
        {
            Subjects = new List<ContactSubjectViewModel>();
        }
    }
    public class ContactSubjectViewModel
    {
        public string Name { get; set; }
        public ContactSubjectViewModel()
        {
            Name = string.Empty;
        }
    }

    public class RalphLaurenInquiriesModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required or invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Business Name is required")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Daytime Phone is required")]
        public string DaytimePhone { get; set; }
        [Required(ErrorMessage = "State / Province is required")]
        public string StateProvince { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zip / Postal Code is required")]
        public string ZipPostalCode { get; set; }
        public string Message { get; set; }
    }
    public class ContactRequestObj
    {
        [Required(ErrorMessage = "The subject cannot be empty.")]
        public string Subject { get; set; }
        public string SKU { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }

    public class ApplyJobVNCandidatetObj
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DesiredJob { get; set; }
        public string MediaSources { get; set; }
        public string Experience { get; set; }
    }
}
