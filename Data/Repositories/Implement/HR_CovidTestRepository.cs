using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class HR_CovidTestRepository : RepositoryERP<HR_CovidTest>, IHR_CovidTestRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_CovidTestRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
    }
}

