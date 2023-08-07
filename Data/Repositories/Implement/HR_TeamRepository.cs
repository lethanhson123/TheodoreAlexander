using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_TeamRepository : RepositoryERP<HR_Team>, IHR_TeamRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_TeamRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
      
        public HR_Team GetByCode(string code)
        {
            HR_Team result = new HR_Team();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Team>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Team GetByName(string name)
        {
            HR_Team result = new HR_Team();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Team>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

