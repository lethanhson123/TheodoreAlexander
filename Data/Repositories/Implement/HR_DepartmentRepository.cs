using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_DepartmentRepository : RepositoryERP<HR_Department>, IHR_DepartmentRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_DepartmentRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }       
        public HR_Department GetByCode(string code)
        {
            HR_Department result = new HR_Department();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Department>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Department GetByName(string name)
        {
            HR_Department result = new HR_Department();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Department>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

