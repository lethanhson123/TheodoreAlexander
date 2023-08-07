using TA.Data.Models;
namespace TA.Data.Repositories
{
    public class HR_CovidLocalRepository : RepositoryERP<HR_CovidLocal>, IHR_CovidLocalRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_CovidLocalRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
    }
}

