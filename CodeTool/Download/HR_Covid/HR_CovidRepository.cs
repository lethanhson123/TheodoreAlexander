using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_CovidRepository : Repository<HR_Covid>, IHR_CovidRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_CovidRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

