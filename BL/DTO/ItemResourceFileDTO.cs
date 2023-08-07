using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BL.DTO
{
    public class ItemResourceFileDto
    {
        public System.Guid ID { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string URL { get; set; }

        public string Property { get; set; }

        public string ModifiedBy { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [NonSerialized] public ICollection<ItemResourceFile_Rule> ItemResourceFile_Rule;

        public static System.Linq.Expressions.Expression<Func<ItemResourceFile, ItemResourceFileDto>> DTOFromEntityConverter = i => new ItemResourceFileDto()
        {
            ID = i.ID,
            Name = i.Name,
            Category = i.Category,
            IsEnabled = i.IsEnabled,
            Title = i.Title,
            URL = i.URL,
            ModifiedBy = i.ModifiedBy,
            ModifiedDate = i.ModifiedDate,
            Property = i.Property
        };
    }
}