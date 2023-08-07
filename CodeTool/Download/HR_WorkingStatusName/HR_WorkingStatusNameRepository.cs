using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_WorkingStatusNameRepository : Repository<HR_WorkingStatusName>, IHR_WorkingStatusNameRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_WorkingStatusNameRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

