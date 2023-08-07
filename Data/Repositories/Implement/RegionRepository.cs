using System;
using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public RegionRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public List<Region> GetByCountryIDToList(Guid countryID)
        {
            var result = _context.Set<Region>().Where(model => model.Country_ID == countryID).OrderBy(model => model.Name).ToList();
            return result;
        }
        public List<Region> GetBySearchStringToList(string searchString)
        {
            var result = _context.Set<Region>().Where(model => model.Name.Contains(searchString)).OrderBy(model => model.Name).ToList();
            return result;
        }
        public List<Region> GetByCountryIDOrSearchStringToList(string countryID, string searchString)
        {
            List<Region> result = new List<Region>();
            if (string.IsNullOrEmpty(searchString))
            {
                if (!string.IsNullOrEmpty(countryID))
                {
                    countryID = countryID.Trim();
                    result = GetByCountryIDToList(Guid.Parse(countryID));
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

