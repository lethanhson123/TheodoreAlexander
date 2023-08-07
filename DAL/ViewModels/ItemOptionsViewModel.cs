using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ItemOptionGroupViewModel
    {
        public string OptionGroup { get; set; }
        public IOrderedEnumerable<ItemOptionsViewModel> Options { get; set; }
    }
    public class ItemOptionsViewModel
    {
        public string Name { get; set; }
        public string SecondaryName { get; set; }
        public string ID { get; set; }
        public string SKU { get; set; }
        public bool Selected { get; set; }
        public string Filename { get; set; }
        public string Code { get; set; }
    }
    public class ItemOptionsQueryableModel
    {
        public Guid ID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string OptionGroup { get; set; }
        public Guid OptionGroupID { get; set; }
        public bool Selected { get; set; }
        public string Filename { get; set; }
        public string Code { get; set; }
        public string DimensionCm { get; set; }
    }
}
