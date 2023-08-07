using TA.Data.Models;
namespace TA.Data.Repositories
{
public class System_AuthenticationApplicationRepository : Repository<System_AuthenticationApplication>, ISystem_AuthenticationApplicationRepository
{
private readonly TheodoreAlexander_ERPContext _context;
public System_AuthenticationApplicationRepository(TheodoreAlexander_ERPContext context) : base(context)
{
_context = context;
}
}
}

