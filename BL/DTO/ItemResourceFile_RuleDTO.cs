using System;
using System.Linq;
using DAL;

namespace BL.DTO
{
    public class ItemResourceFile_RuleDto
    {
        public System.Guid ID { get; set; }

        public System.Guid ItemResourceFile_ID { get; set; }

        public string Rule { get; set; }

        public string Title { get; set; }
        public string Region { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        public string ModifiedBy { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [NonSerialized] public ItemResourceFileDto ItemResourceFile;

        public static System.Linq.Expressions.Expression<Func<ItemResourceFile_Rule, ItemResourceFile_RuleDto>> FromEntityConverterFull = i => new ItemResourceFile_RuleDto()
        {
            ID = i.ID,
            ItemResourceFile_ID = i.ItemResourceFile_ID,
            Rule = i.Rule,
            Region = i.Region,
            Title = i.Title,
            Description = i.Description,
            IsEnabled = i.IsEnabled,
            ModifiedBy = i.ModifiedBy,
            ModifiedDate = i.ModifiedDate,
        };
    }
}