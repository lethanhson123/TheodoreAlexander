using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        public List<City> GetByRegionIDToList(Guid regionID);
        public List<City> GetByRegionIDOrSearchStringToList(string regionID, string searchString);
    }
}

