using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_CovidResultRepository : Repository<HR_CovidResult>, IHR_CovidResultRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_CovidResultRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

