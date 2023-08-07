using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_ProvinceRepository : RepositoryERP<HR_Province>, IHR_ProvinceRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_ProvinceRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public HR_Province GetByCode(string code)
        {
            HR_Province result = new HR_Province();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Province>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Province GetByName(string name)
        {
            HR_Province result = new HR_Province();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Province>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
        public HR_Province GetByNameContains(string name)
        {
            HR_Province result = new HR_Province();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Province>().FirstOrDefault(model => model.Name.Contains(name));
            }
            return result;
        }

        public List<HR_Province> GetBySearchStringToList(string searchString)
        {
            List<HR_Province> result = new List<HR_Province>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                result = _context.Set<HR_Province>().Where(item => item.Name.Contains(searchString)).ToList();
            }
            result = result.OrderBy(item => item.Name).ToList();
            return result;
        }
    }
}

