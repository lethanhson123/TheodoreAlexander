using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BL.DTO
{
    public class LifeStyleDto
    {
        public System.Guid ID { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<Style> Styles { get; set; }

        public static System.Linq.Expressions.Expression<Func<LifeStyle, LifeStyleDto>> Entity2DtoSelector = i => new LifeStyleDto() {
            ID = i.ID,
            Name = i.Name
        };
    }
}