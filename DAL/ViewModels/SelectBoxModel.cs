using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class SelectBoxModel
    {
        public Guid ID { get; set; }
    }
    public class CountrySelectBoxModel: SelectBoxModel
    {
        public string Name { get; set; }
    }
    public class RegionSelectBoxModel: SelectBoxModel
    {
        public string Name { get; set; }
    }
    public class CitySelectBoxModel: SelectBoxModel
    {
        public string Name { get; set; }
    }
    public class CityRegionCountryModel {
        public CitySelectBoxModel City { get; set; }
        public RegionSelectBoxModel Region { get; set; }
        public CountrySelectBoxModel Country { get; set; }
    }
}
