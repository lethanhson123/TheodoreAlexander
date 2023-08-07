using TA.Data.Models;
namespace TA.Data.Repositories
{
public class System_AuthenticationMenuRepository : Repository<System_AuthenticationMenu>, ISystem_AuthenticationMenuRepository
{
private readonly TheodoreAlexander_ERPContext _context;
public System_AuthenticationMenuRepository(TheodoreAlexander_ERPContext context) : base(context)
{
_context = context;
}
}
}

