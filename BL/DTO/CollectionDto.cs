using System;
using System.Linq;
using System.Collections.Generic;
using DAL;

namespace BL.DTO
{
    public class CollectionDto
    {
        public System.Guid ID { get; set; }

        public System.Guid Brand_ID { get; set; }

        public string Name { get; set; }

        [NonSerialized] public BrandDto Brand;

        [NonSerialized] public SubCollectionDto SubCollection;

        [NonSerialized] public ICollection<Item> Items;

        public static System.Linq.Expressions.Expression<Func<Collection, CollectionDto>> Entity2DtoSelector = i => new CollectionDto()
        {
            ID = i.ID,
            Name = i.Name,
            Brand_ID = i.Brand_ID,
        };
    }
}