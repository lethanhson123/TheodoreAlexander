using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_DivisionRepository : Repository<HR_Division>, IHR_DivisionRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_DivisionRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

