using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public class UserEmailDataTransfer
    {
        public string Provider { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }

    }
}
