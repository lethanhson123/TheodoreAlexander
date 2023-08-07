using TA.Data.Models;
namespace TA.Data.Repositories
{
public class HR_StatusRepository : Repository<HR_Status>, IHR_StatusRepository
{
private readonly TheodoreAlexander_NewContext _context;
public HR_StatusRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

