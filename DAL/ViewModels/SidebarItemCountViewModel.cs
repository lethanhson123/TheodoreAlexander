using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class SidebarItemCountViewModel
    {
        public List<CountViewModel> ListCount { get; set; }
    }
    public class CountViewModel
    {
        public string ID { get; set; }
        public int Count { get; set; } = 0;
        public string Name { get; set; }
    }
}
