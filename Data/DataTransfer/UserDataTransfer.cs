using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class UserDataTransfer : User
    {
        public string DealerGroup { get; set; }
        public string CountryName { get; set; }
        public string ISO { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string UserTypeName { get; set; }
        public Guid? StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreBrand { get; set; }
        public string StoreWebsite { get; set; }
        public float? StorePriceMultiplier { get; set; }
        public string StoreAddress1 { get; set; }
        public string StoreAddress2 { get; set; }
        public string StorePostalCode { get; set; }
        public string StorePhone { get; set; }
        public string StoreFax { get; set; }
        public string TausID { get; set; }
        public string TausName { get; set; }
    }
}
