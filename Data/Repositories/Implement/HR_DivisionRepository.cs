using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_DivisionRepository : RepositoryERP<HR_Division>, IHR_DivisionRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_DivisionRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }       
        public HR_Division GetByCode(string code)
        {
            HR_Division result = new HR_Division();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Division>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Division GetByName(string name)
        {
            HR_Division result = new HR_Division();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Division>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

