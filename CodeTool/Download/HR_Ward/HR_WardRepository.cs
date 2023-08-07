using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_WardRepository : Repository<HR_Ward>, IHR_WardRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_WardRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

