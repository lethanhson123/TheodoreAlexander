using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_GroupNameRepository : Repository<HR_GroupName>, IHR_GroupNameRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_GroupNameRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

