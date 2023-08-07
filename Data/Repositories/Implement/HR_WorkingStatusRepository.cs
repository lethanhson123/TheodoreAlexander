using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_WorkingStatusRepository : RepositoryERP<HR_WorkingStatus>, IHR_WorkingStatusRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_WorkingStatusRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }        
        public HR_WorkingStatus GetByCode(string code)
        {
            HR_WorkingStatus result = new HR_WorkingStatus();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_WorkingStatus>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_WorkingStatus GetByName(string name)
        {
            HR_WorkingStatus result = new HR_WorkingStatus();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_WorkingStatus>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

