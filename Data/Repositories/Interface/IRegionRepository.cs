using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        public List<Region> GetByCountryIDToList(Guid countryID);
        public List<Region> GetByCountryIDOrSearchStringToList(string countryID, string searchString);
    }
}

