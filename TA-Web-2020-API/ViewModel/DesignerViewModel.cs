using BL.DTO;
using System;

namespace TA_Web_2020_API.ViewModel
{
    public class DesignerViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public static System.Linq.Expressions.Expression<Func<DesignerDto, DesignerViewModel>> fromDTO = i => new DesignerViewModel()
        {
            ID = i.ID,
            Name = i.Name,
        };
    }
}