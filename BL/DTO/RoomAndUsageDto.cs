using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BL.Dto
{
    public class RoomAndUsageDto
    {
        public System.Guid ID { get; set; }

        public string Name { get; set; }

        public Nullable<int> Order { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<DAL.Type> Types { get; set; }

        public static System.Linq.Expressions.Expression<Func<RoomAndUsage, RoomAndUsageDto>> Entity2DtoSelector = i => new RoomAndUsageDto()
        {
            ID = i.ID,
            Name = i.Name,
            Order = i.Order
        };
    }
}