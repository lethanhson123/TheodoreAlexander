using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BL.DTO
{
    public class StyleDto
    {
        public System.Guid ID { get; set; }

        public string Name { get; set; }

        public Nullable<System.Guid> LifeStyle_ID { get; set; }

        public ICollection<Item> Items { get; set; }

        public LifeStyleDto LifeStyle { get; set; }

        public static System.Linq.Expressions.Expression<Func<Style, StyleDto>> Entity2DtoSelector = i => new StyleDto()
        {
            ID = i.ID,
            Name = i.Name,
        };
    }
}