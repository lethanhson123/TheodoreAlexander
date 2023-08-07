using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class CountItemViewModel
    {
        public Guid RoomId { get; set; }
        public IList<CountGroupByType> Types { get; set; }
        public CountItemViewModel()
        {
            RoomId = new Guid();
            Types = new List<CountGroupByType>();
        }
    }
    public class CountGroupByType
    {
        public Guid TypeId { get; set; }
        public int Count { get; set; }
        public CountGroupByType()
        {
            TypeId = new Guid();
            Count = 0;
        }
    }
    public class CountUPHItemViewModel
    {
        public int UPHCategoryId { get; set; }
        public int Count { get; set; }
        public CountUPHItemViewModel()
        {
            UPHCategoryId = 0;
            Count = 0;
        }
    }
}
