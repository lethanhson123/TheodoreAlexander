using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_TeamNameRepository : Repository<HR_TeamName>, IHR_TeamNameRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_TeamNameRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

