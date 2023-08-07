using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class LocationMaxMind
    {
        public string Country { get; set; }
        public string CountryFullName { get; set; }
        public Guid ContinentId { get; set; }
        public Guid CountryId { get; set; }
    }
}
