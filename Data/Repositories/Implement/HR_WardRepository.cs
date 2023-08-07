using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_WardRepository : RepositoryERP<HR_Ward>, IHR_WardRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_WardRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }       
        public HR_Ward GetByCode(string code)
        {
            HR_Ward result = new HR_Ward();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Ward>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Ward GetByName(string name)
        {
            HR_Ward result = new HR_Ward();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Ward>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
        public HR_Ward GetByNameContains(string name)
        {
            HR_Ward result = new HR_Ward();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Ward>().FirstOrDefault(model => model.Name.Contains(name));
            }
            return result;
        }
        public List<HR_Ward> GetBySearchStringToList(string searchString)
        {
            List<HR_Ward> result = new List<HR_Ward>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                result = _context.Set<HR_Ward>().Where(item => item.Name.Contains(searchString)).ToList();
            }
            result = result.OrderBy(item => item.Name).ToList();
            return result;
        }      
    }
}

