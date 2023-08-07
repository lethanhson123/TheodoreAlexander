using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_CovidTypeRepository : Repository<HR_CovidType>, IHR_CovidTypeRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_CovidTypeRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

