using System;
using System.Linq;
using System.Collections.Generic;
using DAL;

namespace BL.DTO
{
    public class BrandDto
    {
        public System.Guid ID { get; set; }

        public string Name { get; set; }

        [NonSerialized] public ICollection<Collection> Collections;

        [NonSerialized] public ICollection<Country> Countries;

        [NonSerialized] public ICollection<Item> Items;

        [NonSerialized] public ICollection<Store> Stores;

        public static System.Linq.Expressions.Expression<Func<Brand, BrandDto>> Entity2DtoSelector = i => new BrandDto()
        {
            ID = i.ID,
            Name = i.Name,
        };
        public static System.Linq.Expressions.Expression<Func<Brand, BrandDto>> FromEntityConverterFull = i => new BrandDto()
        {
            ID = i.ID,
            Name = i.Name,
            Collections = i.Collections,
            Countries = i.Countries,
            Items = i.Items,
            Stores = i.Stores
        };
    }
}