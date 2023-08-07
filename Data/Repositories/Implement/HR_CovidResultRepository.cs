using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class HR_CovidResultRepository : RepositoryERP<HR_CovidResult>, IHR_CovidResultRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_CovidResultRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
    }
}

