using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_DutyRepository : RepositoryERP<HR_Duty>, IHR_DutyRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_DutyRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }       
        public HR_Duty GetByCode(string code)
        {
            HR_Duty result = new HR_Duty();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Duty>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Duty GetByName(string name)
        {
            HR_Duty result = new HR_Duty();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Duty>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

