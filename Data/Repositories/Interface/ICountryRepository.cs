using System;
using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        public Country GetByID(Guid ID);
        public List<Country> GetBySearchStringToList(string searchString);
    }
}

