using System;
using System.Linq;
using DAL;

namespace BL.DTO
{
    public class AddressDto
    {
        public System.Guid ID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public System.Guid City_ID { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public Nullable<System.Guid> User_ID { get; set; }

        public string Name { get; set; }

        public Nullable<bool> IsVerified { get; set; }

        public Nullable<bool> IsActive { get; set; }

        public Nullable<bool> IsShipping { get; set; }

        public Nullable<bool> IsBilling { get; set; }

        public City City { get; set; }

        public User User { get; set; }

        public static System.Linq.Expressions.Expression<Func<Address, AddressDto>> Entity2DtoSelector = i => new AddressDto()
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
            City = i.City,
            City_ID = i.City.ID,
            User = i.User,
            User_ID = i.User.ID
        };

        public static System.Linq.Expressions.Expression<Func<AddressDto, Address>> Dto2EntitySelector = i => new Address()
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
            City_ID = i.City_ID,
            User_ID = i.User_ID
        };
    }
}