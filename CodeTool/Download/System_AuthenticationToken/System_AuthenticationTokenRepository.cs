using TA.Data.Models;
namespace TA.Data.Repositories
{
public class System_AuthenticationTokenRepository : Repository<System_AuthenticationToken>, ISystem_AuthenticationTokenRepository
{
private readonly TheodoreAlexander_ERPContext _context;
public System_AuthenticationTokenRepository(TheodoreAlexander_ERPContext context) : base(context)
{
_context = context;
}
}
}

