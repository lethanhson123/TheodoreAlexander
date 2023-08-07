using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class HR_CovidTypeRepository : RepositoryERP<HR_CovidType>, IHR_CovidTypeRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_CovidTypeRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
    }
}

