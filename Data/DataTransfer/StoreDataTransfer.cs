using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class StoreDataTransfer : Store
    {
        public string NameHTML { get; set; }
        public string PhoneHTML { get; set; }
        public string AddressHTML { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string ContinentName { get; set; }
        public string Address { get; set; }        
    }
}
