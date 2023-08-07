using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class DesignerDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public static System.Linq.Expressions.Expression<Func<Designer, DesignerDto>> Entity2DtoSelector = i => new DesignerDto()
        {
            ID = i.ID,
            Name = i.Name,
        };

        public DesignerDto()
        {
        }
    }
}
