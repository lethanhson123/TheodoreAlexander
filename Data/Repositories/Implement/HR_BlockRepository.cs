using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class HR_BlockRepository : RepositoryERP<HR_Block>, IHR_BlockRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_BlockRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        
        public HR_Block GetByCode(string code)
        {
            HR_Block result = new HR_Block();
            if (!string.IsNullOrEmpty(code))
            {
                result = _context.Set<HR_Block>().FirstOrDefault(model => model.Code == code);
            }
            return result;
        }
        public HR_Block GetByName(string name)
        {
            HR_Block result = new HR_Block();
            if (!string.IsNullOrEmpty(name))
            {
                result = _context.Set<HR_Block>().FirstOrDefault(model => model.Name == name);
            }
            return result;
        }
    }
}

