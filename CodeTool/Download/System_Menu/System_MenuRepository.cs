using TA.Data.Models;
namespace TA.Data.Repositories
{
public class System_MenuRepository : Repository<System_Menu>, ISystem_MenuRepository
{
private readonly TheodoreAlexander_ERPContext _context;
public System_MenuRepository(TheodoreAlexander_ERPContext context) : base(context)
{
_context = context;
}
}
}

