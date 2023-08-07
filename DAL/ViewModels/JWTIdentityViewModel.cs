using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class JWTIdentityViewModel
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public Guid? CountryId { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CountryFullName { get; set; }
        public bool IsShowInStock { get; set; }
        public Guid? ContinentId { get; set; }
        public Guid? ExclusivityGroupId { get; set; }
        public string RequestIpAddress { get; set; }
        public string ResponseIpAddress { get; set; }
    }
}
