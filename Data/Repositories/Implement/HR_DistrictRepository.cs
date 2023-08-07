using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_DistrictRepository : RepositoryERP<HR_District>, IHR_DistrictRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_DistrictRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }        
        public HR_District GetByCode(string code)
        {
            HR_District result = new HR_District();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_District>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_District GetByName(string name)
        {
            HR_District result = new HR_District();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_District>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
        public HR_District GetByNameContains(string name)
        {
            HR_District result = new HR_District();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_District>().FirstOrDefault(model => model.Name.Contains(name));
            }
            return result;
        }
        public List<HR_District> GetBySearchStringToList(string searchString)
        {
            List<HR_District> result = new List<HR_District>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                result = _context.Set<HR_District>().Where(item => item.Name.Contains(searchString)).ToList();
            }
            result = result.OrderBy(item => item.Name).ToList();
            return result;
        }        
    }
}

