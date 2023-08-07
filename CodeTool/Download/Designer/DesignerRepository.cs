using TA.Data.Models;
namespace TA.Data.Repositories
{
public class DesignerRepository : Repository<Designer>, IDesignerRepository
{
private readonly TheodoreAlexander_NewContext _context;
public DesignerRepository(TheodoreAlexander_NewContext context) : base(context)
{
_context = context;
}
}
}

