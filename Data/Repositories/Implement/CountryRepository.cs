using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public CountryRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public Country GetByID(Guid ID)
        {
            Country result = _context.Set<Country>().AsNoTracking().FirstOrDefault(model => model.ID == ID);
            if (result == null)
            {
                result = new Country();
                result.ID = ID;
            }
            return result;
        }
        public override List<Country> GetAllToList()
        {
            var result = _context.Set<Country>().OrderBy(model => model.Name).ToList();
            return result;
        }
        public List<Country> GetBySearchStringToList(string searchString)
        {
            List<Country> result = new List<Country>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                searchString = searchString.Trim();
                result = _context.Set<Country>().Where(model => model.Name.Contains(searchString) || model.ISO.Contains(searchString) || model.Continent.Contains(searchString)).OrderBy(model => model.Name).ToList();
            }
            return result;
        }
    }
}

