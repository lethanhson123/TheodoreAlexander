using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BL.Dto
{
    public class TypeDto
    {
        public System.Guid ID { get; set; }

        public string Name { get; set; }

        public Nullable<System.Guid> RoomAndUsage_ID { get; set; }

        public Nullable<int> Order { get; set; }

        public Nullable<bool> IsEnabledOnWeb { get; set; }

        public string WebURL { get; set; }

        public ICollection<Item> Items { get; set; }

        public RoomAndUsageDto RoomAndUsage { get; set; }

        public static System.Linq.Expressions.Expression<Func<DAL.Type, TypeDto>> Entity2DtoSelector = i => new TypeDto()
        {
            ID = i.ID,
            Name = i.Name,
            Order = i.Order,
            IsEnabledOnWeb = i.IsEnabledOnWeb,
            WebURL = i.WebURL,
        };
    }
}