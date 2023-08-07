using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_StatusRepository : RepositoryERP<HR_Status>, IHR_StatusRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_StatusRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
     
        public HR_Status GetByCode(string code)
        {
            HR_Status result = new HR_Status();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Status>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Status GetByName(string name)
        {
            HR_Status result = new HR_Status();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Status>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

