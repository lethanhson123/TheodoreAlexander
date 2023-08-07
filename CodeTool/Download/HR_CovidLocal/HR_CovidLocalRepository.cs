using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_CovidLocalRepository : Repository<HR_CovidLocal>, IHR_CovidLocalRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_CovidLocalRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

