using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_GroupRepository : RepositoryERP<HR_Group>, IHR_GroupRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_GroupRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }        
        public HR_Group GetByCode(string code)
        {
            HR_Group result = new HR_Group();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Group>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Group GetByName(string name)
        {
            HR_Group result = new HR_Group();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Group>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

