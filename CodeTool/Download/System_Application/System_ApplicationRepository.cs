using TA.Data.Models;
namespace TA.Data.Repositories
{
public class System_ApplicationRepository : Repository<System_Application>, ISystem_ApplicationRepository
{
private readonly TheodoreAlexander_ERPContext _context;
public System_ApplicationRepository(TheodoreAlexander_ERPContext context) : base(context)
{
_context = context;
}
}
}

