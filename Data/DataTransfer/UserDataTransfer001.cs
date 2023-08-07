using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class UserDataTransfer001 : User
    {        
        public string CountryName { get; set; }
        public string ISO { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string UserTypeName { get; set; }
    }
}
