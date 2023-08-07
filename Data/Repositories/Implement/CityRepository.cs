using System;
using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public CityRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<City> GetByRegionIDToList(Guid regionID)
        {
            var result = _context.Set<City>().Where(model => model.Region_ID == regionID).OrderBy(model => model.Name).ToList();
            return result;
        }
        public List<City> GetBySearchStringToList(string searchString)
        {
            var result = _context.Set<City>().Where(model => model.Name.Contains(searchString)).OrderBy(model => model.Name).ToList();
            return result;
        }
        public List<City> GetByRegionIDOrSearchStringToList(string regionID, string searchString)
        {
            List<City> result = new List<City>();
            if (string.IsNullOrEmpty(searchString))
            {
                if (!string.IsNullOrEmpty(regionID))
                {
                    regionID = regionID.Trim();
                    result = GetByRegionIDToList(Guid.Parse(regionID));
                }
            }
            else
            {
                searchString = searchString.Trim();
                result = GetBySearchStringToList(searchString);
            }
            return result;
        }
    }
}

