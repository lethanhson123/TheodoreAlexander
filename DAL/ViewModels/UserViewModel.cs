using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class UserViewModel
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public Guid UserType_ID { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string PostalCode { get; set; }
        public string Address2 { get; set; }
        public string UserTypeName { get; set; }
        public string MailingAddress { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public Guid? City_ID { get; set; }
        public Guid? Region_ID { get; set; }
        public Guid? Country_ID { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public StoreViewModel StoreInfo { get; set; }
        public UserViewModel()
        {
            City_ID = null;
            Region_ID = null;
            Country_ID = null;
        }
    }

    public class UserTypeForRegisterUserViewModel 
    {
        public List<OptionUserTypeForRegisterUserViewModel> UserTypeGroups { get; set; }
        public UserTypeForRegisterUserViewModel()
        {
            UserTypeGroups = new List<OptionUserTypeForRegisterUserViewModel>();
        }
    }
    public class OptionUserTypeForRegisterUserViewModel
    {
        public string Name { get; set; }
        public List<UserTypeSelectOption> UserTypes { get; set; }
        public OptionUserTypeForRegisterUserViewModel()
        {
            UserTypes = new List<UserTypeSelectOption>();
        }
    }
    public class UserTypeSelectOption : UserTypeViewModel
    {
        public Guid ID { get; set; }
    }
    public class RetrieveUserInfoRequest
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }
    }
    public class UserModelModified
    {
        public string ID { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid FirstName")]
        [MaxLength(254, ErrorMessage = "Name cannot be longer than 254 characters.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Invalid LastName")]
        [MaxLength(254, ErrorMessage = "Name cannot be longer than 254 characters.")]
        public string Lastname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityId { get; set; }
        public string PostalCode { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string CurrentPassword { get; set; }
        public string UserType { get; set; }
        public string AccountNumber { get; set; }
    }
    public class PasswordModifiedModel
    {
        [Required(ErrorMessage = "Invalid NewPassword")]
        [MaxLength(254, ErrorMessage = "NewPassword cannot be longer than 254 characters.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Invalid ConfirmPassword")]
        [MaxLength(254, ErrorMessage = "ConfirmPassword cannot be longer than 254 characters.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Invalid CurrentPassword")]
        [MaxLength(254, ErrorMessage = "CurrentPassword cannot be longer than 254 characters.")]
        public string CurrentPassword { get; set; }
    }
}
