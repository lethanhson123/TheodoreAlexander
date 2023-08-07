using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TA_Web_2020_API.ViewModel
{
    public class AddressViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsShipping { get; set; }
        public bool IsBilling { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string City { get; set; }
        public Guid CityId { get; set; }
        public string Region { get; set; }
        public Guid RegionId { get; set; }
        public string Country { get; set; }
        public Guid CountryId { get; set; }
        public Guid UserId { get; set; }

        public static System.Linq.Expressions.Expression<Func<AddressDto, AddressViewModel>> Dto2ViewModelSelector = i => new AddressViewModel()
        {
            ID = i.ID,
            Name = i.Name,
            IsShipping = i.IsShipping ?? false,
            IsBilling = i.IsBilling ?? false,
            IsVerified = i.IsVerified ?? false,
            IsActive = i.IsActive ?? false,
            AddressLine1 = i.AddressLine1,
            AddressLine2 = i.AddressLine2,
            PostalCode = i.PostalCode,
            Phone = i.Phone,
            Fax = i.Fax,
            City = i.City.Name,
            CityId = i.City.ID,
            Region = i.City.Region.Name,
            RegionId = i.City.Region.ID,
            Country = i.City.Region.Country.Name,
            CountryId = i.City.Region.Country.ID,
            UserId = i.User.ID
        };

        public static System.Linq.Expressions.Expression<Func<AddressViewModel, AddressDto>> ViewModel2DtoSelector = i => new AddressDto()
        {
            ID = i.ID,
            Name = i.Name,
            IsShipping = i.IsShipping,
            IsBilling = i.IsBilling,
            IsVerified = i.IsVerified,
            IsActive = i.IsActive,
            AddressLine1 = i.AddressLine1,
            AddressLine2 = i.AddressLine2,
            PostalCode = i.PostalCode,
            Phone = i.Phone,
            Fax = i.Fax,
            City_ID = i.CityId,
            User_ID = i.UserId
        };
    }
}

