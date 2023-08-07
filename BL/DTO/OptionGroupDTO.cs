using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class OptionGroupDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string GroupName { get; set; }

        public static System.Linq.Expressions.Expression<Func<OptionGroup, OptionGroupDto>> Entity2DtoSelector = i => new OptionGroupDto()
        {
            ID = i.ID,
            Name = i.Name,
            GroupName = i.GroupName
        };

        public OptionGroupDto()
        {
        }
    }
}
