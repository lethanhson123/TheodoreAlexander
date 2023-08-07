using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_CovidTestRepository : Repository<HR_CovidTest>, IHR_CovidTestRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_CovidTestRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

