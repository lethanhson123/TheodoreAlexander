using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_BlockNameRepository : Repository<HR_BlockName>, IHR_BlockNameRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_BlockNameRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

